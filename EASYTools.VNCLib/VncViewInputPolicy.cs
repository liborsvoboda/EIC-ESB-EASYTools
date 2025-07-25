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
using System.Drawing;
using System.Diagnostics;

namespace EASYTools.VNCLib
{
	/// <summary>
	/// A view-only version of IVncInputPolicy.
	/// </summary>
	public sealed class VncViewInputPolicy : IVncInputPolicy
	{
		public VncViewInputPolicy(RfbProtocol rfb)
		{
			Debug.Assert(rfb != null);
		}

		public void WriteKeyboardEvent(uint keysym, bool pressed)
		{
		}

		public void WritePointerEvent(byte buttonMask, Point point)
		{
		}
	}
}