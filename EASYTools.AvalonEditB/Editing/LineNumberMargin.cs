﻿// Copyright (c) 2014 AlphaSierraPapa for the SharpDevelop Team
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy of this
// software and associated documentation files (the "Software"), to deal in the Software
// without restriction, including without limitation the rights to use, copy, modify, merge,
// publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons
// to whom the Software is furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all copies or
// substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED,
// INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR
// PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE
// FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR
// OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
// DEALINGS IN THE SOFTWARE.

using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.TextFormatting;

using AvalonEditB.Document;
using AvalonEditB.Rendering;
using AvalonEditB.Utils;

namespace AvalonEditB.Editing
{
	/// <summary>
	/// Margin showing line numbers.
	/// </summary>
	public class LineNumberMargin : AbstractMargin, IWeakEventListener
	{
		/// <summary>
		/// Creates a new instance of a LineNumberMargin
		/// </summary>
		public LineNumberMargin()
			:base()
		{
			// override Property Value Inheritance, and always render
			// the line number margin left-to-right
			FlowDirection = FlowDirection.LeftToRight;
			foregroundColor.Freeze();
			foregroundCurrColor.Freeze();
		}

		static LineNumberMargin()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(LineNumberMargin),
													 new FrameworkPropertyMetadata(typeof(LineNumberMargin)));
		}

		TextArea textArea;

		/// <summary>
		/// The typeface used for rendering the line number margin.
		/// This field is calculated in MeasureOverride() based on the FontFamily etc. properties.
		/// </summary>
		protected Typeface typeface;


		/// <summary>
		/// The font size used for rendering the line number margin.
		/// This field is calculated in MeasureOverride() based on the FontFamily etc. properties.
		/// </summary>
		protected double emSize;

		SolidColorBrush backgroundColor = null;
		SolidColorBrush foregroundColor = Brushes.Silver;
		SolidColorBrush foregroundCurrColor = Brushes.Black;

		Action<DrawingContext,int,Point,Point> drawInMargin = null;

		/// <summary> Highlight the current line number. True by default</summary>
		public bool HighlightCurrentLineNumber { get; set;} = true;
		
		/// <summary> Color of the current line number text. </summary>
		public SolidColorBrush CurrentLineNumberForegroundColor{ 
			get { return foregroundCurrColor; }
			set { value?.Freeze(); foregroundCurrColor = value; }			
		}
		
		/// <summary> Color of the  line number text. </summary>
		public SolidColorBrush LineNumberForegroundColor{ 
			get { return foregroundColor; }
			set { value?.Freeze(); foregroundColor = value; }			
		}	

		/// <summary>
		/// Get or Set the background color of the full Margin
		/// </summary>		
		public SolidColorBrush BackgroundColor {
			get { return backgroundColor; }
			set { value?.Freeze(); backgroundColor = value; }			
		}

		/// <summary> 
		/// Action to set to draw next to line number. 
		/// the int is the line number.
		/// The Points are bottom left and top right of the line number text.
		/// </summary>
		public Action<DrawingContext,int,Point,Point> DrawInMargin {
			get { return drawInMargin; }
			set { drawInMargin = value; }			
		}


		/// <inheritdoc/>
		protected override Size MeasureOverride(Size availableSize)
		{
			typeface = this.CreateTypeface();
			emSize = (double)GetValue(TextBlock.FontSizeProperty);

			FormattedText text = TextFormatterFactory.CreateFormattedText(
				this,
				new string('9', maxLineNumberLength),
				typeface,
				emSize,
				LineNumberForegroundColor //(Brush)GetValue(Control.ForegroundProperty) // previous foreground
			);
			return new Size(text.Width + 3.0, 0);
		}

		/// <inheritdoc/>
		protected override void OnRender(DrawingContext drawingContext)
		{
			TextView textView = this.TextView;
			Size renderSize = this.RenderSize;
			if (textView != null && textView.VisualLinesValid) {

				// draw Background
				if ( backgroundColor != null) { 
					drawingContext.DrawRectangle(backgroundColor, null, new Rect(0, 0, renderSize.Width, renderSize.Height));
				}

				//var foreground = (Brush)GetValue(Control.ForegroundProperty); // previous foreground
				int curr = textView.HighlightedLine; // the current line number
				
				foreach (VisualLine line in textView.VisualLines) {
					int lineNumber = line.FirstDocumentLine.LineNumber;
					SolidColorBrush foreground = // make current line number black if HighlightCurrentLineNumber is true :	
						(lineNumber == curr && HighlightCurrentLineNumber) ? CurrentLineNumberForegroundColor : LineNumberForegroundColor;
					FormattedText text = TextFormatterFactory.CreateFormattedText(
						this,
						lineNumber.ToString(CultureInfo.CurrentCulture),
						typeface, //lineNumber == curr ? typeface : typeface,	// make current line number BOLD ??
						emSize, 
						foreground	
					);
					double y = line.GetTextLineVisualYPosition(line.TextLines[0], VisualYPosition.TextTop);
					Point pt = new Point(renderSize.Width - text.Width, y - textView.VerticalOffset);
					drawingContext.DrawText(text, pt);
					
					// optional additional drawing action on margin
					if (drawInMargin != null){
						Point a = new Point(0, y - textView.VerticalOffset);
						Point b = new Point(renderSize.Width, y - textView.VerticalOffset-text.Height);
						drawInMargin(drawingContext, lineNumber, a, b); // additional drawing action on margin
					}
					
				}
			}
		}

		/// <inheritdoc/>
		protected override void OnTextViewChanged(TextView oldTextView, TextView newTextView)
		{
			if (oldTextView != null) {
				oldTextView.VisualLinesChanged -= TextViewVisualLinesChanged;
			}
			base.OnTextViewChanged(oldTextView, newTextView);
			if (newTextView != null) {
				newTextView.VisualLinesChanged += TextViewVisualLinesChanged;

				// find the text area belonging to the new text view
				textArea = newTextView.GetService(typeof(TextArea)) as TextArea;
			} else {
				textArea = null;
			}
			InvalidateVisual();
		}

		/// <inheritdoc/>
		protected override void OnDocumentChanged(TextDocument oldDocument, TextDocument newDocument)
		{
			if (oldDocument != null) {
				PropertyChangedEventManager.RemoveListener(oldDocument, this, "LineCount");
			}
			base.OnDocumentChanged(oldDocument, newDocument);
			if (newDocument != null) {
				PropertyChangedEventManager.AddListener(newDocument, this, "LineCount");
			}
			OnDocumentLineCountChanged();
		}

		/// <inheritdoc cref="IWeakEventListener.ReceiveWeakEvent"/>
		protected virtual bool ReceiveWeakEvent(Type managerType, object sender, EventArgs e)
		{
			if (managerType == typeof(PropertyChangedEventManager)) {
				OnDocumentLineCountChanged();
				return true;
			}
			return false;
		}

		bool IWeakEventListener.ReceiveWeakEvent(Type managerType, object sender, EventArgs e)
		{
			return ReceiveWeakEvent(managerType, sender, e);
		}

		/// <summary>
		/// Maximum length of a line number, in characters
		/// </summary>
		protected int maxLineNumberLength = 1;

		void OnDocumentLineCountChanged()
		{
			int documentLineCount = Document != null ? Document.LineCount : 1;
			int newLength = documentLineCount.ToString(CultureInfo.CurrentCulture).Length;

			// The margin looks too small when there is only one digit, so always reserve space for
			// at least two digits
			if (newLength < 2)
				newLength = 2;

			if (newLength != maxLineNumberLength) {
				maxLineNumberLength = newLength;
				InvalidateMeasure();
			}
		}

		void TextViewVisualLinesChanged(object sender, EventArgs e)
		{
			InvalidateVisual();
		}

		AnchorSegment selectionStart;
		bool selecting;

		/// <inheritdoc/>
		protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
		{
			base.OnMouseLeftButtonDown(e);
			if (!e.Handled && TextView != null && textArea != null) {
				e.Handled = true;
				textArea.Focus();

				SimpleSegment currentSeg = GetTextLineSegment(e);
				if (currentSeg == SimpleSegment.Invalid)
					return;
				textArea.Caret.Offset = currentSeg.Offset + currentSeg.Length;
				if (CaptureMouse()) {
					selecting = true;
					selectionStart = new AnchorSegment(Document, currentSeg.Offset, currentSeg.Length);
					if ((Keyboard.Modifiers & ModifierKeys.Shift) == ModifierKeys.Shift) {
						SimpleSelection simpleSelection = textArea.Selection as SimpleSelection;
						if (simpleSelection != null)
							selectionStart = new AnchorSegment(Document, simpleSelection.SurroundingSegment);
					}
					textArea.Selection = Selection.Create(textArea, selectionStart);
					if ((Keyboard.Modifiers & ModifierKeys.Shift) == ModifierKeys.Shift) {
						ExtendSelection(currentSeg);
					}
					textArea.Caret.BringCaretToView(5.0);
				}
			}
		}

		SimpleSegment GetTextLineSegment(MouseEventArgs e)
		{
			Point pos = e.GetPosition(TextView);
			pos.X = 0;
			pos.Y = pos.Y.CoerceValue(0, TextView.ActualHeight);
			pos.Y += TextView.VerticalOffset;
			VisualLine vl = TextView.GetVisualLineFromVisualTop(pos.Y);
			if (vl == null)
				return SimpleSegment.Invalid;
			TextLine tl = vl.GetTextLineByVisualYPosition(pos.Y);
			int visualStartColumn = vl.GetTextLineVisualStartColumn(tl);
			int visualEndColumn = visualStartColumn + tl.Length;
			int relStart = vl.FirstDocumentLine.Offset;
			int startOffset = vl.GetRelativeOffset(visualStartColumn) + relStart;
			int endOffset = vl.GetRelativeOffset(visualEndColumn) + relStart;
			if (endOffset == vl.LastDocumentLine.Offset + vl.LastDocumentLine.Length)
				endOffset += vl.LastDocumentLine.DelimiterLength;
			return new SimpleSegment(startOffset, endOffset - startOffset);
		}

		void ExtendSelection(SimpleSegment currentSeg)
		{
			if (currentSeg.Offset < selectionStart.Offset) {
				textArea.Caret.Offset = currentSeg.Offset;
				textArea.Selection = Selection.Create(textArea, currentSeg.Offset, selectionStart.Offset + selectionStart.Length);
			} else {
				textArea.Caret.Offset = currentSeg.Offset + currentSeg.Length;
				textArea.Selection = Selection.Create(textArea, selectionStart.Offset, currentSeg.Offset + currentSeg.Length);
			}
		}

		/// <inheritdoc/>
		protected override void OnMouseMove(MouseEventArgs e)
		{
			if (selecting && textArea != null && TextView != null) {
				e.Handled = true;
				SimpleSegment currentSeg = GetTextLineSegment(e);
				if (currentSeg == SimpleSegment.Invalid)
					return;
				ExtendSelection(currentSeg);
				textArea.Caret.BringCaretToView(5.0);
			}
			base.OnMouseMove(e);
		}

		/// <inheritdoc/>
		protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e)
		{
			if (selecting) {
				selecting = false;
				selectionStart = null;
				ReleaseMouseCapture();
				e.Handled = true;
			}
			base.OnMouseLeftButtonUp(e);
		}

		/// <inheritdoc/>
		protected override HitTestResult HitTestCore(PointHitTestParameters hitTestParameters)
		{
			// accept clicks even when clicking on the background
			return new PointHitTestResult(this, hitTestParameters.HitPoint);
		}
	}
}