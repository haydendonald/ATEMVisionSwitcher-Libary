using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BMDSwitcherAPI;

namespace ATEMVisionSwitcher
{
     public class SwitcherInput : Input
    {
        private IBMDSwitcherInput _object;
        private DebugConsole Console;

        //Constructor
        public SwitcherInput(DebugConsole console, IBMDSwitcherInput input)
        {
            Console = console;
            _object = input;

            String tempShortName;
            String tempLongName;
            long tempId;
            _object.GetShortName(out tempShortName);
            _object.GetLongName(out tempLongName);
            _object.GetInputId(out tempId);

            ShortName = tempShortName;
            LongName = tempLongName;
            Id = tempId;

            Console.sendVerbose("Created Input Object For Input " + LongName + "(" + Id + ")");
        }

        //Update the long name for this input
        private void UpdateLongName()
        {
            String tempLongName;
            _object.GetLongName(out tempLongName);
            Console.sendInfo("Input " + Id + "'s Long Name Changed To " + LongName);
        }

        //Update the short name for this input
        private void UpdateShortName()
        {
            String tempShortName;
            _object.GetShortName(out tempShortName);
            Console.sendInfo("Input " + Id + "'s Short Name Changed To " + ShortName);
        }
    }
}
