using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BMDSwitcherAPI;
using System.Windows.Forms;

namespace ATEMVisionSwitcher
{
    public class Switcher
    {
        private IBMDSwitcher _switcher;
        private CBMDSwitcherDiscovery _discovery;
        private DebugConsole Console;
        private MixEffectBlocks _mixEffectBlocks;
        private Inputs _inputs;
        private Keyers _keyers;

        //Properties
        public MixEffectBlocks MixEffectBlocks { get { return _mixEffectBlocks; } }
        public Inputs Inputs { get { return _inputs; } }
        public Keyers Keyers { get { return _keyers; } }

        //Constructor
        public Switcher(ref DebugConsole debugConsole)
        {
            Console = debugConsole;

            //Check if the ATEM software is installed
            try { _discovery = new CBMDSwitcherDiscovery(); if (_discovery == null) { throw new Exception(); } }
            catch
            {
                debugConsole.sendError("ATEM Software Not Installed");
                MessageBox.Show("ATEM Switcher Software Not Installed", "ERROR");
                Environment.Exit(1);
            }

            _mixEffectBlocks = new MixEffectBlocks(ref Console);
            _inputs = new Inputs(ref Console);
            _keyers = new Keyers(ref Console);

            Console.sendVerbose("Created Switcher Object");
        }

        ~Switcher()
        {
            Console.sendError("REMOVED!!!");
        }

        //Discover the switcher
        public ATEM_VisionSwitcher.Status Discover(String ipAddress)
        {
            Console.sendVerbose("Attempting To Discover The Switcher");
            _BMDSwitcherConnectToFailure failReason = 0;
            try { _discovery.ConnectTo(ipAddress, out _switcher, out failReason); }
            catch(Exception e)
            {
                Console.sendVerbose("Error Details: \n" + e);

                switch (failReason)
                {
                    case _BMDSwitcherConnectToFailure.bmdSwitcherConnectToFailureNoResponse:
                        Console.sendError("Could Not Discover Switcher Because There Was No Response");
                        return ATEM_VisionSwitcher.Status.NoResponse;
                    case _BMDSwitcherConnectToFailure.bmdSwitcherConnectToFailureIncompatibleFirmware:
                        Console.sendError("Could Not Discover Switcher Because The Switcher Was Inncompatible Firmware");
                        return ATEM_VisionSwitcher.Status.IncompatibleFirmware;
                    default:
                        Console.sendError("Could Not Discover Switcher For An Unknown Reason");
                        return ATEM_VisionSwitcher.Status.Unknown;
                }
            }

            //Make sure the switcher is not null
            if (_switcher == null) { Console.sendError("Switcher Is Null"); return ATEM_VisionSwitcher.Status.InternalError; }

            //We've discovered the switcher!
            Console.sendVerbose("Discovered Switcher");

            if (_inputs.Discover(ref _switcher) != ATEM_VisionSwitcher.Status.Success) { return ATEM_VisionSwitcher.Status.InputDiscoverFailed; }
            if ( _mixEffectBlocks.Discover(ref _switcher, _inputs.SwitcherInputs) != ATEM_VisionSwitcher.Status.Success) { return ATEM_VisionSwitcher.Status.MixEffectBlockDiscoverFailed; }
            if (_keyers.Discover(ref _switcher, _mixEffectBlocks.meBlocks) != ATEM_VisionSwitcher.Status.Success) { return ATEM_VisionSwitcher.Status.KeyerDiscoverFailed; }

            //And We're Done!
            Console.sendInfo("Connected To Switcher");
            return ATEM_VisionSwitcher.Status.Success;
        }
    }
}
