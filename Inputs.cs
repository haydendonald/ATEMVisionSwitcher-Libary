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

        #region Global Properties

        public List<SwitcherInput> SwitcherInputs { get { return _switcherInputs; } }
        public List<AuxInput> AuxInputs { get { return _auxInputs; } }

        //Id
        public long GetId(Input input) { return input.Id; }
        public List<long> GetId(List<SwitcherInput> inputs)
        {
            List<long> returnList = new List<long> { };
            foreach (Input i in inputs) { returnList.Add(i.Id); }
            return returnList;
        }

        //LongName
        public String GetLongName(Input input) { return input.LongName; }
        public List<String> GetLongName(List<Input> inputs)
        {
            List<String> returnList = new List<String> { };
            foreach (Input i in inputs) { returnList.Add(i.LongName); }
            return returnList;
        }
        public void SetCurrentExternalPortType(Input input, String value) { input.LongName = value; }
        public void SetCurrentExternalPortType(List<Input> inputs, String value) { foreach (Input i in inputs) { i.LongName = value; } }


        //ShortName
        public String GetShortName(Input input) { return input.ShortName; }
        public List<String> GetShortName(List<Input> inputs)
        {
            List<String> returnList = new List<String> { };
            foreach (Input i in inputs) { returnList.Add(i.ShortName); }
            return returnList;
        }
        public void SetShortName(Input input, String value) { input.ShortName = value; }
        public void SetShortName(List<Input> inputs, String value) { foreach (Input i in inputs) { i.ShortName = value; } }

        #endregion

        #region SwitcherInput Properties

        //AvailableExternalPortTypes
        public _BMDSwitcherExternalPortType GetAvailableExternalPortTypes(SwitcherInput input) { return input.AvailableExternalPortTypes; }
        public List<_BMDSwitcherExternalPortType> GetAvailableExternalPortTypes(List<SwitcherInput> inputs)
        {
            List<_BMDSwitcherExternalPortType> returnList = new List<_BMDSwitcherExternalPortType> { };
            foreach (SwitcherInput i in inputs) { returnList.Add(i.AvailableExternalPortTypes); }
            return returnList;
        }

        //CurrentExternalPortType
        public _BMDSwitcherExternalPortType GetCurrentExternalPortType(SwitcherInput input) { return input.CurrentExternalPortType; }
        public List<_BMDSwitcherExternalPortType> GetCurrentExternalPortType(List<SwitcherInput> inputs)
        {
            List<_BMDSwitcherExternalPortType> returnList = new List<_BMDSwitcherExternalPortType> { };
            foreach (SwitcherInput i in inputs) { returnList.Add(i.CurrentExternalPortType); }
            return returnList;
        }
        public void SetCurrentExternalPortType(SwitcherInput input, _BMDSwitcherExternalPortType value) { input.CurrentExternalPortType = value; }
        public void SetCurrentExternalPortType(List<SwitcherInput> inputs, _BMDSwitcherExternalPortType value) { foreach (SwitcherInput i in inputs) { i.CurrentExternalPortType = value; } }

        //InputAvailability
        public _BMDSwitcherInputAvailability GetInputAvailability(SwitcherInput input) { return input.InputAvailability; }
        public List<_BMDSwitcherInputAvailability> GetInputAvailability(List<SwitcherInput> inputs)
        {
            List<_BMDSwitcherInputAvailability> returnList = new List<_BMDSwitcherInputAvailability> { };
            foreach (SwitcherInput i in inputs) { returnList.Add(i.InputAvailability); }
            return returnList;
        }

        //PortType
        public _BMDSwitcherPortType GetPortType(SwitcherInput input) { return input.PortType; }
        public List<_BMDSwitcherPortType> GetPortType(List<SwitcherInput> inputs)
        {
            List<_BMDSwitcherPortType> returnList = new List<_BMDSwitcherPortType> { };
            foreach (SwitcherInput i in inputs) { returnList.Add(i.PortType); }
            return returnList;
        }

        //PreviewTallied
        public Boolean GetPreviewTallied(SwitcherInput input) { return input.PreviewTallied; }
        public List<Boolean> GetPreviewTallied(List<SwitcherInput> inputs)
        {
            List<Boolean> returnList = new List<Boolean> { };
            foreach (SwitcherInput i in inputs) { returnList.Add(i.PreviewTallied); }
            return returnList;
        }

        //PropgramTallied
        public Boolean GetProgramTallied(SwitcherInput input) { return input.ProgramTallied; }
        public List<Boolean> GetProgramTallied(List<SwitcherInput> inputs)
        {
            List<Boolean> returnList = new List<Boolean> { };
            foreach (SwitcherInput i in inputs) { returnList.Add(i.ProgramTallied); }
            return returnList;
        }

        //ResetNames
        public Boolean ResetNames(SwitcherInput input) { return input.ResetNames(); }
        public List<Boolean> ResetNames(List<SwitcherInput> inputs)
        {
            List<Boolean> returnList = new List<Boolean> { };
            foreach (SwitcherInput i in inputs) { returnList.Add(i.ResetNames()); }
            return returnList;
        }

        #endregion

        #region AuxInput Properties

        //InputSource
        public long GetInputSource(AuxInput input) { return input.InputSource; }
        public List<long> GetInputSource(List<AuxInput> inputs)
        {
            List<long> returnList = new List<long> { };
            foreach (AuxInput i in inputs) { returnList.Add(i.InputSource); }
            return returnList;
        }
        public void SetInputSource(AuxInput input, long value) { input.InputSource = value; }
        public void SetInputSource(List<AuxInput> inputs, long value) { foreach (AuxInput i in inputs) { i.InputSource = value; } }

        //InputAvailabilityMask
        public _BMDSwitcherInputAvailability GetInputAvailabilityMask(AuxInput input) { return input.InputAvailabilityMask; }
        public List<_BMDSwitcherInputAvailability> GetInputAvailabilityMask(List<AuxInput> inputs)
        {
            List<_BMDSwitcherInputAvailability> returnList = new List<_BMDSwitcherInputAvailability> { };
            foreach (AuxInput i in inputs) { returnList.Add(i.InputAvailabilityMask); }
            return returnList;
        }

        #endregion

        public Inputs(DebugConsole debugConsole)
        {
            Console = debugConsole;
            _switcherInputs = new List<SwitcherInput> { };
            _auxInputs = new List<AuxInput> { };

            Console.sendVerbose("Created Inputs Object");
        }
        public Inputs(DebugConsole debugConsole, List<Input> inputs)
        {
            Console = debugConsole;
            _switcherInputs = new List<SwitcherInput> { };
            _auxInputs = new List<AuxInput> { };

            foreach (Input i in inputs)
            {
                if(i.GetType() == typeof(SwitcherInput)) { _switcherInputs.Add((SwitcherInput)i); }
                if (i.GetType() == typeof(AuxInput)) { _auxInputs.Add((AuxInput)i); }
            }

            Console.sendVerbose("Created Inputs Object");
        }

        //Find a switcher input
        public SwitcherInput FindSwitcherInput(long id)
        {
            foreach (SwitcherInput i in _switcherInputs) { if (i.Id == id) { return i; } }
            return null;
        }

        //Find a switcher input
        public long FindSwitcherInput(Input input)
        {
            foreach (SwitcherInput i in _switcherInputs) { if (i == input) { return i.Id; } }
            return -1;
        }

        //Find a aux input
        public AuxInput FindAuxInput(long id)
        {
            foreach (AuxInput i in _auxInputs) { if (i.Id == id) { return i; } }
            return null;
        }

        //Find a aux input
        public long FindAuxInput(Input input)
        {
            foreach (AuxInput i in _auxInputs) { if (i.Input == input) { return i.Id; } }
            return -1;
        }

        //Discover the inputs
        public ATEM_VisionSwitcher.Status Discover(IBMDSwitcher switcher)
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
                    _auxInputs.Add(new AuxInput(Console, this, (IBMDSwitcherInputAux)tempInput));

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
            try
            {
                foreach (SwitcherInput i in _switcherInputs) { i.Release(); }
                foreach (AuxInput i in _auxInputs) { i.Release(); }
                return ATEM_VisionSwitcher.Status.Success;
            }
            catch(Exception e) { Console.sendError("Could Not Release Inputs\nMore Information:\n" + e); return ATEM_VisionSwitcher.Status.InputReleaseFailed; }

        }

    }
}
