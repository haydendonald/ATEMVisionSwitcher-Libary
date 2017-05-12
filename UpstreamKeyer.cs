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
    public class UpstreamKeyer : Keyer
    {
        DebugConsole Console;
        IBMDSwitcherKey _object;
        UpstreamKeyerMonitor _monitor;
        long _number;
        String _id;

        //Properties
        public long Number { get { return _number; }}
        public String Id { get { return _id; } set { _id = value; } }
        public IBMDSwitcherKey Object { get { return _object; } }
        public UpstreamKeyerMonitor Monitor { get { return _monitor; } }
        public _BMDSwitcherInputAvailability CutInputAvailabilityMask
        {
            get
            {
                _BMDSwitcherInputAvailability value = new _BMDSwitcherInputAvailability();
                try
                {
                    _object.GetCutInputAvailabilityMask(out value);
                    Console.sendVerbose("Got CutInputAvailabilityMask From Upstream Keyer " + _id + " (" + _number + ") = " + value);
                    return value;
                }
                catch (Exception e) { Console.sendError("Could Not Get CutInputAvailabilityMask From Upstream Keyer " + _id + " (" + _number + ")\nMore Information:\n" + e); return value; }
            }
        }
        public _BMDSwitcherInputAvailability FillInputAvailabilityMask
        {
            get
            {
                _BMDSwitcherInputAvailability value = new _BMDSwitcherInputAvailability();
                try
                {
                    _object.GetFillInputAvailabilityMask(out value);
                    Console.sendVerbose("Got FillInputAvailabilityMask From Upstream Keyer " + _id + " (" + _number + ") = " + value);
                    return value;
                }
                catch (Exception e) { Console.sendError("Could Not Get FillInputAvailabilityMask From Upstream Keyer " + _id + " (" + _number + ")\nMore Information:\n" + e); return value; }
            }
        }
        public long InputCut
        {
            get
            {
                long value = -1;
                try
                {
                    _object.GetInputCut(out value);
                    Console.sendVerbose("Got InputCut From Upstream Keyer " + _id + " (" + _number + ") = " + value);
                    return value;
                }
                catch (Exception e) { Console.sendError("Could Not Get InputCut From Upstream Keyer " + _id + " (" + _number + ")\nMore Information:\n" + e); return value; }
            }
            set
            {
                try
                {
                    _object.SetInputCut(value);
                    Console.sendVerbose("Set InputCut On Upstream Keyer " + _id + " (" + _number + ") To " + value);
                }
                catch (Exception e) { Console.sendError("Could Not Set InputCut On Upstream Keyer " + _id + " (" + _number + ") To " + value + "\nMore Information:\n" + e); }
            }
        }
        public long InputFill
        {
            get
            {
                long value = -1;
                try
                {
                    _object.GetInputFill(out value);
                    Console.sendVerbose("Got InputFill From Upstream Keyer " + _id + " (" + _number + ") = " + value);
                    return value;
                }
                catch (Exception e) { Console.sendError("Could Not Get InputFill From Upstream Keyer " + _id + " (" + _number + ")\nMore Information:\n" + e); return value; }
            }
            set
            {
                try
                {
                    _object.SetInputFill(value);
                    Console.sendVerbose("Set InputFill On Upstream Keyer " + _id + " (" + _number + ") To " + value);
                }
                catch (Exception e) { Console.sendError("Could Not Set InputFill On Upstream Keyer " + _id + " (" + _number + ") To " + value + "\nMore Information:\n" + e); }
            }
        }
        public double MaskBottom
        {
            get
            {
                double value = -1;
                try
                {
                    _object.GetMaskBottom(out value);
                    Console.sendVerbose("Got MaskBottom From Upstream Keyer " + _id + " (" + _number + ") = " + value);
                    return value;
                }
                catch (Exception e) { Console.sendError("Could Not Get MaskBottom From Upstream Keyer " + _id + " (" + _number + ")\nMore Information:\n" + e); return value; }
            }
            set
            {
                try
                {
                    _object.SetMaskBottom(value);
                    Console.sendVerbose("Set MaskBottom On Upstream Keyer " + _id + " (" + _number + ") To " + value);
                }
                catch (Exception e) { Console.sendError("Could Not Set MaskBottom On Upstream Keyer " + _id + " (" + _number + ") To " + value + "\nMore Information:\n" + e); }
            }
        }
        public Boolean Masked
        {
            get
            {
                int value = -1;
                try
                {
                    _object.GetMasked(out value);
                    Console.sendVerbose("Got Masked From Upstream Keyer " + _id + " (" + _number + ") = " + value);
                    return value == 1;
                }
                catch (Exception e) { Console.sendError("Could Not Get Masked From Upstream Keyer " + _id + " (" + _number + ")\nMore Information:\n" + e); return false; }
            }
            set
            {
                try
                {
                    if (value == true) { _object.SetMasked(1); } else { _object.SetMasked(0); }
                    Console.sendVerbose("Set Masked On Upstream Keyer " + _id + " (" + _number + ") To " + value);
                }
                catch (Exception e) { Console.sendError("Could Not Set Masked On Upstream Keyer " + _id + " (" + _number + ") To " + value + "\nMore Information:\n" + e); }
            }
        }
        public double MaskLeft
        {
            get
            {
                double value = -1;
                try
                {
                    _object.GetMaskLeft(out value);
                    Console.sendVerbose("Got MaskLeft From Upstream Keyer " + _id + " (" + _number + ") = " + value);
                    return value;
                }
                catch (Exception e) { Console.sendError("Could Not Get MaskLeft From Upstream Keyer " + _id + " (" + _number + ")\nMore Information:\n" + e); return value; }
            }
            set
            {
                try
                {
                    _object.SetMaskLeft(value);
                    Console.sendVerbose("Set MaskLeft On Upstream Keyer " + _id + " (" + _number + ") To " + value);
                }
                catch (Exception e) { Console.sendError("Could Not Set MaskLeft On Upstream Keyer " + _id + " (" + _number + ") To " + value + "\nMore Information:\n" + e); }
            }
        }
        public double MaskRight
        {
            get
            {
                double value = -1;
                try
                {
                    _object.GetMaskRight(out value);
                    Console.sendVerbose("Got MaskRight From Upstream Keyer " + _id + " (" + _number + ") = " + value);
                    return value;
                }
                catch (Exception e) { Console.sendError("Could Not Get MaskRight From Upstream Keyer " + _id + " (" + _number + ")\nMore Information:\n" + e); return value; }
            }
            set
            {
                try
                {
                    _object.SetMaskRight(value);
                    Console.sendVerbose("Set MaskRight On Upstream Keyer " + _id + " (" + _number + ") To " + value);
                }
                catch (Exception e) { Console.sendError("Could Not Set MaskRight On Upstream Keyer " + _id + " (" + _number + ") To " + value + "\nMore Information:\n" + e); }
            }
        }
        public double MaskTop
        {
            get
            {
                double value = -1;
                try
                {
                    _object.GetMaskTop(out value);
                    Console.sendVerbose("Got MaskTop From Upstream Keyer " + _id + " (" + _number + ") = " + value);
                    return value;
                }
                catch (Exception e) { Console.sendError("Could Not Get MaskTop From Upstream Keyer " + _id + " (" + _number + ")\nMore Information:\n" + e); return value; }
            }
            set
            {
                try
                {
                    _object.SetMaskTop(value);
                    Console.sendVerbose("Set MaskTop On Upstream Keyer " + _id + " (" + _number + ") To " + value);
                }
                catch (Exception e) { Console.sendError("Could Not Set MaskTop On Upstream Keyer " + _id + " (" + _number + ") To " + value + "\nMore Information:\n" + e); }
            }
        }
        public Boolean CanBeDVEKey
        {
            get
            {
                int value = -1;
                try
                {
                    _object.CanBeDVEKey(out value);
                    Console.sendVerbose("Got CanBeDEVKey From Upstream Keyer " + _id + " (" + _number + ") = " + value);
                    return value == 1;
                }
                catch (Exception e) { Console.sendError("Could Not Get CanBeDEVKey From Upstream Keyer " + _id + " (" + _number + ")\nMore Information:\n" + e); return false; }
            }
        }
        public _BMDSwitcherTransitionSelection TransitionSelectionMask
        {
            get
            {
                _BMDSwitcherTransitionSelection value = new _BMDSwitcherTransitionSelection();
                try
                {
                    _object.GetTransitionSelectionMask(out value);
                    Console.sendVerbose("Got TransitionSelectionMask From Upstream Keyer " + _id + " (" + _number + ") = " + value);
                    return value;
                }
                catch (Exception e) { Console.sendError("Could Not Get TransitionSelectionMask From Upstream Keyer " + _id + " (" + _number + ")\nMore Information:\n" + e); return value; }
            }
        }
        public _BMDSwitcherKeyType Type
        {
            get
            {
                _BMDSwitcherKeyType value = new _BMDSwitcherKeyType();
                try
                {
                    _object.GetType(out value);
                    Console.sendVerbose("Got Type From Upstream Keyer " + _id + " (" + _number + ") = " + value);
                    return value;
                }
                catch (Exception e) { Console.sendError("Could Not Get Type From Upstream Keyer " + _id + " (" + _number + ")\nMore Information:\n" + e); return value; }
            }
        }
        public Boolean OnAir
        {
            get
            {
                int value = -1;
                try
                {
                    _object.GetOnAir(out value);
                    Console.sendVerbose("Got OnAir From Upstream Keyer " + _id + " (" + _number + ") = " + value);
                    return value == 1;
                }
                catch (Exception e) { Console.sendError("Could Not Get PreMultiplied From Upstream Keyer " + _id + " (" + _number + ")\nMore Information:\n" + e); return false; }
            }
            set
            {
                try
                {
                    if (value == true) { _object.SetOnAir(1); } else { _object.SetOnAir(0); }
                    Console.sendVerbose("Set OnAir On Upstream Keyer " + _id + " (" + _number + ") To " + value);
                }
                catch (Exception e) { Console.sendError("Could Not Set PreMultiplied On Upstream Keyer " + _id + " (" + _number + ") To " + value + "\nMore Information:\n" + e); }
            }
        }

        //Constructor
        public UpstreamKeyer(DebugConsole console, IBMDSwitcherKey keyer, long number, String id = "Not Set")
        {
            Console = console;
            _object = keyer;
            _number = number;
            _id = id;

            //Add the monitors to the callback
            _monitor = new UpstreamKeyerMonitor(Console, id, number);
            _object.AddCallback(_monitor);

            Console.sendVerbose("Created Upstream Keyer " + _id + " (" + _number + ")");
        }

        //Release
        public Boolean Release()
        {
            try
            {
                _object.RemoveCallback(_monitor);
                _monitor = new UpstreamKeyerMonitor(Console, _id, _number);
                _object = null;
                Console.sendVerbose("Released Upstream Keyer " + _id + " (" + ")" + _number);
                return true;
            }
            catch(Exception e) { Console.sendError("Could Not Release Upstream Keyer " + _id + " (" + ")" + _number + "\nMore Information:\n" + e); return false; }
        }

        //Set the keyer on air
        public Boolean SetOnAir()
        {
            try
            {
                OnAir = true;
                return true;
            }
            catch (Exception e)
            {
                Console.sendError("Could Not Set On Air On Upstream Keyer " + _id + " (" + _number + ")\nMore Information:\n" + e);
                return false;
            }
        }

        //Take the keyer off air
        public Boolean TakeOffAir()
        {
            try
            {
                OnAir = false;
                return true;
            }
            catch (Exception e)
            {
                Console.sendError("Could Not Take Off Air On Upstream Keyer " + _id + " (" + _number + ")\nMore Information:\n" + e);
                return false;
            }
        }

        //Return true if on air
        public Boolean IsOnAir()
        {
            return OnAir;
        }
    }
}
