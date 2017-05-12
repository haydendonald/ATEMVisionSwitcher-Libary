/**
	ATEM Vision Switcher Libary By Hayden Donald 2017
	https://github.com/haydendonald/ATEMVisionSwitcher-Libary

	This libary is repsonsible for the interfacing with the Black Magic ATEM Vision Switcher using the given api
    found at https://www.blackmagicdesign.com/support
*/

using System; 
using BMDSwitcherAPI;

namespace ATEMVisionSwitcher
{
    public class HyperdeckMonitor : IBMDSwitcherHyperDeckCallback
    {
        private DebugConsole Console;
        private String _id;
        private long _number;

        //Constructor
        public HyperdeckMonitor(DebugConsole console, String id, long number)
        {
            Console = console;
            _id = id;
            _number = number;

            Console.sendVerbose("Created HyperdeckMonitor Object For HyperDeck " + _id + " (" + _number + ")");
        }

        //Events
        public event EventHandler ActiveStorageMediaChanged;
        public event EventHandler AutoRollOnTakeChanged;
        public event EventHandler AutoRollOnTakeFrameDelayChanged;
        public event EventHandler ClipCountChanged;
        public event EventHandler ConnectionStatusChanged;
        public event EventHandler CurrentClipChanged;
        public event EventHandler CurrentClipTimeChanged;
        public event EventHandler CurrentTimelineTimeChanged;
        public event EventHandler EstimatedRecordTimeRemainingChanged;
        public event EventHandler InterlacedVideoChanged;
        public event EventHandler LoopedPlaybackChanged;
        public event EventHandler NetworkAddressChanged;
        public event EventHandler PlayerStateChanged;
        public event EventHandler RemoteAccessEnabledChanged;
        public event EventHandler ShuttleSpeedChanged;
        public event EventHandler DropFrameTimeCodeChanged;
        public event EventHandler SingleClipPlaybackChanged;
        public event EventHandler StorageMediaStateChanged;
        public event EventHandler SwitcherInputChanged;
        public event EventHandler FrameRateChanged;

