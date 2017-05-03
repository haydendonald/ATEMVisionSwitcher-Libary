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
    public class UpstreamKeyerMonitor : IBMDSwitcherKeyCallback
    {
        private DebugConsole Console;
        private String _id;
        private long _number;

        //Constructor
        public UpstreamKeyerMonitor(DebugConsole console, String id, long number)
        {
            Console = console;
            _id = id;
            _number = number;

            Console.sendVerbose("Created UpstreamKeyerMonitor Object For Mix Effect Block " + id + " (" + number + ")");
        }


        //Events
        public event EventHandler CanBeDVEKeyChanged;
        public event EventHandler InputCutChanged;
        public event EventHandler InputFillChanged;
        public event EventHandler MaskBottomChanged;
        public event EventHandler MaskedChanged;
        public event EventHandler MaskLeftChanged;
        public event EventHandler MaskRightChanged;
        public event EventHandler MaskTopChanged;
        public event EventHandler OnAirChanged;
        public event EventHandler TypeChanged;
        void IBMDSwitcherKeyCallback.Notify(_BMDSwitcherKeyEventType eventType)
        {
            //Switch the event type
            switch (eventType)
            {
                case _BMDSwitcherKeyEventType.bmdSwitcherKeyEventTypeCanBeDVEKeyChanged:
                    if (CanBeDVEKeyChanged != null)
                    {
                        Console.sendVerbose("Clip Changed Has Changed On Upstream Keyer " + _id + " (" + _number + ")");
                        CanBeDVEKeyChanged(this, null);
                    }
                    break;

                case _BMDSwitcherKeyEventType.bmdSwitcherKeyEventTypeInputCutChanged:
                    if (InputCutChanged != null)
                    {
                        Console.sendVerbose("Input Cut Has Changed On Upstream Keyer " + _id + " (" + _number + ")");
                        InputCutChanged(this, null);
                    }
                    break;

                case _BMDSwitcherKeyEventType.bmdSwitcherKeyEventTypeInputFillChanged:
                    if (InputFillChanged != null)
                    {
                        Console.sendVerbose("Input Filled Has Changed On Upstream Keyer " + _id + " (" + _number + ")");
                        InputFillChanged(this, null);
                    }
                    break;

                case _BMDSwitcherKeyEventType.bmdSwitcherKeyEventTypeMaskBottomChanged:
                    if (MaskBottomChanged != null)
                    {
                        Console.sendVerbose("Mask Bottom Has Changed On Upstream Keyer " + _id + " (" + _number + ")");
                        MaskBottomChanged(this, null);
                    }
                    break;

                case _BMDSwitcherKeyEventType.bmdSwitcherKeyEventTypeMaskedChanged:
                    if (MaskedChanged != null)
                    {
                        Console.sendVerbose("Masked Has Changed On Upstream Keyer " + _id + " (" + _number + ")");
                        MaskedChanged(this, null);
                    }
                    break;

                case _BMDSwitcherKeyEventType.bmdSwitcherKeyEventTypeMaskLeftChanged:
                    if (MaskLeftChanged != null)
                    {
                        Console.sendVerbose("Mask Left Has Changed On Upstream Keyer " + _id + " (" + _number + ")");
                        MaskLeftChanged(this, null);
                    }
                    break;

                case _BMDSwitcherKeyEventType.bmdSwitcherKeyEventTypeMaskRightChanged:
                    if (MaskRightChanged != null)
                    {
                        Console.sendVerbose("Mask Right Has Changed On Upstream Keyer " + _id + " (" + _number + ")");
                        MaskRightChanged(this, null);
                    }
                    break;

                case _BMDSwitcherKeyEventType.bmdSwitcherKeyEventTypeMaskTopChanged:
                    if (MaskTopChanged != null)
                    {
                        Console.sendVerbose("Mask Top Has Changed On Upstream Keyer " + _id + " (" + _number + ")");
                        MaskTopChanged(this, null);
                    }
                    break;

                case _BMDSwitcherKeyEventType.bmdSwitcherKeyEventTypeOnAirChanged:
                    if (OnAirChanged != null)
                    {
                        Console.sendVerbose("On Air Has Changed On Upstream Keyer " + _id + " (" + _number + ")");
                        OnAirChanged(this, null);
                    }
                    break;

                case _BMDSwitcherKeyEventType.bmdSwitcherKeyEventTypeTypeChanged:
                    if (TypeChanged != null)
                    {
                        Console.sendVerbose("Type Has Changed On Upstream Keyer " + _id + " (" + _number + ")");
                        TypeChanged(this, null);
                    }
                    break;
            }
        }
    }
}
