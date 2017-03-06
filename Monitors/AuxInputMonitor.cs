/**
	ATEM Vision Switcher Libary By Hayden Donald 2017
	https://github.com/haydendonald/ATEMVisionSwitcher-Libary

	This libary is repsonsible for the interfacing with the Black Magic ATEM Vision Switcher using the given api
    found at https://www.blackmagicdesign.com/support
*/

using System;
using BMDSwitcherAPI;

namespace ATEMVisionSwitcher
{
    public class AuxInputMonitor : IBMDSwitcherInputAuxCallback
    {
        private DebugConsole Console;
        private String _longName;
        private long _id;

        //Constructor
        public AuxInputMonitor(DebugConsole console, String longName, long id)
        {
            Console = console;
            _id = id;
            _longName = longName;

            Console.sendVerbose("Created AuxInputMonitor Object For Input " + longName + " (" + id + ")");
        }

        public event EventHandler InputSourceChanged;

        public void Notify(_BMDSwitcherInputAuxEventType eventType)
        {
            //Switch the event type
            switch (eventType)
            {
                case _BMDSwitcherInputAuxEventType.bmdSwitcherInputAuxEventTypeInputSourceChanged:
                    if (InputSourceChanged != null)
                    {
                        Console.sendVerbose("InputSource Has Changed On Switcher Input " + _longName + " (" + _id + ")");
                        InputSourceChanged(this, null);
                    }
                    break;
            }
        }
    }
}
