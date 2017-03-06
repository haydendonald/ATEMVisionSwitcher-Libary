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
    public class SwitcherInputMonitor : IBMDSwitcherInputCallback
    {
        private DebugConsole Console;
        private String _longName;
        private long _id;

        //Constructor
        public SwitcherInputMonitor(DebugConsole console, String longName, long id)
        {
            Console = console;
            _id = id;
            _longName = longName;

            Console.sendVerbose("Created SwitcherInputMonitor Object For Input " + longName + " (" + id + ")");
        }

        public event EventHandler AvailableExternalPortTypesChanged;
        public event EventHandler CurrentExternalPortTypeChanged;
        public event EventHandler IsPreviewTalliedChanged;
        public event EventHandler IsProgramTalliedChanged;
        public event EventHandler LongNameChanged;
        public event EventHandler ShortNameChanged;

        public void Notify(_BMDSwitcherInputEventType eventType)
        {
            //Switch the event type
            switch (eventType)
            {
                case _BMDSwitcherInputEventType.bmdSwitcherInputEventTypeAvailableExternalPortTypesChanged:
                    if (AvailableExternalPortTypesChanged != null)
                    {
                        Console.sendVerbose("AvailableExternalPortTypesChanged Has Changed On Switcher Input " + _longName + " (" + _id + ")");
                        AvailableExternalPortTypesChanged(this, null);
                    }
                    break;
                case _BMDSwitcherInputEventType.bmdSwitcherInputEventTypeCurrentExternalPortTypeChanged:
                    if (CurrentExternalPortTypeChanged != null)
                    {
                        Console.sendVerbose("CurrentExternalPortTypeChanged Has Changed On Switcher Input " + _longName + " (" + _id + ")");
                        CurrentExternalPortTypeChanged(this, null);
                    }
                    break;
                case _BMDSwitcherInputEventType.bmdSwitcherInputEventTypeIsPreviewTalliedChanged:
                    if (IsPreviewTalliedChanged != null)
                    {
                        Console.sendVerbose("IsPreviewTalliedChanged Has Changed On Switcher Input " + _longName + " (" + _id + ")");
                        IsPreviewTalliedChanged(this, null);
                    }
                    break;
                case _BMDSwitcherInputEventType.bmdSwitcherInputEventTypeIsProgramTalliedChanged:
                    if (IsProgramTalliedChanged != null)
                    {
                        Console.sendVerbose("IsProgramTalliedChanged Has Changed On Switcher Input " + _longName + " (" + _id + ")");
                        IsProgramTalliedChanged(this, null);
                    }
                    break;
                case _BMDSwitcherInputEventType.bmdSwitcherInputEventTypeLongNameChanged:
                    if (LongNameChanged != null)
                    {
                        Console.sendVerbose("LongNameChanged Has Changed On Switcher Input " + _longName + " (" + _id + ")");
                        LongNameChanged(this, null);
                    }
                    break;
                case _BMDSwitcherInputEventType.bmdSwitcherInputEventTypeShortNameChanged:
                    if (ShortNameChanged != null)
                    {
                        Console.sendVerbose("ShortNameChanged Has Changed On Switcher Input " + _longName + " (" + _id + ")");
                        ShortNameChanged(this, null);
                    }
                    break;
            }
        }
    }
}
