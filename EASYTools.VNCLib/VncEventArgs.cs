// EASYTools.VNCLib - .NET VNC Client for WPF Library
// Copyright (C) 2008 David Humphrey
//
// This program is free software; you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation; either version 2 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program; if not, write to the Free Software
// Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA

using System;

namespace EASYTools.VNCLib
{
	public class VncEventArgs : EventArgs
	{
		IDesktopUpdater updater;
		
		public VncEventArgs(IDesktopUpdater updater) : base()
		{
			this.updater = updater;
		}
		
		/// <summary>
		/// Gets the IDesktopUpdater object that will handling re-drawing the desktop.
		/// </summary>
		public IDesktopUpdater DesktopUpdater {
			get { 
				return updater; 
			}
		}
	}
}