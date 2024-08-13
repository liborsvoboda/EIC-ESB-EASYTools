using System;
using System.Windows;
using System.Windows.Controls.Primitives;
using EASYTools.HTMLFullEditor.Interfaces;
using EASYTools.HTMLFullEditor.Localization;
using EASYTools.HTMLFullEditor.ViewModels;

namespace EASYTools.HTMLFullEditor.Code
{
    internal class ShowHtmlButton : ToolbarElement
    {
        private readonly ToolbarViewModel _toolbarViewModel;

        public ShowHtmlButton(ToolbarViewModel toolbarViewModel) : base(nameof(StandardToolbarElement.ToggleHtmlCode))
        {
            _toolbarViewModel = toolbarViewModel;
        }

        protected override FrameworkElement CreateElement(IBrowserControl browserControl)
        {
            var button = new ToggleButton();
            button.ToolTip = ResourceManager.Text_HtmlCode;
            button.Content = ResourceHelper.GetIcon("Icon_Code");

            button.Click += (s, e) =>
            {
                // ReSharper disable once PossibleInvalidOperationException
                browserControl.ToggleSourceEditor(_toolbarViewModel, button.IsChecked.Value /*!browserControl.IsInSourceEditMode*/);
            };

            return button;
        }

        public override bool EnabledInSourceMode
        {
            get => true;
            set => throw new InvalidOperationException();
        }
    }
}
