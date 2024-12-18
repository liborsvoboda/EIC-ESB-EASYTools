﻿using System;
using System.Collections.Concurrent;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interop;
using EASYTools.HTMLFullEditor.Annotations;
using EASYTools.HTMLFullEditor.Interfaces;
using EASYTools.HTMLFullEditor.ViewModels;
using EASYTools.HTMLFullEditor.Views;

namespace EASYTools.HTMLFullEditor
{
    public class HtmlEditor : UserControl
    {
        /*
         * Access keys are fired in web browser control, event when typing
         * (Error in complex environments, where Focus is handled badly for COM objects - see https://stackoverflow.com/questions/18256886/webbrowser-control-keyboard-and-focus-behavior).
         * For example when there is command with access key 'e', you couldn't write 'e' when editing text inside browser.
         * Solution inspiration: https://stackoverflow.com/questions/8444012/access-key-getting-selected-even-we-did-not-press-alt-key-in-wpf
         */

        #region Access Keys resolve

        static HtmlEditor()
        {
            // registering for access key events
            EventManager.RegisterClassHandler(
                typeof(UIElement),
                AccessKeyManager.AccessKeyPressedEvent,
                new AccessKeyPressedEventHandler(AccessKeyPressedEventHandler)
            );
        }

        private static void AccessKeyPressedEventHandler(object sender, AccessKeyPressedEventArgs e)
        {
            // If Alt key is not pressed - handle the event
            if ((Keyboard.Modifiers & ModifierKeys.Alt) != ModifierKeys.Alt)
            {
                foreach (var kv in LoadedEditors)
                {
                    // if any HtmlEditor inner browser has focus - cancel this event
                    if (kv.Key.InnerBrowserHasFocus)
                    {
                        e.Target = null;
                        e.Handled = true;
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// Saving all currently loaded Editors inside.
        /// </summary>
        private static readonly ConcurrentDictionary<HtmlEditor, bool> LoadedEditors = new ConcurrentDictionary<HtmlEditor, bool>();

        private static void OnControlLoaded(object sender, RoutedEventArgs e)
        {
            var editor = (HtmlEditor)sender;
            LoadedEditors.TryAdd(editor, true);
        }

        private static void OnControlUnloaded(object sender, RoutedEventArgs e)
        {
            var editor = (HtmlEditor)sender;
            LoadedEditors.TryRemove(editor, out _);
        }

        #endregion

        public HtmlEditor()
        {
            InitializeEditor();

            this.Loaded += OnControlLoaded;
            this.Unloaded += OnControlUnloaded;
        }

        private void InitializeEditor()
        {
            var dockPanel = new DockPanel();

            EditorBrowser browser = new EditorBrowser();
            var toolbar = new EditorToolbar();

            DockPanel.SetDock(toolbar, Dock.Top);
            dockPanel.Children.Add(toolbar);
            DockPanel.SetDock(browser, Dock.Bottom);
            dockPanel.Children.Add(browser);

            // dependency on html content
            browser.HtmlContentChanged += BrowserContentChanged;

            // set DataContexts and properties
            dockPanel.DataContext = this;
            toolbar.DataContext = Toolbar = new ToolbarViewModel(browser);
            Browser = browser;

            // render new content
            Content = dockPanel;
        }

        /// <summary>
        /// Gets toolbar view model.
        /// </summary>
        public ToolbarViewModel Toolbar
        {
            get;
            set;
        }

        /// <summary>
        /// Gets browser control.
        /// </summary>
        public IBrowserControl Browser
        {
            get;
            set;
        }

        /// <summary>
        /// Gets whether this HtmlEditor has Focus inside.
        /// Handles the situation even when the focus is inside the WebBrowser control (COM Object).
        /// </summary>
        public bool HasFocusInside
        {
            get
            {
                if (IsKeyboardFocusWithin)
                    return true;

                // focus can also be inside the browser
                return InnerBrowserHasFocus;
            }
        }

        /// <summary>
        /// Gets whether the inner WebBrowser COM object has focus.
        /// </summary>
        /// <remarks>
        /// https://stackoverflow.com/questions/18256886/webbrowser-control-keyboard-and-focus-behavior
        /// </remarks>
        private bool InnerBrowserHasFocus => ((IKeyboardInputSink)((EditorBrowser)Browser).Browser).HasFocusWithin();

        #region HtmlContent dependency property

        /// <summary>
        /// Gets or sets whether the HtmlContent dependency property change should not be called after setting new value.
        /// When this is turned off, you will se the HtmlContent to internal browser and after the browser will load the HTML,
        /// it will se the HtmlContent dependency property back to new (altered) html content, used to render the UI of WYSIWYG (even when the user does not make any change).
        /// </summary>
        public bool HtmlContentDisableInitialChange
        {
            get;
            set;
        } = true;

        /// <summary>
        /// Gets or sets html content of this editor.
        /// </summary>
        public string HtmlContent
        {
            get => (string)GetValue(HtmlContentProperty);
            set => SetValue(HtmlContentProperty, value);
        }
        public static readonly DependencyProperty HtmlContentProperty = DependencyProperty.Register(nameof(HtmlContent), typeof(string), typeof(HtmlEditor), new FrameworkPropertyMetadata(HtmlContentPropertyChanged){BindsTwoWayByDefault = true});

        private static void HtmlContentPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
            var editor = (HtmlEditor)d;

            // if the content had changed, resetting tracking variables
            if (editor.Browser.OpenDocument((string)e.NewValue))
            {
                editor._firstLoadedContent = null;
                editor._hasChangedAfterFirstLoad = false;

                // in source edit mode, BrowserContentChanged method is called immediately in OpenDocument method
                // so i need to call it again manually, to initiate tracking variables
                if (editor.Browser.IsInSourceEditMode)
                {
                    editor.BrowserContentChanged(editor, null);
                }
            }
        }

        private void BrowserContentChanged(object sender, EventArgs e)
        {
            var content = Browser.GetCurrentHtml();

            if (HtmlContentDisableInitialChange)
            {
                // after first load - saving the (maybe transformed) HTML editor
                if (_firstLoadedContent == null)
                {
                    _firstLoadedContent = content;
                    return;
                }
                // checking if the content has not changed
                if (!_hasChangedAfterFirstLoad && content == _firstLoadedContent)
                {
                    return;
                }
                _hasChangedAfterFirstLoad = true;
            }

            HtmlContent = content;
        }

        private bool _hasChangedAfterFirstLoad;
        private string _firstLoadedContent;

        #endregion
    }
}
