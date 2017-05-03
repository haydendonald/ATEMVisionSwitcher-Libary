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
        private String _longName;
        private String _shortName;
        private long _id;

        //Properties
        public SwitcherInputMonitor Monitor { get { return _monitor; } }

        public _BMDSwitcherExternalPortType AvailableExternalPortTypes
        {
            get
            {
                _BMDSwitcherExternalPortType value = new _BMDSwitcherExternalPortType();
                try
                {
                    _object.GetAvailableExternalPortTypes(out value);
                    Console.sendVerbose("Got AvailableExternalPortTypes From SwitcherInput " + _longName + " (" + _id + ") = " + value);
                    return value;
                }
                catch (Exception e) { Console.sendError("Could Not Get AvailableExternalPortTypes From SwitcherInput " + _longName + " (" + _id + ")\nMore Information:\n" + e); return value; }
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
                    Console.sendVerbose("Got AvailableExternalPortTypes From SwitcherInput " + _longName + " (" + _id + ") = " + value);
                    return value;
                }
                catch (Exception e) { Console.sendError("Could Not Get AvailableExternalPortTypes From SwitcherInput " + _longName + " (" + _id + ")\nMore Information:\n" + e); return value; }
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
                    Console.sendVerbose("Got InputAvailability From SwitcherInput " + _longName + " (" + _id + ") = " + value);
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
                    _id = value;
                    Console.sendVerbose("Got InputId From SwitcherInput " + _longName + " = " + _id);
                    return _id;
                }
                catch (Exception e) { Console.sendError("Could Not Get InputId From SwitcherInput" + _longName + "\nMore Information:\n" + e); return value; }
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
                    _shortName = value;
                    Console.sendVerbose("Got ShortName From SwitcherInput " + _longName + " (" + _id + ") = " + _shortName);
                    return _shortName;
                }
                catch (Exception e) { Console.sendError("Could Not Get ShortName From SwitcherInput " + _longName + " (" + _id + ")\nMore Information:\n" + e); return value; }
            }
            set
            {
                try
                {
                    _object.SetShortName(value);
                    _shortName = value;
                    Console.sendVerbose("Set ShortName On SwitcherInput" + LongName + " (" + Id + ") To " + value);
                }
                catch (Exception e) { Console.sendError("Could Not Set ShortName On SwitcherInput " + _longName + " (" + _id + ") To " + value + "\nMore Information:\n" + e); }
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
                    _longName = value;
                    Console.sendVerbose("Got LongName From SwitcherInput " + _longName + " (" + _id + ") = " + _longName);
                    return _longName;
                }
                catch (Exception e) { Console.sendError("Could Not Get LongName From SwitcherInput " + _longName + " (" + _id + ")\nMore Information:\n" + e); return value; }
            }
            set
            {
                try
                {
                    _object.SetLongName(value);
                    _longName = value;
                    Console.sendVerbose("Set LongName On SwitcherInput (" + Id + ") To " + value);
                }
                catch (Exception e) { Console.sendError("Could Not Set LongName On SwitcherInput " + _longName + " (" + _id + ") To " + value + "\nMore Information:\n" + e); }
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
                    Console.sendVerbose("Got PortType From SwitcherInput " + _longName + " (" + _id + ") = " + value);
                    return value;
                }
                catch (Exception e) { Console.sendError("Could Not Get PortType From SwitcherInput " + _longName + " (" + _id + ")\nMore Information:\n" + e); return value; }
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
                    Console.sendVerbose("Got PreviewTallied From SwitcherInput " + _longName + " (" + _id + ") = " + value);
                    return value == 1;
                }
                catch (Exception e) { Console.sendError("Could Not Get PreviewTallied From SwitcherInput " + _longName + " (" + _id + ")\nMore Information:\n" + e); return value == 1; }
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
                    Console.sendVerbose("Got ProgramTallied From SwitcherInput " + _longName + " (" + _id + ") = " + value);
                    return value == 1;
                }
                catch (Exception e) { Console.sendError("Could Not Get ProgramTallied From SwitcherInput " + _longName + " (" + _id + ")\nMore Information:\n" + e); return value == 1; }
            }
        }

        //Constructor
        public SwitcherInput(DebugConsole console, IBMDSwitcherInput input)
        {
            Console = console;
            _object = input;
            _shortName = LongName;
            _longName = ShortName;

            Console.sendVerbose("Created Input Object For Input " + _longName + "(" + _id + ")");
        }

        //Reset Names
        public Boolean ResetNames()
        {
            try
            {
                _object.ResetNames();
                _longName = "";
                _shortName = "";
                Console.sendVerbose("ResetNames On SwitcherInput " + _longName + " (" + _id + ")");
                return true;
            }
            catch (Exception e) { Console.sendError("Could Not ResetNames On SwitcherInput " + _longName + " (" + _id + ")\nMore Information:\n" + e); return false; }
        }

        //Release
        public Boolean Release()
        {
            try
            {
                _object.RemoveCallback(_monitor);
                _monitor = new SwitcherInputMonitor(Console, _longName, _id);
                _object = null;
                Console.sendVerbose("Released SwitcherInput " + _longName + " (" + ")" + _id);
                return true;
            }
            catch (Exception e) { Console.sendError("Could Not Release SwitcherInput " + _longName + " (" + ")" + _id + "\nMore Information:\n" + e); return false; }
        }
    }
}
