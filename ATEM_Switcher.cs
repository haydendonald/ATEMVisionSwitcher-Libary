using System;
using BMDSwitcherAPI;
using System.Text.RegularExpressions;

/**
	ATEM Vision Switcher Libary By Hayden Donald 2017
	http://github.com/haydendonald

	This libary is repsonsible for the interfacing with the Black Magic ATEM Vision Switcher using the given api
    found at https://www.blackmagicdesign.com/support
*/

namespace ATEMVisionSwitcher
{
    public class ATEM_VisionSwitcher
    {
        public enum Type { ME1, ME2 };
        public enum Status
        {
            Unknown, NoResponse, IncompatibleFirmware, Success, Disconnected, Connected, InvalidIPAddress, KeyerDiscoverFailed,
            MixEffectBlockDiscoverFailed, InputDiscoverFailed, AuxInputDiscoverFailed, SwitcherDiscoverFailed, InternalError
        };
        public enum PowerStatus { PSU1Failed, PSU2Failed, Good, Unknown }

        private DebugConsole Console;
        private Switcher _switcher;
        private Inputs _inputs;
        private Keyers _keyers;
        private MixEffectBlocks _mixEffectBlocks;
        private Status _status;
        private PowerStatus _powerStatus;
        private String _ipAddress;
        private String _productName;

        //Constructor
        public ATEM_VisionSwitcher(DebugConsole.DebugLevel debugLevel = DebugConsole.DebugLevel.Important)
        {
            Console = new DebugConsole(debugLevel);
            _switcher = new Switcher(ref Console);
            _inputs = _switcher.Inputs;
            _keyers = _switcher.Keyers;
            _mixEffectBlocks = _switcher.MixEffectBlocks;
            _status = Status.Unknown;
            _powerStatus = PowerStatus.Unknown;

            Console.sendVerbose("Created Vision Switcher Object");
        }

        //Connect to the switcher
        public Status Connect(String ipAddress)
        {
            Console.sendInfo("Attempting To Connect To The Switcher At " + ipAddress);
            _switcher.Discover(ipAddress);
            return Status.Unknown;
        }
    }
}
