using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BMDSwitcherAPI;

namespace ATEMVisionSwitcher
{
    class UpstreamKeyer
    {
        DebugConsole Console;
        IBMDSwitcherKey _object;
        UpstreamKeyerMonitor _monitor;
        long _number;
        String _id;

        //Properties
        public long Number { get { return _number; } }
        public String Id { get { return _id; } }
        public IBMDSwitcherKey Object { get { return _object; } }
        public UpstreamKeyerMonitor Monitor { get { return _monitor; } }
        public bool CanBeDVEPool { get { int value; _object.CanBeDVEKey(out value); return value == 1; } }
        public _BMDSwitcherInputAvailability CutInputAvailabilityMask { get { _BMDSwitcherInputAvailability value; _object.GetCutInputAvailabilityMask(out value); return value; } }
        public _BMDSwitcherInputAvailability FillInputAvailabilityMask { get { _BMDSwitcherInputAvailability value; _object.GetFillInputAvailabilityMask(out value); return value; } }
        public int HashCode { get { return _object.GetHashCode(); } }
        public long InputCut { get { long value; _object.GetInputCut(out value); return value; } }
        public long InputFill { get { long value; _object.GetInputFill(out value); return value; } }
        public double MaskBottom { get { double value; _object.GetMaskBottom(out value); return value; } }
        public Boolean Masked { get { int value; _object.GetMasked(out value); return value == 1; } }
        public double MaskLeft { get { double value; _object.GetMaskLeft(out value); return value; } }
        public double MaskRight { get { double value; _object.GetMaskRight(out value); return value; } }
        public double MaskTop { get { double value; _object.GetMaskTop(out value); return value; } }
        public _BMDSwitcherTransitionSelection TransitionSelectionMask { get { _BMDSwitcherTransitionSelection value; _object.GetTransitionSelectionMask(out value); return value; } }
        public _BMDSwitcherKeyType Type { get { _BMDSwitcherKeyType value; _object.GetType(out value); return value; } }
        public _BMDSwitcherKeyType ResetMask { get { _BMDSwitcherKeyType value; _object.GetType(out value); return value; } }

        //Constructor
        public UpstreamKeyer(DebugConsole console, IBMDSwitcherKey keyer, long number, String id = "Not Set")
        {
            Console = console;
            _object = keyer;
            _number = number;
            _id = id;

   
            _object.SetMaskLeft;
            _object.SetMaskRight;
            _object.SetMaskTop;
            _object.SetOnAir;
            _object.SetType;



            //Add the monitors to the callback
            _monitor = new UpstreamKeyerMonitor(Console, id, number);
            _object.AddCallback(_monitor);

            Console.sendWarning("Upstream Keyer Does Not Contain All Methods");
        }

        public Boolean SetInputCut(long value) { try { _object.SetInputCut(value); return true; } catch (Exception e) { Console.sendError("Could Not Set Input Cut To Upstream Keyer " + _id + " (" + _number + ")\nMore Information:\n" + e); return false; } }
        public Boolean SetInputFill(long value) { try { _object.SetInputFill(value); return true; } catch (Exception e) { Console.sendError("Could Not Set Input Fill To Upstream Keyer " + _id + " (" + _number + ")\nMore Information:\n" + e); return false; } }
        public Boolean SetMaskBottom(long value) { try { _object.SetMaskBottom(value); return true; } catch (Exception e) { Console.sendError("Could Not Set Mask Bottom To Upstream Keyer " + _id + " (" + _number + ")\nMore Information:\n" + e); return false; } }
        public Boolean SetMasked(int value) { try { _object.SetMasked(value); return true; } catch (Exception e) { Console.sendError("Could Not Set Masked To Upstream Keyer " + _id + " (" + _number + ")\nMore Information:\n" + e); return false; } }



        //Set the keyers state to on air
        public Boolean SetOnAir(Boolean value = true)
        {
            try
            {
                _object.SetOnAir(Convert.ToInt16(value));
                return true;
            }
            catch (Exception e) { Console.sendError(" Could Not Set Upstream Keyer " + _id + " On Air To " + value + "\nMore Information:\n" + e); }
            return false;
        }

        //Update the keyers id
        public void SetId(String id)
        {
            if (id != null) { _id = id; }
            else { Console.sendWarning("Could Not Set Id To Upstream Keyer " + _number + " Because The Id Was Null"); }
        }
    }
}
