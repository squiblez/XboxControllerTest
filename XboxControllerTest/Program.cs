//
//  Program.cs
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
using System.IO;
namespace XboxControllerTest
{
    class MainClass
    {

        public static void Main(string[] args)
        {   
            //Attempt to create object from /dev/input/js1
            //you may need to manually locate the device file and adjust this line
            linuxXboxController xcont = new linuxXboxController("/dev/input/js1", true);
            
            do
            {   
                //Check if an update to the controllers state has happened
                if(xcont.update())
                {
                    //Uncomment the code below to have raw bytes printed to console after each update is detected

                    //Convert the bytes to a string and print them
                    string hex = BitConverter.ToString(xcont.deviceBytes.ToArray());
                    Console.WriteLine(hex);
                }

            } while (true);
        }
    }
}