        void IBMDSwitcherHyperDeckCallback.Notify(_BMDSwitcherHyperDeckEventType eventType)
        {
            try
            {
                //Switch the Property Id
                switch (eventType)
                {
                    case _BMDSwitcherHyperDeckEventType.bmdSwitcherHyperDeckEventTypeActiveStorageMediaChanged:
                        if (ActiveStorageMediaChanged != null)
                        {
                            Console.sendVerbose("ActiveStorageMediaChanged Has Changed On Hyperdeck " + _id + " (" + _number + ")");
                            ActiveStorageMediaChanged(this, null);
                        }
                        break;
                    case _BMDSwitcherHyperDeckEventType.bmdSwitcherHyperDeckEventTypeAutoRollOnTakeChanged:
                        if (AutoRollOnTakeChanged != null)
                        {
                            Console.sendVerbose("AutoRollOnTakeChanged Has Changed On Hyperdeck " + _id + " (" + _number + ")");
                            AutoRollOnTakeChanged(this, null);
                        }
                        break;
                    case _BMDSwitcherHyperDeckEventType.bmdSwitcherHyperDeckEventTypeAutoRollOnTakeFrameDelayChanged:
                        if (AutoRollOnTakeFrameDelayChanged != null)
                        {
                            Console.sendVerbose("AutoRollOnTakeFrameDelayChanged Has Changed On Hyperdeck " + _id + " (" + _number + ")");
                            AutoRollOnTakeFrameDelayChanged(this, null);
                        }
                        break;
                    case _BMDSwitcherHyperDeckEventType.bmdSwitcherHyperDeckEventTypeClipCountChanged:
                        if (ClipCountChanged != null)
                        {
                            Console.sendVerbose("ClipCountChanged Has Changed On Hyperdeck " + _id + " (" + _number + ")");
                            ClipCountChanged(this, null);
                        }
                        break;
                    case _BMDSwitcherHyperDeckEventType.bmdSwitcherHyperDeckEventTypeConnectionStatusChanged:
                        if (ConnectionStatusChanged != null)
                        {
                            Console.sendVerbose("ConnectionStatusChanged Has Changed On Hyperdeck " + _id + " (" + _number + ")");
                            ConnectionStatusChanged(this, null);
                        }
                        break;
                    case _BMDSwitcherHyperDeckEventType.bmdSwitcherHyperDeckEventTypeCurrentClipChanged:
                        if (CurrentClipChanged != null)
                        {
                            Console.sendVerbose("CurrentClipChanged Has Changed On Hyperdeck " + _id + " (" + _number + ")");
                            CurrentClipChanged(this, null);
                        }
                        break;
                    case _BMDSwitcherHyperDeckEventType.bmdSwitcherHyperDeckEventTypeCurrentClipTimeChanged:
                        if (CurrentClipTimeChanged != null)
                        {
                            Console.sendVerbose("CurrentClipTimeChanged Has Changed On Hyperdeck " + _id + " (" + _number + ")");
                            CurrentClipTimeChanged(this, null);
                        }
                        break;
                    case _BMDSwitcherHyperDeckEventType.bmdSwitcherHyperDeckEventTypeCurrentTimelineTimeChanged:
                        if (CurrentTimelineTimeChanged != null)
                        {
                            Console.sendVerbose("CurrentTimelineTimeChanged Has Changed On Hyperdeck " + _id + " (" + _number + ")");
                            CurrentTimelineTimeChanged(this, null);
                        }
                        break;
                    case _BMDSwitcherHyperDeckEventType.bmdSwitcherHyperDeckEventTypeEstimatedRecordTimeRemainingChanged:
                        if (EstimatedRecordTimeRemainingChanged != null)
                        {
                            Console.sendVerbose("EstimatedRecordTimeRemainingChanged Has Changed On Hyperdeck " + _id + " (" + _number + ")");
                            EstimatedRecordTimeRemainingChanged(this, null);
                        }
                        break;
                    case _BMDSwitcherHyperDeckEventType.bmdSwitcherHyperDeckEventTypeFrameRateChanged:
                        if (FrameRateChanged != null)
                        {
                            Console.sendVerbose("FrameRateChanged Has Changed On Hyperdeck " + _id + " (" + _number + ")");
                            FrameRateChanged(this, null);
                        }
                        break;
                    case _BMDSwitcherHyperDeckEventType.bmdSwitcherHyperDeckEventTypeInterlacedVideoChanged:
                        if (InterlacedVideoChanged != null)
                        {
                            Console.sendVerbose("InterlacedVideoChanged Has Changed On Hyperdeck " + _id + " (" + _number + ")");
                            InterlacedVideoChanged(this, null);
                        }
                        break;
                    case _BMDSwitcherHyperDeckEventType.bmdSwitcherHyperDeckEventTypeLoopedPlaybackChanged:
                        if (LoopedPlaybackChanged != null)
                        {
                            Console.sendVerbose("LoopedPlaybackChanged Has Changed On Hyperdeck " + _id + " (" + _number + ")");
                            LoopedPlaybackChanged(this, null);
                        }
                        break;
                    case _BMDSwitcherHyperDeckEventType.bmdSwitcherHyperDeckEventTypeNetworkAddressChanged:
                        if (NetworkAddressChanged != null)
                        {
                            Console.sendVerbose("NetworkAddressChanged Has Changed On Hyperdeck " + _id + " (" + _number + ")");
                            NetworkAddressChanged(this, null);
                        }
                        break;
                    case _BMDSwitcherHyperDeckEventType.bmdSwitcherHyperDeckEventTypePlayerStateChanged:
                        if (PlayerStateChanged != null)
                        {
                            Console.sendVerbose("PlayerStateChanged Has Changed On Hyperdeck " + _id + " (" + _number + ")");
                            PlayerStateChanged(this, null);
                        }
                        break;
                    case _BMDSwitcherHyperDeckEventType.bmdSwitcherHyperDeckEventTypeRemoteAccessEnabledChanged:
                        if (RemoteAccessEnabledChanged != null)
                        {
                            Console.sendVerbose("RemoteAccessEnabledChanged Has Changed On Hyperdeck " + _id + " (" + _number + ")");
                            RemoteAccessEnabledChanged(this, null);
                        }
                        break;
                    case _BMDSwitcherHyperDeckEventType.bmdSwitcherHyperDeckEventTypeShuttleSpeedChanged:
                        if (ShuttleSpeedChanged != null)
                        {
                            Console.sendVerbose("ShuttleSpeedChanged Has Changed On Hyperdeck " + _id + " (" + _number + ")");
                            ShuttleSpeedChanged(this, null);
                        }
                        break;
                    case _BMDSwitcherHyperDeckEventType.bmdSwitcherHyperDeckEventTypeDropFrameTimeCodeChanged:
                        if (DropFrameTimeCodeChanged != null)
                        {
                            Console.sendVerbose("DropFrameTimeCodeChanged Has Changed On Hyperdeck " + _id + " (" + _number + ")");
                            DropFrameTimeCodeChanged(this, null);
                        }
                        break;
                    case _BMDSwitcherHyperDeckEventType.bmdSwitcherHyperDeckEventTypeSingleClipPlaybackChanged:
                        if (SingleClipPlaybackChanged != null)
                        {
                            Console.sendVerbose("SingleClipPlaybackChanged Has Changed On Hyperdeck " + _id + " (" + _number + ")");
                            SingleClipPlaybackChanged(this, null);
                        }
                        break;
                    case _BMDSwitcherHyperDeckEventType.bmdSwitcherHyperDeckEventTypeStorageMediaStateChanged:
                        if (StorageMediaStateChanged != null)
                        {
                            Console.sendVerbose("StorageMediaStateChanged Has Changed On Hyperdeck " + _id + " (" + _number + ")");
                            StorageMediaStateChanged(this, null);
                        }
                        break;
                    case _BMDSwitcherHyperDeckEventType.bmdSwitcherHyperDeckEventTypeSwitcherInputChanged:
                        if (SwitcherInputChanged != null)
                        {
                            Console.sendVerbose("SwitcherInputChanged Has Changed On Hyperdeck " + _id + " (" + _number + ")");
                            SwitcherInputChanged(this, null);
                        }
                        break;
                }
            }
            catch { }
        }

