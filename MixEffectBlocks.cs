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
        DebugConsole Console;
        List<SwitcherInput> _inputs;
        List<MixEffectBlock> _mixEffectBlocks;

        //Properties
        public List<MixEffectBlock> meBlocks { get { return _mixEffectBlocks; } }

        //Constructor
        public MixEffectBlocks(ref DebugConsole debugConsole)
        {
            Console = debugConsole;
            _mixEffectBlocks = new List<MixEffectBlock> { };
            Console.sendVerbose("Created MixEffectBlocks Object");
        }

        //Change Program
        public Boolean ChangeProgram(int meId, Input input)
        {
            return _mixEffectBlocks[meId - 1].ChangeProgram(input);
        }

        //Change Preview
        public Boolean ChangePreview(int meId, Input input)
        {
            return _mixEffectBlocks[meId - 1].ChangePreview(input);
        }

        //Discover the mixeffectblocks
        public ATEM_VisionSwitcher.Status Discover(ref IBMDSwitcher switcher, List<SwitcherInput> inputs)
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
