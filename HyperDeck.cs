using System;
using BMDSwitcherAPI;

namespace ATEMVisionSwitcher
{
    public class HyperDeck
    {
        private IBMDSwitcherHyperDeck _object;
        private Inputs _inputs;
        private HyperdeckMonitor _monitor;
        private String _id;
        private long _number;
        private Boolean _present;
        private DebugConsole Console;

        //Properties
        public String Id { get { return _id; } }
        public long Number
        {
            get
            {
                long value = -1;
                try
                {
                    _object.GetId(out value);
                    _number = value;
                    Console.sendVerbose("Got Id From Hyperdeck " + _id + " (" + _number + ") = " + value);
                    return value;
                }
                catch (Exception e) { Console.sendError("Could Not Id ActiveStorageMedia From Hyperdeck " + _id + " (" + _number + ")\nMore Information:\n" + e); return value; }
            }
        }
        public Boolean Present { get { return _present; } }
        public HyperdeckMonitor Monitor { get { return _monitor; } }
        public _BMDSwitcherHyperDeckConnectionStatus ConnectionStatus
        {
            get
            {
                _BMDSwitcherHyperDeckConnectionStatus value = new _BMDSwitcherHyperDeckConnectionStatus();
                try
                {
                    _object.GetConnectionStatus(out value);
                    Console.sendVerbose("Got ConnectionStatus From Hyperdeck " + _id + " (" + _number + ") = " + value);
                    return value;
                }
                catch (Exception e) { Console.sendError("Could Not Get ConnectionStatus From Hyperdeck " + _id + " (" + _number + ")\nMore Information:\n" + e); return value; }
            }
        }
        public Boolean IsRemoteAccessEnabled
        {
            get
            {
                int value = -1;
                try
                {
                    _object.IsRemoteAccessEnabled(out value);
                    Console.sendVerbose("Got IsRemoteAccessEnabled From Hyperdeck " + _id + " (" + _number + ") = " + value);
                    return value == 1;
                }
                catch (Exception e) { Console.sendError("Could Not Get IsRemoteAccessEnabled From Hyperdeck " + _id + " (" + _number + ")\nMore Information:\n" + e); return false; }
            }
        }
        public uint StorageMediaCount
        {
            get
            {
                uint value = 0;
                try
                {
                    _object.GetStorageMediaCount(out value);
                    Console.sendVerbose("Got StorageMediaCount From Hyperdeck " + _id + " (" + _number + ") = " + value);
                    return value;
                }
                catch (Exception e) { Console.sendError("Could Not Get StorageMediaCount From Hyperdeck " + _id + " (" + _number + ")\nMore Information:\n" + e); return value; }
            }
        }
        public _BMDSwitcherHyperDeckStorageMediaState StorageMediaState
        {
            get
            {
                _BMDSwitcherHyperDeckStorageMediaState value = new _BMDSwitcherHyperDeckStorageMediaState();
                try
                {
                    _object.GetStorageMediaState(StorageMediaCount, out value);
                    Console.sendVerbose("Got StorageMediaState From Hyperdeck " + _id + " (" + _number + ") = " + value);
                    return value;
                }
                catch (Exception e) { Console.sendError("Could Not Get StorageMediaState From Hyperdeck " + _id + " (" + _number + ")\nMore Information:\n" + e); return value; }
            }
        }
        public int ActiveStorageMedia
        {
            get
            {
                int value = -1;
                try
                {
                    _object.GetActiveStorageMedia(out value);
                    Console.sendVerbose("Got ActiveStorageMedia From Hyperdeck " + _id + " (" + _number + ") = " + value);
                    return value;
                }
                catch (Exception e) { Console.sendError("Could Not Get ActiveStorageMedia From Hyperdeck " + _id + " (" + _number + ")\nMore Information:\n" + e); return value; }
            }
            set
            {
                try
                {
                    _object.SetActiveStorageMedia(value);
                    Console.sendVerbose("Set ActiveStorageMedia On Hyperdeck " + _id + " (" + _number + ") To " + value);
                }
                catch (Exception e) { Console.sendError("Could Not Set ActiveStorageMedia On Hyperdeck " + _id + " (" + _number + ") To " + value + "\nMore Information:\n" + e); }
            }
        }
        public uint ClipCount
        {
            get
            {
                uint value = 0;
                try
                {
                    _object.GetClipCount(out value);
                    Console.sendVerbose("Got ClipCount From Hyperdeck " + _id + " (" + _number + ") = " + value);
                    return value;
                }
                catch (Exception e) { Console.sendError("Could Not Get ClipCount From Hyperdeck " + _id + " (" + _number + ")\nMore Information:\n" + e); return value; }
            }
        }
        public Input SwitcherInput
        {
            get
            {
                long value = -1;
                try
                {
                    _object.GetSwitcherInput(out value);
                    Input input = _inputs.FindSwitcherInput(value);
                    Console.sendVerbose("Got SwitcherInput From Hyperdeck " + _id + " (" + _number + ") = " + input.LongName + " (" + value + ")");
                    return input;
                }
                catch (Exception e) { Console.sendError("Could Not Get SwitcherInput From Hyperdeck " + _id + " (" + _number + ")\nMore Information:\n" + e); return null; }
            }
            set
            {
                try
                {
                    _object.SetSwitcherInput(_inputs.FindSwitcherInput(value));
                    Console.sendVerbose("Set SwitcherInput On Hyperdeck " + _id + " (" + _number + ") To " + value.LongName);
                }
                catch (Exception e) { Console.sendError("Could Not Set SwitcherInput On Hyperdeck " + _id + " (" + _number + ") To " + value.LongName + "\nMore Information:\n" + e); }
            }
        }
        public Boolean IsInterlacedVideo
        {
            get
            {
                int value = -1;
                try
                {
                    _object.IsInterlacedVideo(out value);
                    Console.sendVerbose("Got IsInterlacedVideo From Hyperdeck " + _id + " (" + _number + ") = " + value);
                    return value == 1;
                }
                catch (Exception e) { Console.sendError("Could Not Get IsInterlacedVideo From Hyperdeck " + _id + " (" + _number + ")\nMore Information:\n" + e); return false; }
            }
        }
        public Boolean IsDropFrameTimeCode
        {
            get
            {
                int value = -1;
                try
                {
                    _object.IsDropFrameTimeCode(out value);
                    Console.sendVerbose("Got IsDropFrameTimeCode From Hyperdeck " + _id + " (" + _number + ") = " + value);
                    return value == 1;
                }
                catch (Exception e) { Console.sendError("Could Not Get IsDropFrameTimeCode From Hyperdeck " + _id + " (" + _number + ")\nMore Information:\n" + e); return false; }
            }
        }
        public _BMDSwitcherHyperDeckPlayerState PlayerState
        {
            get
            {
                _BMDSwitcherHyperDeckPlayerState value = new _BMDSwitcherHyperDeckPlayerState();
                try
                {
                    _object.GetPlayerState(out value);
                    Console.sendVerbose("Got PlayerState From Hyperdeck " + _id + " (" + _number + ") = " + value);
                    return value;
                }
                catch (Exception e) { Console.sendError("Could Not Get PlayerState From Hyperdeck " + _id + " (" + _number + ")\nMore Information:\n" + e); return value; }
            }
        }
        public long CurrentClip
        {
            get
            {
                long value = -1;
                try
                {
                    _object.GetCurrentClip(out value);
                    Console.sendVerbose("Got CurrentClip From Hyperdeck " + _id + " (" + _number + ") = " + value);
                    return value;
                }
                catch (Exception e) { Console.sendError("Could Not Get CurrentClip From Hyperdeck " + _id + " (" + _number + ")\nMore Information:\n" + e); return value; }
            }
            set
            {
                try
                {
                    _object.SetCurrentClip(value);
                    Console.sendVerbose("Set CurrentClip On Hyperdeck " + _id + " (" + _number + ") To " + value);
                }
                catch (Exception e) { Console.sendError("Could Not Set CurrentClip On Hyperdeck " + _id + " (" + _number + ") To " + value + "\nMore Information:\n" + e); }
            }
        }
        public int ShuttleSpeed
        {
            get
            {
                int value = -1;
                try
                {
                    _object.GetShuttleSpeed(out value);
                    Console.sendVerbose("Got ShuttleSpeed From Hyperdeck " + _id + " (" + _number + ") = " + value);
                    return value;
                }
                catch (Exception e) { Console.sendError("Could Not Get ShuttleSpeed From Hyperdeck " + _id + " (" + _number + ")\nMore Information:\n" + e); return value; }
            }
        }
        public Boolean LoopedPlayback
        {
            get
            {
                int value = -1;
                try
                {
                    _object.GetLoopedPlayback(out value);
                    Console.sendVerbose("Got LoopedPlayback From Hyperdeck " + _id + " (" + _number + ") = " + value);
                    return value == 1;
                }
                catch (Exception e) { Console.sendError("Could Not Get LoopedPlayback From Hyperdeck " + _id + " (" + _number + ")\nMore Information:\n" + e); return false; }
            }
            set
            {
                try
                {
                    if (value)
                    {
                        _object.SetLoopedPlayback(1);
                    }
                    else
                    {
                        _object.SetLoopedPlayback(0);
                    }

                    Console.sendVerbose("Set LoopedPlayback On Hyperdeck " + _id + " (" + _number + ") To " + value);
                }
                catch (Exception e) { Console.sendError("Could Not Set LoopedPlayback On Hyperdeck " + _id + " (" + _number + ") To " + value + "\nMore Information:\n" + e); }
            }
        }
        public int SingleClipPlayback
        {
            get
            {
                int value = -1;
                try
                {
                    _object.GetSingleClipPlayback(out value);
                    Console.sendVerbose("Got SingleClipPlayback From Hyperdeck " + _id + " (" + _number + ") = " + value);
                    return value;
                }
                catch (Exception e) { Console.sendError("Could Not Get SingleClipPlayback From Hyperdeck " + _id + " (" + _number + ")\nMore Information:\n" + e); return value; }
            }
            set
            {
                try
                {
                    _object.SetSingleClipPlayback(value);
                    Console.sendVerbose("Set SingleClipPlayback On Hyperdeck " + _id + " (" + _number + ") To " + value);
                }
                catch (Exception e) { Console.sendError("Could Not Set SingleClipPlayback On Hyperdeck " + _id + " (" + _number + ") To " + value + "\nMore Information:\n" + e); }
            }
        }
        public Boolean AutoRollOnTake
        {
            get
            {
                int value = -1;
                try
                {
                    _object.GetAutoRollOnTake(out value);
                    Console.sendVerbose("Got AutoRollOnTake From Hyperdeck " + _id + " (" + _number + ") = " + value);
                    return value == 1;
                }
                catch (Exception e) { Console.sendError("Could Not Get AutoRollOnTake From Hyperdeck " + _id + " (" + _number + ")\nMore Information:\n" + e); return false; }
            }
            set
            {
                try
                {
                    if (value)
                    {
                        _object.SetAutoRollOnTake(1);
                    }
                    else
                    {
                        _object.SetAutoRollOnTake(0);
                    }
                    Console.sendVerbose("Set AutoRollOnTake On Hyperdeck " + _id + " (" + _number + ") To " + value);
                }
                catch (Exception e) { Console.sendError("Could Not Set AutoRollOnTake On Hyperdeck " + _id + " (" + _number + ") To " + value + "\nMore Information:\n" + e); }
            }
        }
        public ushort AutoRollOnTakeFrameDelay
        {
            get
            {
                ushort value = 0;
                try
                {
                    _object.GetAutoRollOnTakeFrameDelay(out value);
                    Console.sendVerbose("Got AutoRollOnTakeFrameDelay From Hyperdeck " + _id + " (" + _number + ") = " + value);
                    return value;
                }
                catch (Exception e) { Console.sendError("Could Not Get AutoRollOnTakeFrameDelay From Hyperdeck " + _id + " (" + _number + ")\nMore Information:\n" + e); return value; }
            }
            set
            {
                try
                {
                    _object.SetAutoRollOnTakeFrameDelay(value);
                    Console.sendVerbose("Set AutoRollOnTakeFrameDelay On Hyperdeck " + _id + " (" + _number + ") To " + value);
                }
                catch (Exception e) { Console.sendError("Could Not Set AutoRollOnTakeFrameDelay On Hyperdeck " + _id + " (" + _number + ") To " + value + "\nMore Information:\n" + e); }
            }
        }
        public uint NetworkAddress
        {
            get
            {
                uint value = 0;
                try
                {
                    _object.GetNetworkAddress(out value);
                    Console.sendVerbose("Got NetworkAddress From Hyperdeck " + _id + " (" + _number + ") = " + value);
                    return value;
                }
                catch (Exception e) { Console.sendError("Could Not Get NetworkAddress From Hyperdeck " + _id + " (" + _number + ")\nMore Information:\n" + e); return value; }
            }
            set
            {
                try
                {
                    _object.SetNetworkAddress(value);
                    Console.sendVerbose("Set NetworkAddress On Hyperdeck " + _id + " (" + _number + ") To " + value);
                }
                catch (Exception e) { Console.sendError("Could Not Set NetworkAddress On Hyperdeck " + _id + " (" + _number + ") To " + value + "\nMore Information:\n" + e); }
            }
        }