        public event EventHandler ErrorTypeAlreadyInUse;
        public event EventHandler ErrorTypeDuplicateAddress;
        public event EventHandler ErrorTypeMediaFull;
        public event EventHandler ErrorTypeNoInput;
        public event EventHandler ErrorTypeRemoteDisabled;
        public event EventHandler ErrorTypeUnknown;
        public event EventHandler MediaError;

        void IBMDSwitcherHyperDeckCallback.NotifyError(_BMDSwitcherHyperDeckErrorType errorType)
        {
            try
            {
                //Switch the Property Id
                switch (errorType)
                {
                    case _BMDSwitcherHyperDeckErrorType.bmdSwitcherHyperDeckErrorTypeAlreadyInUse:
                        if (ErrorTypeAlreadyInUse != null)
                        {
                            Console.sendVerbose("ErrorTypeAlreadyInUse Has Changed On Hyperdeck " + _id + " (" + _number + ")");
                            ErrorTypeAlreadyInUse(this, null);
                        }
                        break;
                    case _BMDSwitcherHyperDeckErrorType.bmdSwitcherHyperDeckErrorTypeDuplicateAddress:
                        if (ErrorTypeDuplicateAddress != null)
                        {
                            Console.sendVerbose("ErrorTypeDuplicateAddress Has Changed On Hyperdeck " + _id + " (" + _number + ")");
                            ErrorTypeDuplicateAddress(this, null);
                        }
                        break;
                    case _BMDSwitcherHyperDeckErrorType.bmdSwitcherHyperDeckErrorTypeMediaError:
                        if (MediaError != null)
                        {
                            Console.sendVerbose("TypeMediaError Has Changed On Hyperdeck " + _id + " (" + _number + ")");
                            MediaError(this, null);
                        }
                        break;
                    case _BMDSwitcherHyperDeckErrorType.bmdSwitcherHyperDeckErrorTypeMediaFull:
                        if (ErrorTypeMediaFull != null)
                        {
                            Console.sendVerbose("ErrorTypeMediaFull Has Changed On Hyperdeck " + _id + " (" + _number + ")");
                            ErrorTypeMediaFull(this, null);
                        }
                        break;
                    case _BMDSwitcherHyperDeckErrorType.bmdSwitcherHyperDeckErrorTypeNoInput:
                        if (ErrorTypeNoInput != null)
                        {
                            Console.sendVerbose("ErrorTypeNoInput Has Changed On Hyperdeck " + _id + " (" + _number + ")");
                            ErrorTypeNoInput(this, null);
                        }
                        break;
                    case _BMDSwitcherHyperDeckErrorType.bmdSwitcherHyperDeckErrorTypeRemoteDisabled:
                        if (ErrorTypeRemoteDisabled != null)
                        {
                            Console.sendVerbose("ErrorTypeRemoteDisabled Has Changed On Hyperdeck " + _id + " (" + _number + ")");
                            ErrorTypeRemoteDisabled(this, null);
                        }
                        break;
                    case _BMDSwitcherHyperDeckErrorType.bmdSwitcherHyperDeckErrorTypeUnknown:
                        if (ErrorTypeUnknown != null)
                        {
                            Console.sendVerbose("ErrorTypeUnknown Has Changed On Hyperdeck " + _id + " (" + _number + ")");
                            ErrorTypeUnknown(this, null);
                        }
                        break;
                }
            }
            catch { }
        }
    }

}
