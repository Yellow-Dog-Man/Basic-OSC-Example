# Simple OSC Tester
A quick debugging application, designed to connect to Resonite's OSC_Reciever component and to test connectivity.

Feel free to use it to validate if your network setup will allow OSC connectivity or as a jumping off point for further development.

## Testing
1. In Resonite, attach an OSC_Reciever Component to an Empty Object (Component can be found in Network/OSC)
1. Specify the network port in the port field of the component.
1. Specify the user in the user field of the component.
1. Verify that the "Is Listening" checkbox is enabled
1. Add a `OSC_Value<T>` component, with the data type `Long`.
1. Drag the receiver from previous steps into the handler on the `OSC_Value`.
1. Set the Path of the OSC_Value to `/test`
1. Run this application using 2 CLI arguments, the first being the IP Address and the second being the port:
    - e.g. `OSCTester.exe 127.0.0.1 3001`

You should then see the OSC Value counting upwards with the Unix Epoch in Seconds, which is generated from the application.


## Screenshots

## Setup in Resonite
![240430-YTQIXWJRoCD19LF7A50K](https://github.com/Yellow-Dog-Man/Basic-OSC-Example/assets/8791132/e0ed7207-b357-44d6-bfe1-410b5212ce8a)

## The app itself running
![240430-nIm13FxNPpvyXALa0lxg](https://github.com/Yellow-Dog-Man/Basic-OSC-Example/assets/8791132/c8a616f9-051c-4ed4-837d-431748502a5a)
