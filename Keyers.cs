using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using BMDSwitcherAPI;

namespace ATEMVisionSwitcher
{
    public class Keyers
    {
        DebugConsole Console;
        List<UpstreamKeyer> _upstreamKeyers;
        List<DownstreamKeyer> _downstreamKeyers;

        public Keyers(ref DebugConsole debugConsole)
        {
            Console = debugConsole;
            _upstreamKeyers = new List<UpstreamKeyer> { };
            _downstreamKeyers = new List<DownstreamKeyer> { };
            
            Console.sendVerbose("Created Keyers Object");
        }

        //Discover the keyers
        public ATEM_VisionSwitcher.Status Discover(ref IBMDSwitcher switcher, List<MixEffectBlock> meBlocks)
        {
            //Get Downstream Keyers
            IBMDSwitcherDownstreamKeyIterator dsIterator = null;
            IntPtr dsIteratorPtr;
            Guid dsIteratorIID = typeof(IBMDSwitcherDownstreamKeyIterator).GUID;
            switcher.CreateIterator(ref dsIteratorIID, out dsIteratorPtr);
            if (dsIteratorPtr != null) { dsIterator = (IBMDSwitcherDownstreamKeyIterator)Marshal.GetObjectForIUnknown(dsIteratorPtr); }

            //Make sure that the Downstream Keyer Iterator is not null
            if (dsIterator == null) { Console.sendError("Keyer Iterator Is Null"); return ATEM_VisionSwitcher.Status.KeyerDiscoverFailed; }

            //Get the downstream keyers
            for (int i = 0; true; i++)
            {
                IBMDSwitcherDownstreamKey tempDsKeyer = null;
                dsIterator.Next(out tempDsKeyer);
                if (tempDsKeyer == null) { break; }
                Console.sendVerbose("Found Downstream Keyer " + i);

                _downstreamKeyers.Add(new DownstreamKeyer(Console, tempDsKeyer, i));
                if (_downstreamKeyers[i] == null) { Console.sendError("Downstream Keyer " + (i + 1) + " Is Null"); return ATEM_VisionSwitcher.Status.KeyerDiscoverFailed; }
            }


            //Get the upstream keyers
            foreach(MixEffectBlock i in meBlocks)
            {
                IBMDSwitcherKeyIterator usIterator = null;
                IntPtr usIteratorPtr;
                Guid usIteratorIID = typeof(IBMDSwitcherKeyIterator).GUID;
                i.meBlock.CreateIterator(ref usIteratorIID, out usIteratorPtr);
                if (usIteratorPtr != null) { usIterator = (IBMDSwitcherKeyIterator)Marshal.GetObjectForIUnknown(usIteratorPtr); }

                //Make sure that the usIterator is not null
                if (usIterator == null) { Console.sendError("UpStream Keyer Iterator Is Null"); return ATEM_VisionSwitcher.Status.KeyerDiscoverFailed; }

                for (int j = 0; true; j++)
                {
                    IBMDSwitcherKey tempUSKeyer = null;
                    usIterator.Next(out tempUSKeyer);

                    if (tempUSKeyer == null) { break; }
                    Console.sendVerbose("Found Upstream Keyer " + j);

                    _upstreamKeyers.Add(new UpstreamKeyer(Console, tempUSKeyer, j));
                    if (_upstreamKeyers[j] == null) { Console.sendError("Upstream Keyer " + j + " Is Null"); return ATEM_VisionSwitcher.Status.KeyerDiscoverFailed; }
                }
            }


            Console.sendInfo("Found Upstream Keyers: ");
            foreach(UpstreamKeyer i in _upstreamKeyers) { Console.sendTabInfo("ID: " + i.Id); }
            Console.sendInfo("Found Downstream Keyers: ");
            foreach (DownstreamKeyer i in _downstreamKeyers) { Console.sendTabInfo("ID: " + i.Id); }

            return ATEM_VisionSwitcher.Status.Success;
        }
    }
}
