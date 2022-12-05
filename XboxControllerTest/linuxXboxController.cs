//
//  linuxXboxController.cs
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
using System.Collections.Generic;

namespace XboxControllerTest
{
    public class linuxXboxController
    {
        //device file stream
        FileStream deviceStream;
        //external counter
        int counter = 0;

        //debug flag(setting true will make updates print information about the parsed bytes
        bool debug = false;

        //the list of Bytes, it is represented as a list incase an incorrect joystick type is connected and has more bytes
        public List<byte> deviceBytes = new List<byte>();

        //The create new abstraction class to save information parsed from the raw device file
        public controllerState state = new controllerState();

        /// <summary>
        /// Creates a new Xbox controller instance from a device file
        /// </summary>
        /// <param name="devicefile">Full path to device.</param>
        public linuxXboxController(string devicefile, bool deviceDebug = false)
        {
            try
            {
                deviceStream = File.Open(devicefile, FileMode.Open);
                debug = deviceDebug;
            }
            catch (Exception ex)
            {   
                //Don't throw the exception, just print it.
                Console.WriteLine("Failed to initialize input device: " + devicefile);
                Console.WriteLine(ex.Message);
            }

        }

        /// <summary>
        /// Update this instance.
        /// </summary>
        /// <returns>True if the device state has updated.</returns>
        public bool update()
        {
            //the output buffer
            bool output = false;

            //clears existing bytes list.
            deviceBytes.Clear();

            //Collection loop
            do
            {
                //If a new byte is available, an update has occured
                if(deviceStream.CanRead)
                {
                    int data = deviceStream.ReadByte();

                    //Set output to true since an update has happened
                    output = true;

                    //Insert bytes into buffer(in order)
                    deviceBytes.Add((byte)data);


                }
                //Increase counter
                counter++;
                
            } while (counter < 8);

            //Reset counter
            counter = 0;

            //Grab the event type identifier byte and cast it to xEvents enum
            xEvents eventType = (xEvents)deviceBytes.ToArray()[6];

            //Check for button event
            if(eventType == xEvents.ButtonAction)
            {
                if (debug) Console.WriteLine("Button action event!");
                xButtons button = (xButtons)deviceBytes.ToArray()[7];
                xButtonEventTypes buttonAction = (xButtonEventTypes)deviceBytes.ToArray()[4];
                if (debug) Console.Write(button.ToString());

                if(buttonAction == xButtonEventTypes.Pressed)
                {
                    state.buttons[(byte)button] = true;
                    if (debug) Console.WriteLine(" pressed.");
                }
                else if(buttonAction == xButtonEventTypes.Released)
                {
                    state.buttons[(byte)button] = false;
                    if (debug) Console.WriteLine(" released.");
                }
            }
            //Check for axis event
            else if(eventType == xEvents.AxisMoved)
            {
                if (debug) Console.WriteLine("Axis action event!");
                xAxis axis = (xAxis)deviceBytes.ToArray()[7];
                if (debug) Console.Write(axis.ToString());
                byte[] cbytes = { deviceBytes.ToArray()[3], deviceBytes.ToArray()[4] };
                Int16 value = BitConverter.ToInt16(cbytes, 0);
                state.axis[(byte)axis] = value;

                if (debug) Console.WriteLine(" moved to " + value.ToString());
            }
            else
            {
                if (debug) Console.WriteLine("Unknown event occured(this is normal immediately after connection)");
            }



            return output;
        }
    }
}
