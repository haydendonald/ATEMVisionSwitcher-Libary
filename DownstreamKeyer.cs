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
    public class DownstreamKeyer : Keyer
    {
        DebugConsole Console;
        IBMDSwitcherDownstreamKey _object;
        DownstreamKeyerMonitor _monitor;
        long _number;
        String _id;

        //Properties
        public long Number { get { return _number; } }
        public String Id { get { return _id; } set { _id = value; } }
        public IBMDSwitcherDownstreamKey Object { get { return _object; } }
        public DownstreamKeyerMonitor Monitor { get { return _monitor; } }

        public double Clip
        {
            get
            {
                double value = -1;
                try
                {
                    _object.GetClip(out value);
                    Console.sendVerbose("Got Clip From Downstream Keyer " + _id + " (" + _number + ") = " + value);
                    return value;
                }
                catch (Exception e) { Console.sendError("Could Not Get Clip From Downstream Keyer " + _id + " (" + _number + ")\nMore Information:\n" + e); return value; }
            }
            set
            {
                try
                {
                    _object.SetClip(value);
                    Console.sendVerbose("Set Clip On Downstream Keyer " + _id + " (" + _number + ") To " + value);
                }
                catch (Exception e) { Console.sendError("Could Not Set Clip On Downstream Keyer " + _id + " (" + _number + ") To " + value + "\nMore Information:\n" + e); }
            }
        }
        public _BMDSwitcherInputAvailability CutInputAvailabilityMask
        {
            get
            {
                _BMDSwitcherInputAvailability value = new _BMDSwitcherInputAvailability();
                try
                {
                    _object.GetCutInputAvailabilityMask(out value);
                    Console.sendVerbose("Got CutInputAvailabilityMask From Downstream Keyer " + _id + " (" + _number + ") = " + value);
                    return value;
                }
                catch (Exception e) { Console.sendError("Could Not Get CutInputAvailabilityMask From Downstream Keyer " + _id + " (" + _number + ")\nMore Information:\n" + e); return value; }
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
                    Console.sendVerbose("Got FillInputAvailabilityMask From Downstream Keyer " + _id + " (" + _number + ") = " + value);
                    return value;
                }
                catch (Exception e) { Console.sendError("Could Not Get FillInputAvailabilityMask From Downstream Keyer " + _id + " (" + _number + ")\nMore Information:\n" + e); return value; }
            }
        }
        public uint FramesRemaining
        {
            get
            {
                uint value = 0;
                try
                {
                    _object.GetFramesRemaining(out value);
                    Console.sendVerbose("Got FramesRemaining From Downstream Keyer " + _id + " (" + _number + ") = " + value);
                    return value;
                }
                catch (Exception e) { Console.sendError("Could Not Get FramesRemaining From Downstream Keyer " + _id + " (" + _number + ")\nMore Information:\n" + e); return value; }
            }
        }
        public double Gain
        {
            get
            {
                double value = -1;
                try
                {
                    _object.GetGain(out value);
                    Console.sendVerbose("Got Gain From Downstream Keyer " + _id + " (" + _number + ") = " + value);
                    return value;
                }
                catch (Exception e) { Console.sendError("Could Not Get Gain From Downstream Keyer " + _id + " (" + _number + ")\nMore Information:\n" + e); return value; }
            }
            set
            {
                try
                {
                    _object.SetGain(value);
                    Console.sendVerbose("Set Gain On Downstream Keyer " + _id + " (" + _number + ") To " + value);
                }
                catch (Exception e) { Console.sendError("Could Not Set Gain On Downstream Keyer " + _id + " (" + _number + ") To " + value + "\nMore Information:\n" + e); }
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
                    Console.sendVerbose("Got InputCut From Downstream Keyer " + _id + " (" + _number + ") = " + value);
                    return value;
                }
                catch (Exception e) { Console.sendError("Could Not Get InputCut From Downstream Keyer " + _id + " (" + _number + ")\nMore Information:\n" + e); return value; }
            }
            set
            {
                try
                {
                    _object.SetInputCut(value);
                    Console.sendVerbose("Set InputCut On Downstream Keyer " + _id + " (" + _number + ") To " + value);
                }
                catch (Exception e) { Console.sendError("Could Not Set InputCut On Downstream Keyer " + _id + " (" + _number + ") To " + value + "\nMore Information:\n" + e); }
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
                    Console.sendVerbose("Got InputFill From Downstream Keyer " + _id + " (" + _number + ") = " + value);
                    return value;
                }
                catch (Exception e) { Console.sendError("Could Not Get InputFill From Downstream Keyer " + _id + " (" + _number + ")\nMore Information:\n" + e); return value; }
            }
            set
            {
                try
                {
                    _object.SetInputFill(value);
                    Console.sendVerbose("Set InputFill On Downstream Keyer " + _id + " (" + _number + ") To " + value);
                }
                catch (Exception e) { Console.sendError("Could Not Set InputFill On Downstream Keyer " + _id + " (" + _number + ") To " + value + "\nMore Information:\n" + e); }
            }
        }
        public int Inverse
        {
            get
            {
                int value = -1;
                try
                {
                    _object.GetInverse(ref value);
                    Console.sendVerbose("Got Inverse From Downstream Keyer " + _id + " (" + _number + ") = " + value);
                    return value;
                }
                catch (Exception e) { Console.sendError("Could Not Get Inverse From Downstream Keyer " + _id + " (" + _number + ")\nMore Information:\n" + e); return value; }
            }
            set
            {
                try
                {
                    _object.SetInverse(value);
                    Console.sendVerbose("Set Inverse On Downstream Keyer " + _id + " (" + _number + ") To " + value);
                }
                catch (Exception e) { Console.sendError("Could Not Set Inverse On Downstream Keyer " + _id + " (" + _number + ") To " + value + "\nMore Information:\n" + e); }
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
                    Console.sendVerbose("Got MaskBottom From Downstream Keyer " + _id + " (" + _number + ") = " + value);
                    return value;
                }
                catch (Exception e) { Console.sendError("Could Not Get MaskBottom From Downstream Keyer " + _id + " (" + _number + ")\nMore Information:\n" + e); return value; }
            }
            set
            {
                try
                {
                    _object.SetMaskBottom(value);
                    Console.sendVerbose("Set MaskBottom On Downstream Keyer " + _id + " (" + _number + ") To " + value);
                }
                catch (Exception e) { Console.sendError("Could Not Set MaskBottom On Downstream Keyer " + _id + " (" + _number + ") To " + value + "\nMore Information:\n" + e); }
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
                    Console.sendVerbose("Got Masked From Downstream Keyer " + _id + " (" + _number + ") = " + value);
                    return value == 1;
                }
                catch (Exception e) { Console.sendError("Could Not Get Masked From Downstream Keyer " + _id + " (" + _number + ")\nMore Information:\n" + e); return false; }
            }
            set
            {
                try
                {
                    if (value == true) { _object.SetMasked(1); } else { _object.SetMasked(0); }
                    Console.sendVerbose("Set Masked On Downstream Keyer " + _id + " (" + _number + ") To " + value);
                }
                catch (Exception e) { Console.sendError("Could Not Set Masked On Downstream Keyer " + _id + " (" + _number + ") To " + value + "\nMore Information:\n" + e); }
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
                    Console.sendVerbose("Got MaskLeft From Downstream Keyer " + _id + " (" + _number + ") = " + value);
                    return value;
                }
                catch (Exception e) { Console.sendError("Could Not Get MaskLeft From Downstream Keyer " + _id + " (" + _number + ")\nMore Information:\n" + e); return value; }
            }
            set
            {
                try
                {
                    _object.SetMaskLeft(value);
                    Console.sendVerbose("Set MaskLeft On Downstream Keyer " + _id + " (" + _number + ") To " + value);
                }
                catch (Exception e) { Console.sendError("Could Not Set MaskLeft On Downstream Keyer " + _id + " (" + _number + ") To " + value + "\nMore Information:\n" + e); }
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
                    Console.sendVerbose("Got MaskRight From Downstream Keyer " + _id + " (" + _number + ") = " + value);
                    return value;
                }
                catch (Exception e) { Console.sendError("Could Not Get MaskRight From Downstream Keyer " + _id + " (" + _number + ")\nMore Information:\n" + e); return value; }
            }
            set
            {
                try
                {
                    _object.SetMaskRight(value);
                    Console.sendVerbose("Set MaskRight On Downstream Keyer " + _id + " (" + _number + ") To " + value);
                }
                catch (Exception e) { Console.sendError("Could Not Set MaskRight On Downstream Keyer " + _id + " (" + _number + ") To " + value + "\nMore Information:\n" + e); }
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
                    Console.sendVerbose("Got MaskTop From Downstream Keyer " + _id + " (" + _number + ") = " + value);
                    return value;
                }
                catch (Exception e) { Console.sendError("Could Not Get MaskTop From Downstream Keyer " + _id + " (" + _number + ")\nMore Information:\n" + e); return value; }
            }
            set
            {
                try
                {
                    _object.SetMaskTop(value);
                    Console.sendVerbose("Set MaskTop On Downstream Keyer " + _id + " (" + _number + ") To " + value);
                }
                catch (Exception e) { Console.sendError("Could Not Set MaskTop On Downstream Keyer " + _id + " (" + _number + ") To " + value + "\nMore Information:\n" + e); }
            }
        }
        public Boolean IsAutoTransitioning
        {
            get
            {
                int value = -1;
                try
                {
                    _object.IsAutoTransitioning(out value);
                    Console.sendVerbose("Got IsAutoTransitioning From Downstream Keyer " + _id + " (" + _number + ") = " + value);
                    return value == 1;
                }
                catch (Exception e) { Console.sendError("Could Not Get IsAutoTransitioning From Downstream Keyer " + _id + " (" + _number + ")\nMore Information:\n" + e); return false; }
            }
        }
        public Boolean IsTransitioning
        {
            get
            {
                int value = -1;
                try
                {
                    _object.IsTransitioning(out value);
                    Console.sendVerbose("Got IsTransitioning From Downstream Keyer " + _id + " (" + _number + ") = " + value);
                    return value == 1;
                }
                catch (Exception e) { Console.sendError("Could Not Get IsTransitioning From Downstream Keyer " + _id + " (" + _number + ")\nMore Information:\n" + e); return false; }
            }
        }
        public Boolean PreMultiplied
        {
            get
            {
                int value = -1;
                try
                {
                    _object.GetPreMultiplied(out value);
                    Console.sendVerbose("Got PreMultiplied From Downstream Keyer " + _id + " (" + _number + ") = " + value);
                    return value == 1;
                }
                catch (Exception e) { Console.sendError("Could Not Get PreMultiplied From Downstream Keyer " + _id + " (" + _number + ")\nMore Information:\n" + e); return false; }
            }
            set
            {
                try
                {
                    if (value == true) { _object.SetPreMultiplied(1); } else { _object.SetPreMultiplied(0); }
                    Console.sendVerbose("Set PreMultiplied On Downstream Keyer " + _id + " (" + _number + ") To " + value);
                }
                catch (Exception e) { Console.sendError("Could Not Set PreMultiplied On Downstream Keyer " + _id + " (" + _number + ") To " + value + "\nMore Information:\n" + e); }
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
                    Console.sendVerbose("Got OnAir From Downstream Keyer " + _id + " (" + _number + ") = " + value);
                    return value == 1;
                }
                catch (Exception e) { Console.sendError("Could Not Get PreMultiplied From Downstream Keyer " + _id + " (" + _number + ")\nMore Information:\n" + e); return false; }
            }
            set
            {
                try
                {
                    if (value == true) { _object.SetOnAir(1); } else { _object.SetOnAir(0); }
                    Console.sendVerbose("Set OnAir On Downstream Keyer " + _id + " (" + _number + ") To " + value);
                }
                catch (Exception e) { Console.sendError("Could Not Set PreMultiplied On Downstream Keyer " + _id + " (" + _number + ") To " + value + "\nMore Information:\n" + e); }
            }
        }


        //Constructor
        public DownstreamKeyer(DebugConsole console, IBMDSwitcherDownstreamKey keyer, long number, String id = "Not Set")
        {
            Console = console;
            _object = keyer;
            _number = number;
            _id = id;

            //Add the monitors to the callback
            _monitor = new DownstreamKeyerMonitor(Console, _id, _number);
            _object.AddCallback(_monitor);

            Console.sendVerbose("Created Downstream Keyer " + _id + " (" + _number + ")");
        }

        //Release
        public Boolean Release()
        {
            try
            {
                _object.RemoveCallback(_monitor);
                _monitor = new DownstreamKeyerMonitor(Console, _id, _number);
                _object = null;
                Console.sendVerbose("Released Downstream Keyer " + _id + " (" + ")" + _number);
                return true;
            }
            catch (Exception e) { Console.sendError("Could Not Release Downstream Keyer " + _id + " (" + ")" + _number + "\nMore Information:\n" + e); return false; }
        }

        //Perform an auto transition
        public Boolean PerformAutoTransition()
        {
            try
            {
                Console.sendVerbose("Performing An Auto Transition On Downstream Keyer " + _id + " (" + _number + ")");
                _object.PerformAutoTransition();
                return true;
            }
            catch (Exception e)
            {
                Console.sendError("Could Not Perform An Auto Transition On Downstream Keyer " + _id + " (" + _number + ")\nMore Information:\n" + e);
                return false;
            }
        }

        //Perform an auto transition
        public Boolean ResetMask()
        {
            try
            {
                Console.sendVerbose("Resetting Mask On Downstream Keyer " + _id + " (" + _number + ")");
                _object.ResetMask();
                return true;
            }
            catch (Exception e)
            {
                Console.sendError("Could Not Reset Mask On Downstream Keyer " + _id + " (" + _number + ")\nMore Information:\n" + e);
                return false;
            }
        }
    }
}
