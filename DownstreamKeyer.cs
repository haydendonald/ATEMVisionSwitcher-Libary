using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BMDSwitcherAPI;

namespace ATEMVisionSwitcher
{
    public class DownstreamKeyer
    {
        DebugConsole Console;
        IBMDSwitcherDownstreamKey _object;
        DownstreamKeyerMonitor _monitor;
        long _number;
        String _id;

        //Properties
        public long Number { get { return _number; } }
        public String Id { get { return _id; } }
        public IBMDSwitcherDownstreamKey Object { get { return _object; } }
        public DownstreamKeyerMonitor Monitor { get { return _monitor; } }
        public Boolean isOnAir
        {
            get
            {
                int state = 0;
                _object.GetOnAir(out state);
                return (state == 1);
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
            _monitor = new DownstreamKeyerMonitor();
            _object.AddCallback(_monitor);

            Console.sendWarning("Downstream Keyer Does Not Contain All Methods");
        }

        //Deconstructor
        ~DownstreamKeyer()
        {
            try
            {
                _object.RemoveCallback(_monitor);
                _monitor = new DownstreamKeyerMonitor();
                _object = null;
            }
            catch (Exception e) { Console.sendError("Could Not Release Downstream Keyer " + Id + "\nMore Information:\n" + e); }
        }

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

        //Update the keyers Id
        public void SetId(String id)
        {
            if (id != null) { _id = id; }
            else { Console.sendWarning("Could Not Set Id To Upstream Keyer " + _number + " Because The Id Was Null"); }
        }
    }
}
