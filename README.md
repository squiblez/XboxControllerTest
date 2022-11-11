# XboxControllerTest
Example/Reference program demonstrating how to read raw input from an xbox/xinput gamepad in Linux using an IO.File.FileStream object.

A complete but small and simple library specifically(and only) for connecting to and parsing/abstracting information from an Xbox 360(or later) controller on Linux using device files.

it includes:
linuxXboxController class, the container object that will read packets from device file and parse them into a state class that represents axis and button data.
controllerState class, an abstraction container that will allow you to check button and axis states without having to read or understand bytes from device files.
Enumerations for Xbox controller buttons and axis IDs, so indexing the status of axis or button values is simple.