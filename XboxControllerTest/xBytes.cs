//
//  xBytes.cs
//
//  Author:
//       Michael Sullender <squiblez@gmail.com>
//
//  Copyright (c) 2022 2023
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
    public enum xBytes
    {
        CounterSegment1 = 0x00,
        CounterSegment2 = 0x01,
        CounterSegment3 = 0x02,
        CounterSegment4 = 0x03,
        Argument1 = 0x04,
        Argument2 = 0x05,
        EventGroup = 0x06,
        Identifier = 0x07
    }
}