        //Constructor
        public HyperDeck(DebugConsole console, IBMDSwitcherHyperDeck hyperdeck, ref Inputs inputs, long number, String id = "Not Set")
        {
            Console = console;
            _object = hyperdeck;
            _id = id;
            _inputs = inputs;
            _number = number;
            _monitor = new HyperdeckMonitor(Console, _id, _number);

            if (ConnectionStatus == _BMDSwitcherHyperDeckConnectionStatus.bmdSwitcherHyperDeckConnectionStatusConnected) { _present = true; }
            else { _present = false; }

            //Add the monitor to the callback
            _object.AddCallback(_monitor);
        }

        public _BMDSwitcherHyperDeckStorageMediaState StorageState(uint id)
        {
            _BMDSwitcherHyperDeckStorageMediaState state = new _BMDSwitcherHyperDeckStorageMediaState();
            try
            {
                _object.GetStorageMediaState(id, out state);
                Console.sendVerbose("Got State From Hyperdeck " + _id + " (" + _number + ")");
                return state;
            }
            catch (Exception e)
            {
                Console.sendError("Could Not Get State On Hyperdeck " + _id + " (" + _number + ")\nMore Information:\n" + e);
                return state;
            }
        }

        public Boolean Play()
        {
            try
            {
                Console.sendVerbose("Playing On Hyperdeck " + _id + " (" + _number + ")");
                _object.Play();
                return true;
            }
            catch (Exception e)
            {
                Console.sendError("Could Not Play On Hyperdeck " + _id + " (" + _number + ")\nMore Information:\n" + e);
                return false;
            }
        }

