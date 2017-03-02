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
        public bool isOnAir
        {
            get
            {
                int state = 0;
                _object.GetOnAir(out state);
                return (state == 1);
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
            _monitor = new UpstreamKeyerMonitor();
            _object.AddCallback(_monitor);

            Console.sendWarning("Upstream Keyer Does Not Contain All Methods");
        }

        //Deconstructor
        ~UpstreamKeyer()
        {
            try
            {
                _object.RemoveCallback(_monitor);
                _monitor = new UpstreamKeyerMonitor();
                _object = null;
            }
            catch(Exception e) { Console.sendError("Could Not Release Upstream Keyer " + Id + "\nMore Information:\n" + e); }
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

        //Update the keyers id
        public void SetId(String id)
        {
            if (id != null) { _id = id; }
            else { Console.sendWarning("Could Not Set Id To Upstream Keyer " + _number + " Because The Id Was Null"); }
        }
    }
}
