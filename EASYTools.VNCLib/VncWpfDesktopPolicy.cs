

using System;
//using System.Windows.Forms;
using System.Drawing;

using EASYTools.VNCLib;

namespace EASYTools.VNCLib
{
	/// <summary>
	/// A clipped version of VncDesktopTransformPolicy.
	/// </summary>
	public sealed class VncWpfDesktopPolicy : VncDesktopTransformPolicy
	{
        public VncWpfDesktopPolicy(VncClient vnc,
                                       EASYTools.VNCLib remoteDesktop) 
            : base(vnc, remoteDesktop)
        {
        }

        public override bool AutoScroll {
            get {
                return true;
            }
        }

        public override Size AutoScrollMinSize {
            get {
                if (vnc != null && vnc.Framebuffer != null) {
                    return new Size(vnc.Framebuffer.Width, vnc.Framebuffer.Height);
                } else {
                    return new Size(100, 100);
                }
            }
        }

        public override Point UpdateRemotePointer(Point current)
        {
            Point adjusted = new Point();

            adjusted.X = (int)((double)current.X / remoteDesktop.ImageScale);
            adjusted.Y = (int)((double)current.Y / remoteDesktop.ImageScale);

            return adjusted;
        }

        public override Rectangle AdjustUpdateRectangle(Rectangle updateRectangle)
        {
			int x, y;


            if (remoteDesktop.ActualWidth > remoteDesktop.designModeDesktop.ActualWidth)
            {
                x = updateRectangle.X + (int)(remoteDesktop.ActualWidth - remoteDesktop.designModeDesktop.ActualWidth) / 2;
            }
            else
            {
                x = updateRectangle.X;
            }

            if (remoteDesktop.ActualHeight > remoteDesktop.designModeDesktop.ActualHeight)
            {
                y = updateRectangle.Y + (int)(remoteDesktop.ActualHeight - remoteDesktop.designModeDesktop.ActualHeight) / 2;
            }
            else
            {
                y = updateRectangle.Y;
            }

			return new Rectangle(x, y, updateRectangle.Width, updateRectangle.Height);
        }

        public override Point GetMouseMovePoint(Point current)
        {
            return UpdateRemotePointer(current);
        }
    }
}