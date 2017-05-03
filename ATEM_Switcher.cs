using System;
using BMDSwitcherAPI;
using System.Text.RegularExpressions;

/**
	ATEM Vision Switcher Libary By Hayden Donald 2017
	https://github.com/haydendonald/ATEMVisionSwitcher-Libary

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
            MixEffectBlockDiscoverFailed, InputDiscoverFailed, AuxInputDiscoverFailed, SwitcherDiscoverFailed, InternalError,
            InputReleaseFailed, MixEffectBlockReleaseFailed, KeyerReleaseFailed
        };
        public enum PowerStatus { PSU1Failed, PSU2Failed, Good, Unknown }

        private DebugConsole Console;
        public Switcher _switcher;
        private Inputs _inputs;
        private Keyers _keyers;
        private MixEffectBlocks _mixEffectBlocks;
        private Status _status;
        private PowerStatus _powerStatus;
        private String _ipAddress;
        private String _productName;

        //Properties
        public DebugConsole DebugConsole { get { return Console; } }
        public Switcher Switcher { get { return _switcher; } }
        public Inputs Inputs { get { return _inputs; } }
        public Keyers Keyers { get { return _keyers; } }
        public MixEffectBlocks MixEffectBlocks { get { return _mixEffectBlocks; } }
        public Status CurrentStatus { get { return _status; } }
        public PowerStatus CurrentPowerStatus { get { return _powerStatus; } }
        public String IpAddress { get { return _ipAddress; } }
        public String ProductName { get { return _productName; } }

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

        //Disconnect from the switcher
        public Status Disconnect()
        {
            Console.sendInfo("Disconnecting From The Switcher");
            _switcher = new Switcher(ref Console);
            return Status.Success;
        }
    }
}
