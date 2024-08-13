using System;

namespace EASYTools.VNCLib
{
	/// <summary>
	/// Used in connection with the ConnectComplete event. Contains information about the remote desktop useful for setting-up the client's GUI.
	/// </summary>
	public class ConnectEventArgs : EventArgs
	{
		int width;
		int height;
		string name;
		
		/// <summary>
		/// Constructor for ConnectEventArgs
		/// </summary>
		/// <param name="width">An Integer indicating the Width of the remote framebuffer.</param>
		/// <param name="height">An Integer indicating the Height of the remote framebuffer.</param>
		/// <param name="name">A String containing the name of the remote Desktop.</param>
		public ConnectEventArgs(int width, int height, string name) : base()
		{
			this.width = width;
			this.height = height;
			this.name = name;
		}
		
		/// <summary>
		/// Gets the Width of the remote Desktop.
		/// </summary>
		public int DesktopWidth {
			get { 
				return width; 
			}
		}
		
		/// <summary>
		/// Gets the Height of the remote Desktop.
		/// </summary>
		public int DesktopHeight {
			get { 
				return height; 
			}
		}
		
		/// <summary>
		/// Gets the name of the remote Desktop, if any.
		/// </summary>
		public string DesktopName {
			get { 
				return name; 
			}
		}
	}
}
