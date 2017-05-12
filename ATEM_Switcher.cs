using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Drawing;

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
            InputReleaseFailed, MixEffectBlockReleaseFailed, KeyerReleaseFailed, HyperDeckDiscoverFailed
        };
        public enum PowerStatus { PSU1Failed, PSU2Failed, Good, Unknown }

        //UI Colors
        public enum ColorType { Default, Live, LiveME, Preview, PreviewME, Sub };
        private Color _defaultColor = Color.White;
        private Color _liveColor = Color.Red;
        private List<Color> _liveMEColor = new List<Color> { Color.Aqua, Color.BlueViolet };
        private Color _previewColor = Color.LightGreen;
        private List<Color> _previewMEColor = new List<Color> { Color.Aqua, Color.BlueViolet };
        private Color _subColor = Color.Yellow;

        private DebugConsole Console;
        public Switcher _switcher;
        private Inputs _inputs;
        private Keyers _keyers;
        private MixEffectBlocks _mixEffectBlocks;
        private Status _status;
        private PowerStatus _powerStatus;
        private String _ipAddress;
        private String _productName;
        private String _LibVersion = "Development";
        private String _ATEMVersion = "7.1.1";

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
        public Color DefaultColor { get { return _defaultColor; } set { _defaultColor = value; } }
        public Color LiveColor { get { return _liveColor; }set { _liveColor = value; } }
        public List<Color> LiveMEColor { get { return _liveMEColor; } set { _liveMEColor = value; } }
        public Color PreviewColor { get { return _previewColor; } set { _previewColor = value; } }
        public List<Color> PreviewMEColor { get { return _previewMEColor; } set { _previewMEColor = value; } }
        public Color SubColor { get { return _subColor; } set { _subColor = value; } }

        //Constructor
        public ATEM_VisionSwitcher(DebugConsole.DebugLevel debugLevel = DebugConsole.DebugLevel.Important)
        {
            Console = new DebugConsole(debugLevel);
            _switcher = new Switcher(Console);
            _inputs = _switcher.Inputs;
            _keyers = _switcher.Keyers;
            _mixEffectBlocks = _switcher.MixEffectBlocks;
            _status = Status.Unknown;
            _powerStatus = PowerStatus.Unknown;

            Console.sendVerbose("Created Vision Switcher Object");
            Console.sendInfo("ATEM Vision Switcher Libary");
            Console.sendTabInfo("https://github.com/haydendonald/ATEMVisionSwitcher-Libary");
            Console.sendTabInfo("");
            Console.sendTabInfo("Libary Version: " + _LibVersion);
            Console.sendTabInfo("ATEM Version: " + _ATEMVersion);
        }

        //Connect to the switcher
        public Status Connect(String ipAddress)
        {
            Console.sendInfo("Attempting To Connect To The Switcher At " + ipAddress);

            //Check if the ip is valid
            if (CheckIPAddress(ipAddress)) {
                Status status = _switcher.Discover(ipAddress);

                if(status == Status.Success)
                {
                    _ipAddress = ipAddress;
                    _productName = _switcher.ProductName;
                    return Status.Connected;
                }

                return status;
            }
            else { return Status.InvalidIPAddress; }
        }

        //Disconnect from the switcher
        public Status Disconnect()
        {
            Console.sendInfo("Disconnecting From The Switcher");
            _switcher = new Switcher(Console);
            return Status.Success;
        }

        //Check if the IP Address is valid, will return VALID if valid, else will return the issue
        private Boolean CheckIPAddress(String ipAddr)
        {
            if (ipAddr.Length < 7) { return false; }
            if (Regex.IsMatch(ipAddr, @"^[a-zA-Z]+$")) { return false; }
            return true;
        }
    }
}
