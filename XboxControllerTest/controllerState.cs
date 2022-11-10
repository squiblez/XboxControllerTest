//
//  controllerState.cs
//
//  Author:
//       Michael Sullender <squiblez@gmail.com>
//
//  Copyright (c) 2022 2022
//
//  This program is free software; you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation; either version 2 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with this program; if not, write to the Free Software
//  Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA 02111-1307 USA
//
using System;
namespace XboxControllerTest
{
    /// <summary>
    /// Abstraction used by the linuxXboxController to check the indivdual state of each button and axis between updates.
    /// </summary>
    public class controllerState
    {
        public bool[] buttons = new bool[0x0B];
        public short[] axis = new short[0x09];

        //Get the state of a button via enumerator.
        public bool getButtonState(xButtons button)
        {
            bool output = false;
            try
            {
                output = buttons[(byte)button];
            }
            catch { }
            return output;
        }

        //Get the state of an axis via enumerator.
        public short getAxisState(xEvents _axis)
        {
            short output = 0;
            try
            {
                output = axis[(byte)_axis];
            }
            catch { }
            return output;
        }

        public controllerState()
        {

        }
    }
}
