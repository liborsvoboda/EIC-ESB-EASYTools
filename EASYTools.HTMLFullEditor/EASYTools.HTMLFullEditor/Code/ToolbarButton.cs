﻿using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using EASYTools.HTMLFullEditor.Interfaces;

namespace EASYTools.HTMLFullEditor.Code
{
    /// <summary>
    /// Class representing single toolbar button (can be toggleable).
    /// </summary>
    public class ToolbarButton : ToolbarElement
    {
        private readonly Action<IBrowserControl> _onClick;
        private readonly Func<IBrowserControl, bool> _getToggleState;
        private readonly object _buttonContent;

        protected ToolbarButton(string identifier) : base(identifier)
        {
            // only for inheritance
        }

        public ToolbarButton(string identifier, string name, ContentElement buttonContent, Action<IBrowserControl> onClick)
            :this(identifier, name, (object)buttonContent, onClick) {}

        public ToolbarButton(string identifier, string name, UIElement buttonContent, Action<IBrowserControl> onClick)
            :this(identifier, name, (object)buttonContent, onClick) {}

        private ToolbarButton(string identifier, string name, object buttonContent, Action<IBrowserControl> onClick)
            :base(identifier)
        {
            Name = name;
            _buttonContent = buttonContent;
            _onClick = onClick;
            IsToggleable = false;
            _getToggleState = (_) => throw new InvalidOperationException("Cannot check toggle state on non toggleable button.");
        }

        public ToolbarButton(string identifier, string name, ContentElement buttonContent, Action<IBrowserControl> onClick, Func<IBrowserControl, bool> getToggleState)
            :this(identifier, name, (object)buttonContent, onClick, getToggleState) {}

        public ToolbarButton(string identifier, string name, UIElement buttonContent, Action<IBrowserControl> onClick, Func<IBrowserControl, bool> getToggleState)
            :this(identifier, name, (object)buttonContent, onClick, getToggleState) {}

        private ToolbarButton(string identifier, string name, object buttonContent, Action<IBrowserControl> onClick, Func<IBrowserControl, bool> getToggleState)
            :base(identifier)
        {
            Name = name;
            _buttonContent = buttonContent;
            _onClick = onClick;
            IsToggleable = true;
            _getToggleState = getToggleState;
        }

        /// <summary>
        /// Gets localized name/tooltip text on this control.
        /// </summary>
        public virtual string Name
        {
            get;
        }

        /// <summary>
        /// Gets or sets whether the 'focus editor after click' function may be disabled.
        /// </summary>
        public bool DisableEditorFocusAfterClick
        {
            get;
            set;
        }

        /// <summary>
        /// Gets whether this button can be toggled.
        /// </summary>
        public bool IsToggleable
        {
            get => EnableCheckState;
            private set => EnableCheckState = value;
        }

        /// <summary>
        /// Action executed, when this button is clicked.
        /// </summary>
        public virtual void Clicked(IBrowserControl browserControl) => _onClick(browserControl);

        /// <summary>
        /// When <see cref="IsToggleable"/> = true, this action is returning whether this button is active/toggled.
        /// </summary>
        public virtual bool GetToggleState(IBrowserControl browserControl) => _getToggleState(browserControl);

        protected virtual object GetButtonContent() => _buttonContent;

        protected override FrameworkElement CreateElement(IBrowserControl browserControl)
        {
            ButtonBase button;

            if (IsToggleable)
            {
                button = new ToggleButton();
            }
            else
            {
                button = new Button();
            }

            button.ToolTip = Name;
            button.Content = GetButtonContent();
            button.Click += (s, e) =>
            {
                Clicked(browserControl);
                if (!DisableEditorFocusAfterClick)
                {
                    browserControl.Focus();
                }
            };

            return button;
        }

        protected override void CheckState(FrameworkElement element, IBrowserControl browserControl)
        {
            ((ToggleButton)element).IsChecked = GetToggleState(browserControl);
        }
    }
}
