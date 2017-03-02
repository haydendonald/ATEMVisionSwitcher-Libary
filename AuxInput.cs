using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BMDSwitcherAPI;

namespace ATEMVisionSwitcher
{
    public class AuxInput : Input
    {
        private IBMDSwitcherInputAux _input;
        private DebugConsole Console;

        //Properties
        //Find an input
        public static AuxInput Find(List<AuxInput> inputs, long id)
        {
            foreach (AuxInput i in inputs)
            {
                if (i.Id == id) { return i; }
            }

            return null;
        }

        //Constructor
        public AuxInput(DebugConsole console, IBMDSwitcherInputAux input)
        {
            Console = console;
            _input = input;

            String tempShortName;
            String tempLongName;
            long tempId;
            ((IBMDSwitcherInput)_input).GetShortName(out tempShortName);
            ((IBMDSwitcherInput)_input).GetLongName(out tempLongName);
            ((IBMDSwitcherInput)_input).GetInputId(out tempId);

            ShortName = tempShortName;
            LongName = tempLongName;
            Id = tempId;

            Console.sendVerbose("Created Aux Input Object For Input " + LongName + "(" + Id + ")");
        }

        //Change the input source
        public Boolean ChangeInputSource(Input input)
        {
            try { _input.SetInputSource(input.Id); Console.sendInfo("Set Input Source Of Aux Input " + LongName + " To " + input.LongName + "(" + input.Id + ")"); return true; }
            catch (Exception e) { Console.sendError("Failed To Set Input Source On Aux Input " + LongName + "\nError Information:\n" + e); }
            return false;
        }
    }
}
