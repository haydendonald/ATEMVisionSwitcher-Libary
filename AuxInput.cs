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
    public class AuxInput : Input
    {
        private IBMDSwitcherInputAux _object;
        private AuxInputMonitor _monitor;
        private DebugConsole Console;
        private String _longName;
        private String _shortName;
        private long _id;

        //Properties
        public IBMDSwitcherInputAux Object { get { return _object; } }
        public AuxInputMonitor Monitor { get { return _monitor; } }
        public long InputSource
        {
            get
            {
                long value = -1;
                try
                {
                    _object.GetInputSource(out value);
                    Console.sendVerbose("Got InputSource From AuxInput " + _longName + " (" + _id + ") = " + value);
                    return value;
                }
                catch (Exception e) { Console.sendError("Could Not Get InputSource From AuxInput " + _longName + " (" + _id + ")\nMore Information:\n" + e); return value; }
            }
            set
            {
                try
                {
                    _object.SetInputSource(value);
                    Console.sendVerbose("Set InputSource On AuxInput" + _longName + " (" + _id + ") To " + value);
                }
                catch (Exception e) { Console.sendError("Could Not Set InputSource On AuxInput " + _longName + " (" + _id + ") To " + value + "\nMore Information:\n" + e); }
            }
        }
        public _BMDSwitcherInputAvailability InputAvailabilityMask
        {
            get
            {
                _BMDSwitcherInputAvailability value = new _BMDSwitcherInputAvailability();
                try
                {
                    _object.GetInputAvailabilityMask(out value);
                    Console.sendVerbose("Got InputAvailabilityMask From AuxInput " + _longName + " (" + _id + ") = " + value);
                    return value;
                }
                catch (Exception e) { Console.sendError("Could Not Get InputAvailabilityMask From AuxInput " + _longName + " (" + _id + ")\nMore Information:\n" + e); return value; }
            }
        }
        public String ShortName
        {
            get
            {
                String value = "Invalid";
                try
                {
                    ((IBMDSwitcherInput)_object).GetShortName(out value);
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
                    ((IBMDSwitcherInput)_object).SetShortName(value);
                    _shortName = value;
                    Console.sendVerbose("Set ShortName On SwitcherInput" + _longName + " (" + _id + ") To " + value);
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
                    ((IBMDSwitcherInput)_object).GetLongName(out value);
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
                    ((IBMDSwitcherInput)_object).SetLongName(value);
                    _longName = value;
                    Console.sendVerbose("Set LongName On SwitcherInput" + _longName + " (" + _id + ") To " + _longName);
                }
                catch (Exception e) { Console.sendError("Could Not Set LongName On SwitcherInput " + _longName + " (" + _id + ") To " + value + "\nMore Information:\n" + e); }
            }
        }
        public long Id
        {
            get
            {
                long value = -1;
                try
                {
                    ((IBMDSwitcherInput)_object).GetInputId(out value);
                    _id = value;
                    Console.sendVerbose("Got InputId From SwitcherInput " + _longName + " (" + _id + ") = " + _id);
                    return _id;
                }
                catch (Exception e) { Console.sendError("Could Not Get InputId From SwitcherInput " + _longName + " (" + _id + ")\nMore Information:\n" + e); return value; }
            }
        }

        //Constructor
        public AuxInput(DebugConsole console, IBMDSwitcherInputAux input)
        {
            Console = console;
            _object = input;
            _monitor = new AuxInputMonitor(Console, LongName, Id);
            _shortName = ShortName;
            _longName = LongName;
            _id = Id;

            Console.sendVerbose("Created Aux Input Object For Input " + _longName + "(" + _id + ")");
        }

        //Release
        public Boolean Release()
        {
            try
            {
                _object.RemoveCallback(_monitor);
                _monitor = new AuxInputMonitor(Console, LongName, Id);
                _object = null;
                Console.sendVerbose("Released AuxInput " + LongName + " (" + ")" + Id);
                return true;
            }
            catch (Exception e) { Console.sendError("Could Not Release AuxInput " + LongName + " (" + ")" + Id + "\nMore Information:\n" + e); return false; }
        }
    }
}
