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
    public class SwitcherInput : Input
    {
        private IBMDSwitcherInput _object;
        private SwitcherInputMonitor _monitor;
        private DebugConsole Console;

        //Properties
        public _BMDSwitcherExternalPortType AvailableExternalPortTypes
        {
            get
            {
                _BMDSwitcherExternalPortType value = new _BMDSwitcherExternalPortType();
                try
                {
                    _object.GetAvailableExternalPortTypes(out value);
                    Console.sendVerbose("Got AvailableExternalPortTypes From SwitcherInput " + LongName + " (" + Id + ") = " + value);
                    return value;
                }
                catch (Exception e) { Console.sendError("Could Not Get AvailableExternalPortTypes From SwitcherInput " + LongName + " (" + Id + ")\nMore Information:\n" + e); return value; }
            }
        }
        public _BMDSwitcherExternalPortType CurrentExternalPortType
        {
            get
            {
                _BMDSwitcherExternalPortType value = new _BMDSwitcherExternalPortType();
                try
                {
                    _object.GetCurrentExternalPortType(out value);
                    Console.sendVerbose("Got AvailableExternalPortTypes From SwitcherInput " + LongName + " (" + Id + ") = " + value);
                    return value;
                }
                catch (Exception e) { Console.sendError("Could Not Get AvailableExternalPortTypes From SwitcherInput " + LongName + " (" + Id + ")\nMore Information:\n" + e); return value; }
            }
            set
            {
                try
                {
                    _object.SetCurrentExternalPortType(value);
                    Console.sendVerbose("Set AvailableExternalPortTypes On SwitcherInput" + LongName + " (" + Id + ") To " + value);
                }
                catch (Exception e) { Console.sendError("Could Not Set AvailableExternalPortTypes On SwitcherInput " + LongName + " (" + Id + ") To " + value + "\nMore Information:\n" + e); }
            }
        }
        public _BMDSwitcherInputAvailability InputAvailability
        {
            get
            {
                _BMDSwitcherInputAvailability value = new _BMDSwitcherInputAvailability();
                try
                {
                    _object.GetInputAvailability(out value);
                    Console.sendVerbose("Got InputAvailability From SwitcherInput " + LongName + " (" + Id + ") = " + value);
                    return value;
                }
                catch (Exception e) { Console.sendError("Could Not Get InputAvailability From SwitcherInput " + LongName + " (" + Id + ")\nMore Information:\n" + e); return value; }
            }
        }
        public long Id
        {
            get
            {
                long value = -1;
                try
                {
                    _object.GetInputId(out value);
                    Console.sendVerbose("Got InputId From SwitcherInput " + LongName + " (" + Id + ") = " + value);
                    return value;
                }
                catch (Exception e) { Console.sendError("Could Not Get InputId From SwitcherInput " + LongName + " (" + Id + ")\nMore Information:\n" + e); return value; }
            }
        }
        public String ShortName
        {
            get
            {
                String value = "Invalid";
                try
                {
                    _object.GetShortName(out value);
                    Console.sendVerbose("Got ShortName From SwitcherInput " + LongName + " (" + Id + ") = " + value);
                    return value;
                }
                catch (Exception e) { Console.sendError("Could Not Get ShortName From SwitcherInput " + LongName + " (" + Id + ")\nMore Information:\n" + e); return value; }
            }
            set
            {
                try
                {
                    _object.SetShortName(value);
                    Console.sendVerbose("Set ShortName On SwitcherInput" + LongName + " (" + Id + ") To " + value);
                }
                catch (Exception e) { Console.sendError("Could Not Set ShortName On SwitcherInput " + LongName + " (" + Id + ") To " + value + "\nMore Information:\n" + e); }
            }
        }
        public String LongName
        {
            get
            {
                String value = "Invalid";
                try
                {
                    _object.GetLongName(out value);
                    Console.sendVerbose("Got LongName From SwitcherInput " + LongName + " (" + Id + ") = " + value);
                    return value;
                }
                catch (Exception e) { Console.sendError("Could Not Get LongName From SwitcherInput " + LongName + " (" + Id + ")\nMore Information:\n" + e); return value; }
            }
            set
            {
                try
                {
                    _object.SetLongName(value);
                    Console.sendVerbose("Set LongName On SwitcherInput" + LongName + " (" + Id + ") To " + value);
                }
                catch (Exception e) { Console.sendError("Could Not Set LongName On SwitcherInput " + LongName + " (" + Id + ") To " + value + "\nMore Information:\n" + e); }
            }
        }
        public _BMDSwitcherPortType PortType
        {
            get
            {
                _BMDSwitcherPortType value = new _BMDSwitcherPortType();
                try
                {
                    _object.GetPortType(out value);
                    Console.sendVerbose("Got PortType From SwitcherInput " + LongName + " (" + Id + ") = " + value);
                    return value;
                }
                catch (Exception e) { Console.sendError("Could Not Get PortType From SwitcherInput " + LongName + " (" + Id + ")\nMore Information:\n" + e); return value; }
            }
        }
        public Boolean PreviewTallied
        {
            get
            {
                int value = 0;
                try
                {
                    _object.IsPreviewTallied(out value);
                    Console.sendVerbose("Got PreviewTallied From SwitcherInput " + LongName + " (" + Id + ") = " + value);
                    return value == 1;
                }
                catch (Exception e) { Console.sendError("Could Not Get PreviewTallied From SwitcherInput " + LongName + " (" + Id + ")\nMore Information:\n" + e); return value == 1; }
            }
        }
        public Boolean ProgramTallied
        {
            get
            {
                int value = 0;
                try
                {
                    _object.IsProgramTallied(out value);
                    Console.sendVerbose("Got ProgramTallied From SwitcherInput " + LongName + " (" + Id + ") = " + value);
                    return value == 1;
                }
                catch (Exception e) { Console.sendError("Could Not Get ProgramTallied From SwitcherInput " + LongName + " (" + Id + ")\nMore Information:\n" + e); return value == 1; }
            }
        }

        //Constructor
        public SwitcherInput(DebugConsole console, IBMDSwitcherInput input)
        {
            Console = console;
            _object = input;

            Console.sendVerbose("Created Input Object For Input " + LongName + "(" + Id + ")");
        }

        //Reset Names
        public Boolean ResetNames()
        {
            try
            {
                _object.ResetNames();
                Console.sendVerbose("ResetNames On SwitcherInput " + LongName + " (" + Id + ")");
                return true;
            }
            catch (Exception e) { Console.sendError("Could Not ResetNames On SwitcherInput " + LongName + " (" + Id + ")\nMore Information:\n" + e); return false; }
        }

        //Release
        public Boolean Release()
        {
            try
            {
                _object.RemoveCallback(_monitor);
                _monitor = new SwitcherInputMonitor(Console, LongName, Id);
                _object = null;
                Console.sendVerbose("Released SwitcherInput " + LongName + " (" + ")" + Id);
                return true;
            }
            catch (Exception e) { Console.sendError("Could Not Release SwitcherInput " + LongName + " (" + ")" + Id + "\nMore Information:\n" + e); return false; }
        }
    }
}
