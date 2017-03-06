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
                    Console.sendVerbose("Got InputSource From AuxInput " + LongName + " (" + Id + ") = " + value);
                    return value;
                }
                catch (Exception e) { Console.sendError("Could Not Get InputSource From AuxInput " + LongName + " (" + Id + ")\nMore Information:\n" + e); return value; }
            }
            set
            {
                try
                {
                    _object.SetInputSource(value);
                    Console.sendVerbose("Set InputSource On AuxInput" + LongName + " (" + Id + ") To " + value);
                }
                catch (Exception e) { Console.sendError("Could Not Set InputSource On AuxInput " + LongName + " (" + Id + ") To " + value + "\nMore Information:\n" + e); }
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
                    Console.sendVerbose("Got InputAvailabilityMask From AuxInput " + LongName + " (" + Id + ") = " + value);
                    return value;
                }
                catch (Exception e) { Console.sendError("Could Not Get InputAvailabilityMask From AuxInput " + LongName + " (" + Id + ")\nMore Information:\n" + e); return value; }
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
                    Console.sendVerbose("Got ShortName From SwitcherInput " + LongName + " (" + Id + ") = " + value);
                    return value;
                }
                catch (Exception e) { Console.sendError("Could Not Get ShortName From SwitcherInput " + LongName + " (" + Id + ")\nMore Information:\n" + e); return value; }
            }
            set
            {
                try
                {
                    ((IBMDSwitcherInput)_object).SetShortName(value);
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
                    ((IBMDSwitcherInput)_object).GetLongName(out value);
                    Console.sendVerbose("Got LongName From SwitcherInput " + LongName + " (" + Id + ") = " + value);
                    return value;
                }
                catch (Exception e) { Console.sendError("Could Not Get LongName From SwitcherInput " + LongName + " (" + Id + ")\nMore Information:\n" + e); return value; }
            }
            set
            {
                try
                {
                    ((IBMDSwitcherInput)_object).SetLongName(value);
                    Console.sendVerbose("Set LongName On SwitcherInput" + LongName + " (" + Id + ") To " + value);
                }
                catch (Exception e) { Console.sendError("Could Not Set LongName On SwitcherInput " + LongName + " (" + Id + ") To " + value + "\nMore Information:\n" + e); }
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
                    Console.sendVerbose("Got InputId From SwitcherInput " + LongName + " (" + Id + ") = " + value);
                    return value;
                }
                catch (Exception e) { Console.sendError("Could Not Get InputId From SwitcherInput " + LongName + " (" + Id + ")\nMore Information:\n" + e); return value; }
            }
        }

        //Constructor
        public AuxInput(DebugConsole console, IBMDSwitcherInputAux input)
        {
            Console = console;
            _monitor = new AuxInputMonitor(Console, LongName, Id);
            _object = input;

            Console.sendVerbose("Created Aux Input Object For Input " + LongName + "(" + Id + ")");
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
