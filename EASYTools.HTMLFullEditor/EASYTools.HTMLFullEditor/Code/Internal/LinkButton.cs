using System.Windows;
using EASYTools.HTMLFullEditor.Dialogs;
using EASYTools.HTMLFullEditor.Interfaces;
using EASYTools.HTMLFullEditor.Localization;
using EASYTools.HTMLFullEditor.Views;
using mshtml;

namespace EASYTools.HTMLFullEditor.Code
{
    internal class LinkButton : ToolbarButton
    {
        public LinkButton() : base(nameof(StandardToolbarElement.Link), ResourceManager.Text_Link, ResourceHelper.GetIcon("Icon_Earth"), null)
        {
        }

        public override void Clicked(IBrowserControl browserControl)
        {
            var range = (IHTMLTxtRange)browserControl.CurrentDocument.selection.createRange();
            var selectedText = range.text;

            var linkDialog = new HyperlinkDialog(selectedText);
            linkDialog.Owner = Window.GetWindow((EditorBrowser)browserControl);
            if (linkDialog.ShowDialog() == true)
            {
                CreateAnchor(range, linkDialog);
            }
        }

        private void CreateAnchor(IHTMLTxtRange selectedRange, HyperlinkDialog resultDialog)
        {
            var url = resultDialog.Url.EscapeHtml();
            var txt = resultDialog.Text.EscapeHtml(true);
            if (string.IsNullOrEmpty(txt))
            {
                txt = resultDialog.Url.EscapeHtml(true);
            }
            string anchor = $"<a href=\"{url}\">{txt}</a>";
            selectedRange.pasteHTML(anchor);
        }
    }
}
