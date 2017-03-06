/**
	ATEM Vision Switcher Libary By Hayden Donald 2017
	https://github.com/haydendonald/ATEMVisionSwitcher-Libary

	This libary is repsonsible for the interfacing with the Black Magic ATEM Vision Switcher using the given api
    found at https://www.blackmagicdesign.com/support
*/

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using BMDSwitcherAPI;

namespace ATEMVisionSwitcher
{
    public class Inputs
    {
        private DebugConsole Console;
        private List<SwitcherInput> _switcherInputs;
        private List<AuxInput> _auxInputs;

        //Properties
        public List<SwitcherInput> SwitcherInputs { get { return _switcherInputs; } }
        public List<AuxInput> AuxInputs { get { return _auxInputs; } }

        public Inputs(ref DebugConsole debugConsole)
        {
            Console = debugConsole;
            _switcherInputs = new List<SwitcherInput> { };
            _auxInputs = new List<AuxInput> { };

            Console.sendVerbose("Created Inputs Object");
        }

        //Discover the inputs
        public ATEM_VisionSwitcher.Status Discover(ref IBMDSwitcher switcher)
        {
            Console.sendVerbose("Attempting To Find Inputs");

            //Check if the iterator is valid
            IBMDSwitcherInputIterator iterator = null;
            IntPtr iteratorPtr;
            Guid iteratorIID = typeof(IBMDSwitcherInputIterator).GUID;
            switcher.CreateIterator(ref iteratorIID, out iteratorPtr);
            if (iteratorPtr != null) { iterator = (IBMDSwitcherInputIterator)Marshal.GetObjectForIUnknown(iteratorPtr); }
            if (iterator == null) { Console.sendError("Input Iterator Is Null For Input Discovery"); return ATEM_VisionSwitcher.Status.InputDiscoverFailed; }

            int switcherInputIndex = 0;
            int auxInputIndex = 0;
            while (true)
            {
                IBMDSwitcherInput tempInput;
                iterator.Next(out tempInput);
                if (tempInput == null) { break; }

                _BMDSwitcherPortType portType;
                tempInput.GetPortType(out portType);

                //If the port type is not of type aux add it to the return list
                if (portType != _BMDSwitcherPortType.bmdSwitcherPortTypeAuxOutput)
                {
                    _switcherInputs.Add(new SwitcherInput(Console, tempInput));

                    Console.sendVerbose("Found Switcher Input " + switcherInputIndex + ": " + _switcherInputs[switcherInputIndex].LongName + " [" + _switcherInputs[switcherInputIndex].Id + "]");
                    switcherInputIndex++;
                }
                else
                {
                    _auxInputs.Add(new AuxInput(Console, (IBMDSwitcherInputAux)tempInput));

                    Console.sendVerbose("Found Aux Input " + auxInputIndex + ": " + _auxInputs[auxInputIndex].LongName + " [" + _auxInputs[auxInputIndex].Id + "]");
                    auxInputIndex++;
                }
            }

            Console.sendInfo("Discovered Switcher Inputs:");
            foreach (SwitcherInput i in _switcherInputs) { Console.sendTabInfo("[" + i.Id + "] " + i.LongName); }
            Console.sendInfo("Discovered Aux Inputs:");
            foreach (AuxInput i in _auxInputs) { Console.sendTabInfo("[" + i.Id + "] " + i.LongName); }

            return ATEM_VisionSwitcher.Status.Success;
        }

        //Release the inputs
        public ATEM_VisionSwitcher.Status Release()
        {
            Console.sendInfo("Releasing Inputs");
            foreach(SwitcherInput i in _switcherInputs) { i.rel}
        }

    }
}