        public Boolean Record()
        {
            try
            {
                Console.sendVerbose("Recording On Hyperdeck " + _id + " (" + _number + ")");
                _object.Record();
                return true;
            }
            catch (Exception e)
            {
                Console.sendError("Could Not Recording On Hyperdeck " + _id + " (" + _number + ")\nMore Information:\n" + e);
                return false;
            }
        }

        public Boolean Stop()
        {
            try
            {
                Console.sendVerbose("Stopping On Hyperdeck " + _id + " (" + _number + ")");
                _object.Stop();
                return true;
            }
            catch (Exception e)
            {
                Console.sendError("Could Not Stop On Hyperdeck " + _id + " (" + _number + ")\nMore Information:\n" + e);
                return false;
            }
        }

        public Boolean Shuttle(int speedPercent)
        {
            try
            {
                Console.sendVerbose("Shuttling On Hyperdeck " + _id + " (" + _number + ")");
                _object.Shuttle(speedPercent);
                return true;
            }
            catch (Exception e)
            {
                Console.sendError("Could Not Shuttle On Hyperdeck " + _id + " (" + _number + ")\nMore Information:\n" + e);
                return false;
            }
        }

        public Boolean Jog(int frameDelta)
        {
            try
            {
                Console.sendVerbose("Jogging On Hyperdeck " + _id + " (" + _number + ")");
                _object.Jog(frameDelta);
                return true;
            }
            catch (Exception e)
            {
                Console.sendError("Could Not Jog On Hyperdeck " + _id + " (" + _number + ")\nMore Information:\n" + e);
                return false;
            }
        }

        public Boolean RecordStop()
        {
            try
            {
                if(PlayerState == _BMDSwitcherHyperDeckPlayerState.bmdSwitcherHyperDeckStateRecord) { Stop(); }
                else { Record(); }
                return true;
            }
            catch (Exception e)
            {
                Console.sendError("Could Not RecordStop On Hyperdeck " + _id + " (" + _number + ")\nMore Information:\n" + e);
                return false;
            }
        }

        public Boolean PlayStop()
        {
            try
            {
                if (PlayerState == _BMDSwitcherHyperDeckPlayerState.bmdSwitcherHyperDeckStatePlay) { Stop(); }
                else { Play(); }
                return true;
            }
            catch (Exception e)
            {
                Console.sendError("Could Not PlayStop On Hyperdeck " + _id + " (" + _number + ")\nMore Information:\n" + e);
                return false;
            }
        }
    }
}
