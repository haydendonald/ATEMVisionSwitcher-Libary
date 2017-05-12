using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using BMDSwitcherAPI;

namespace ATEMVisionSwitcher
{
    public class MixEffectBlocks
    {
        private DebugConsole Console;
        private List<MixEffectBlock> _mixEffectBlocks;

        //Properties
        public List<MixEffectBlock> meBlocks { get { return _mixEffectBlocks; } }

        //Constructor
        public MixEffectBlocks(DebugConsole debugConsole)
        {
            Console = debugConsole;
            _mixEffectBlocks = new List<MixEffectBlock> { };
            Console.sendVerbose("Created MixEffectBlocks Object");
        }
        public MixEffectBlocks(DebugConsole debugConsole, List<MixEffectBlock> mixEffectBlocks)
        {
            Console = debugConsole;
            _mixEffectBlocks = mixEffectBlocks;
            Console.sendVerbose("Created MixEffectBlocks Object");
        }
        public MixEffectBlocks(DebugConsole debugConsole, MixEffectBlock mixEffectBlock)
        {
            Console = debugConsole;
            _mixEffectBlocks = new List<MixEffectBlock> { mixEffectBlock };
            Console.sendVerbose("Created MixEffectBlocks Object");
        }

        //Change Program
        public void ChangeProgram(int meId, Input input)
        {
            _mixEffectBlocks[meId - 1].ChangeProgram(input);
        }

        //Change Preview
        public void ChangePreview(int meId, Input input)
        {
            _mixEffectBlocks[meId - 1].ChangePreview(input);
        }

        //Perform auto transition
        public void PerformAutoTransition()
        {
            foreach (MixEffectBlock i in _mixEffectBlocks) { i.PerformAutoTransition(); }
        }

        //Perform auto transition
        public void PerformCut()
        {
            foreach (MixEffectBlock i in _mixEffectBlocks) { i.PerformCut(); }
        }

        //Perform auto transition
        public void PerformFadeToBlack()
        {
            foreach (MixEffectBlock i in _mixEffectBlocks) { i.PerformFadeToBlack(); }
        }

        //Find a mix effect block
        public MixEffectBlock GetMixEffectBlock(String meID)
        {
            foreach(MixEffectBlock i in _mixEffectBlocks)
            {
                if(i.Id == meID) { return i; }
            }

            return null;
        }

        //Find a mix effect block
        public MixEffectBlock GetMixEffectBlock(long meNumber)
        {
            foreach (MixEffectBlock i in _mixEffectBlocks)
            {
                if (i.Number == meNumber) { return i; }
            }

            return null;
        }

        //Check if a program input is active
        public Boolean ProgramInputActive(Input input, List<MixEffectBlock> meBlocks = null)
        {
            if(meBlocks == null) { meBlocks = _mixEffectBlocks; }
            foreach (MixEffectBlock i in meBlocks) { if (i.ProgramInput != input) { return false; } }
            return true;
        }
        public Boolean ProgramInputActive(Input input, MixEffectBlock meBlock)
        {
            return meBlock.ProgramInput == input;
        }

        //Check if an input is active
        public Boolean PreviewInputActive(Input input, List<MixEffectBlock> meBlocks = null)
        {
            if (meBlocks == null) { meBlocks = _mixEffectBlocks; }
            foreach (MixEffectBlock i in meBlocks) { if (i.PreviewInput != input) { return false; } }
            return true;
        }
        public Boolean PreviewInputActive(Input input, MixEffectBlock meBlock)
        {
            return meBlock.PreviewInput == input;
        }

        //Discover the mixeffectblocks
        public ATEM_VisionSwitcher.Status Discover(IBMDSwitcher switcher, Inputs inputs)
        {
            Console.sendVerbose("Attempting To Find The Mix Effect Blocks");

            //Create the iterator
            IBMDSwitcherMixEffectBlockIterator iterator = null;
            IntPtr iteratorPtr;
            Guid iteratorIID = typeof(IBMDSwitcherMixEffectBlockIterator).GUID;
            switcher.CreateIterator(iteratorIID, out iteratorPtr);
            if (iteratorPtr != null) { iterator = (IBMDSwitcherMixEffectBlockIterator)Marshal.GetObjectForIUnknown(iteratorPtr); }

            //Check the iterator 
            if (iterator == null) { Console.sendError("Mix Effect Block Iterator Is Null"); return ATEM_VisionSwitcher.Status.MixEffectBlockDiscoverFailed; }

            //Get the mix effect blocks
            for (int i = 0; true; i++)
            {
                IBMDSwitcherMixEffectBlock tempMixEffectBlock;
                iterator.Next(out tempMixEffectBlock);
                if (tempMixEffectBlock == null) { break; }
                Console.sendVerbose("Found Mix Effect Block " + i);

                _mixEffectBlocks.Add(new MixEffectBlock(Console, tempMixEffectBlock, inputs, i));
                if (_mixEffectBlocks[i] == null) { Console.sendError("Mix Effect Block " + i + " Is Null"); return ATEM_VisionSwitcher.Status.MixEffectBlockDiscoverFailed; }
            }

            Console.sendVerbose("Successfully Discovered The Mix Effect Block(s)");

            Console.sendInfo("Found " + _mixEffectBlocks.Count + " Mix Effect Blocks");
            foreach(MixEffectBlock i in _mixEffectBlocks) { Console.sendTabInfo("ID: " + i.Id + "(" + i.Number + ")"); }

            return ATEM_VisionSwitcher.Status.Success;
        }
    }
}
