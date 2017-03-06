using System;
using System.Collections.Generic;
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

        //On Air
        public Boolean GetOnAir(Keyer keyer) { return keyer.OnAir; }
        public List<Boolean> GetOnAir(List<Keyer> keyers)
        {
            List<Boolean> returnList = new List<Boolean> { };
            foreach (Keyer i in keyers) { returnList.Add(i.OnAir); }
            return returnList;
        }
        public void SetOnAir(Keyer keyer, Boolean value = true) { keyer.OnAir = value; }
        public void SetOnAir(List<Keyer> keyers, Boolean value) { foreach(Keyer i in keyers) { i.OnAir = value; } }

        //CutInputAvailabilityMask
        public _BMDSwitcherInputAvailability GetCutInputAvailabilityMask(Keyer keyer) { return keyer.CutInputAvailabilityMask; }
        public List<_BMDSwitcherInputAvailability> GetCutInputAvailabilityMask(List<Keyer> keyers)
        {
            List<_BMDSwitcherInputAvailability> returnList = new List<_BMDSwitcherInputAvailability> { };
            foreach (Keyer i in keyers) { returnList.Add(i.CutInputAvailabilityMask); }
            return returnList;
        }

        //FillInputAvailabilityMask
        public _BMDSwitcherInputAvailability GetFillInputAvailabilityMask(Keyer keyer) { return keyer.FillInputAvailabilityMask; }
        public List<_BMDSwitcherInputAvailability> GetFillInputAvailabilityMask(List<Keyer> keyers)
        {
            List<_BMDSwitcherInputAvailability> returnList = new List<_BMDSwitcherInputAvailability> { };
            foreach (Keyer i in keyers) { returnList.Add(i.FillInputAvailabilityMask); }
            return returnList;
        }

        //Id
        public String GetId(Keyer keyer) { return keyer.Id; }
        public List<String> GetId(List<Keyer> keyers)
        {
            List<String> returnList = new List<String> { };
            foreach (Keyer i in keyers) { returnList.Add(i.Id); }
            return returnList;
        }
        public void SetId(Keyer keyer, String value) { keyer.Id = value; }
        public void SetId(List<Keyer> keyers, String value) { foreach (Keyer i in keyers) { i.Id = value; } }

        //InputCut
        public long GetInputCut(Keyer keyer) { return keyer.InputCut; }
        public List<long> GetInputCut(List<Keyer> keyers)
        {
            List<long> returnList = new List<long> { };
            foreach (Keyer i in keyers) { returnList.Add(i.InputCut); }
            return returnList;
        }
        public void SetInputCut(Keyer keyer, long value ) { keyer.InputCut = value; }
        public void SetInputCut(List<Keyer> keyers, long value) { foreach (Keyer i in keyers) { i.InputCut = value; } }

        //InputFill
        public long GetInputFill(Keyer keyer) { return keyer.InputFill; }
        public List<long> GetInputFill(List<Keyer> keyers)
        {
            List<long> returnList = new List<long> { };
            foreach (Keyer i in keyers) { returnList.Add(i.InputFill); }
            return returnList;
        }
        public void SetInputFill(Keyer keyer, long value) { keyer.InputFill = value; }
        public void SetInputFill(List<Keyer> keyers, long value) { foreach (Keyer i in keyers) { i.InputFill = value; } }

        //MaskBottom
        public double GetMaskBottom(Keyer keyer) { return keyer.MaskBottom; }
        public List<double> GetMaskBottom(List<Keyer> keyers)
        {
            List<double> returnList = new List<double> { };
            foreach (Keyer i in keyers) { returnList.Add(i.MaskBottom); }
            return returnList;
        }
        public void SetMaskBottom(Keyer keyer, double value) { keyer.MaskBottom = value; }
        public void SetMaskBottom(List<Keyer> keyers, double value) { foreach (Keyer i in keyers) { i.MaskBottom = value; } }

        //Masked
        public Boolean GetMasked(Keyer keyer) { return keyer.Masked; }
        public List<Boolean> GetMasked(List<Keyer> keyers)
        {
            List<Boolean> returnList = new List<Boolean> { };
            foreach (Keyer i in keyers) { returnList.Add(i.Masked); }
            return returnList;
        }
        public void SetMasked(Keyer keyer, Boolean value = true) { keyer.Masked = value; }
        public void SetMasked(List<Keyer> keyers, Boolean value) { foreach (Keyer i in keyers) { i.Masked = value; } }

        //MaskLeft
        public double GetMaskLeft(Keyer keyer) { return keyer.MaskLeft; }
        public List<double> GetMaskLeft(List<Keyer> keyers)
        {
            List<double> returnList = new List<double> { };
            foreach (Keyer i in keyers) { returnList.Add(i.MaskLeft); }
            return returnList;
        }
        public void SetMaskLeft(Keyer keyer, double value) { keyer.MaskLeft = value; }
        public void SetMaskLeft(List<Keyer> keyers, double value) { foreach (Keyer i in keyers) { i.MaskLeft = value; } }

        //MaskRight
        public double GetMaskRight(Keyer keyer) { return keyer.MaskRight; }
        public List<double> GetMaskRight(List<Keyer> keyers)
        {
            List<double> returnList = new List<double> { };
            foreach (Keyer i in keyers) { returnList.Add(i.MaskRight); }
            return returnList;
        }
        public void SetMaskRight(Keyer keyer, double value) { keyer.MaskRight = value; }
        public void SetMaskRight(List<Keyer> keyers, double value) { foreach (Keyer i in keyers) { i.MaskRight = value; } }

        //MaskTop
        public double GetMaskTop(Keyer keyer) { return keyer.MaskTop; }
        public List<double> GetMaskTop(List<Keyer> keyers)
        {
            List<double> returnList = new List<double> { };
            foreach (Keyer i in keyers) { returnList.Add(i.MaskTop); }
            return returnList;
        }
        public void SetMaskTop(Keyer keyer, double value) { keyer.MaskTop = value; }
        public void SetMaskTop(List<Keyer> keyers, double value) { foreach (Keyer i in keyers) { i.MaskTop = value; } }

        //Number
        public long GetNumber(Keyer keyer) { return keyer.Number; }
        public List<long> GetNumber(List<Keyer> keyers)
        {
            List<long> returnList = new List<long> { };
            foreach (Keyer i in keyers) { returnList.Add(i.Number); }
            return returnList;
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
            int j = 0;
            foreach(MixEffectBlock i in meBlocks)
            {
                IBMDSwitcherKeyIterator usIterator = null;
                IntPtr usIteratorPtr;
                Guid usIteratorIID = typeof(IBMDSwitcherKeyIterator).GUID;
                i.meBlock.CreateIterator(ref usIteratorIID, out usIteratorPtr);
                if (usIteratorPtr != null) { usIterator = (IBMDSwitcherKeyIterator)Marshal.GetObjectForIUnknown(usIteratorPtr); }

                //Make sure that the usIterator is not null
                if (usIterator == null) { Console.sendError("UpStream Keyer Iterator Is Null"); return ATEM_VisionSwitcher.Status.KeyerDiscoverFailed; }

                while(true)
                {
                    IBMDSwitcherKey tempUSKeyer = null;
                    usIterator.Next(out tempUSKeyer);

                    if (tempUSKeyer == null) { break; }
                    Console.sendVerbose("Found Upstream Keyer " + j);

                    _upstreamKeyers.Add(new UpstreamKeyer(Console, tempUSKeyer, j));
                    if (_upstreamKeyers[j] == null) { Console.sendError("Upstream Keyer " + j + " Is Null"); return ATEM_VisionSwitcher.Status.KeyerDiscoverFailed; }
                    j++;
                }
            }


            Console.sendInfo("Found Upstream Keyers: ");
            foreach(UpstreamKeyer i in _upstreamKeyers) { Console.sendTabInfo("ID: " + i.Id + " (" + i.Number + ")"); }
            Console.sendInfo("Found Downstream Keyers: ");
            foreach (DownstreamKeyer i in _downstreamKeyers) { Console.sendTabInfo("ID: " + i.Id + " (" + i.Number + ")"); }

            return ATEM_VisionSwitcher.Status.Success;
        }
    }
}
