using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using EASYTools.HTMLFullEditor.Interfaces;
using EASYTools.HTMLFullEditor.Localization;

namespace EASYTools.HTMLFullEditor.Code
{
    internal class HighlightColorButton : ColorButtonBase
    {
        public HighlightColorButton() : base(nameof(StandardToolbarElement.LineHighlightColor), ResourceManager.Text_HighlightColor, Colors.Yellow)
        {
        }

        protected override UIElement CreateMainButtonContent()
        {
            /*
             * <Viewbox Height="16">
                    <Grid>
                        <ContentControl Content="{StaticResource Icon_HighlightColor_Main}" Margin="-2,0,2,0" />
                        <ContentControl Content="{StaticResource Icon_HighlightColor_Underscore}" Margin="-2,0,2,0" />
                    </Grid>
                </Viewbox>
             */

            var scaler = new Viewbox();
            scaler.Height = 16;

            var container = new Grid();
            var icon = ResourceHelper.GetIcon("Icon_HighlightColor_Main");
            Underscore = (Path)ResourceHelper.GetIcon("Icon_HighlightColor_Underscore");
            container.Children.Add(icon);
            container.Children.Add(Underscore);

            scaler.Child = container;

            return scaler;
        }

        protected override void UseCurrentColor(IBrowserControl browserControl)
        {
            var color = ColorPicker.LastSelectedColor;
            browserControl.ExecuteCommand("BackColor", false, Utils.FormatColor(color));
        }
    }
}
