using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using BMDSwitcherAPI;

namespace ATEMVisionSwitcher
{
    public class HyperDecks
    {
        //private DebugConsole Console;
        private List<HyperDeck> _hyperdecks;

        private DebugConsole Console;

        //Properties
        public List<HyperDeck> Decks { get { return _hyperdecks; } }

        //Constructor
        public HyperDecks(DebugConsole debugConsole)
        {
            Console = debugConsole;
            _hyperdecks = new List<HyperDeck> { };
            Console.sendVerbose("Created Hyperdecks Object");
        }

        //Constructor
        public HyperDecks(DebugConsole debugConsole, List<HyperDeck> hyperDecks)
        {
            Console = debugConsole;
            _hyperdecks = hyperDecks;
            Console.sendVerbose("Created Hyperdecks Object");
        }

        //Constructor
        public HyperDecks(DebugConsole debugConsole, HyperDeck hyperDeck)
        {
            Console = debugConsole;
            _hyperdecks = new List<HyperDeck> { hyperDeck };
            Console.sendVerbose("Created Hyperdecks Object");
        }

        //Discover the hyperdecks
        public ATEM_VisionSwitcher.Status Discover(IBMDSwitcher switcher, Inputs inputs)
        {
            Console.sendVerbose("Attempting To Find The HyperDecks");

            //Create the iterator
            IBMDSwitcherHyperDeckIterator iterator = null;
            IntPtr iteratorPtr;
            Guid iteratorIID = typeof(IBMDSwitcherHyperDeckIterator).GUID;
            switcher.CreateIterator(iteratorIID, out iteratorPtr);
            if (iteratorPtr != null) { iterator = (IBMDSwitcherHyperDeckIterator)Marshal.GetObjectForIUnknown(iteratorPtr); }

            //Check the iterator 
            if (iterator == null) { Console.sendError("Hyper Deck Iterator Is Null"); return ATEM_VisionSwitcher.Status.HyperDeckDiscoverFailed; }

            //Get the mix effect blocks
            for (int i = 0; true; i++)
            {
                IBMDSwitcherHyperDeck tempHyperDeck;
                iterator.Next(out tempHyperDeck);
                if (tempHyperDeck == null) { break; }
                Console.sendVerbose("Found HyperDeck " + i);
                _hyperdecks.Add(new HyperDeck(Console, tempHyperDeck, ref inputs, i));
                if (_hyperdecks[i] == null) { Console.sendError("HyperDeck " + i + " Is Null"); return ATEM_VisionSwitcher.Status.HyperDeckDiscoverFailed; }

            }

            Console.sendVerbose("Successfully Discovered The HyperDeck(s)");

            Console.sendInfo("Found " + _hyperdecks.Count + " Hyper Decks");
            foreach (HyperDeck i in _hyperdecks) { Console.sendTabInfo("ID: " + i.Id + "(" + i.Number + ")"); }
            return ATEM_VisionSwitcher.Status.Success;
        }

        public void Play(List<HyperDeck> hyperDecks = null)
        {
            //If not passed anything assume all
            if (hyperDecks == null) { hyperDecks = _hyperdecks; }

            foreach(HyperDeck i in hyperDecks)
            {
                i.Play();
            }
        }

        public void Record(List<HyperDeck> hyperDecks = null)
        {
            //If not passed anything assume all
            if (hyperDecks == null) { hyperDecks = _hyperdecks; }

            foreach (HyperDeck i in hyperDecks)
            {
                i.Record();
            }
        }

        public void Stop(List<HyperDeck> hyperDecks = null)
        {
            //If not passed anything assume all
            if (hyperDecks == null) { hyperDecks = _hyperdecks; }

            foreach (HyperDeck i in hyperDecks)
            {
                i.Stop();
            }
        }

        public void Shuttle(int speedPercent, List<HyperDeck> hyperDecks = null)
        {
            //If not passed anything assume all
            if (hyperDecks == null) { hyperDecks = _hyperdecks; }

            foreach (HyperDeck i in hyperDecks)
            {
                i.Shuttle(speedPercent);
            }
        }

        public void Jog(int frameDelta, List<HyperDeck> hyperDecks = null)
        {
            //If not passed anything assume all
            if (hyperDecks == null) { hyperDecks = _hyperdecks; }

            foreach (HyperDeck i in hyperDecks)
            {
                i.Jog(frameDelta);
            }
        }

        public void PlayStop(List<HyperDeck> hyperDecks = null)
        {
            //If not passed anything assume all
            if (hyperDecks == null) { hyperDecks = _hyperdecks; }

            Boolean allStopped = true;
            foreach (HyperDeck i in hyperDecks) { if (i.PlayerState != _BMDSwitcherHyperDeckPlayerState.bmdSwitcherHyperDeckStateIdle && i.Present) { allStopped = false; } }

            foreach (HyperDeck i in hyperDecks)
            {
                if (i.ConnectionStatus == _BMDSwitcherHyperDeckConnectionStatus.bmdSwitcherHyperDeckConnectionStatusConnected)
                {
                    if (allStopped)
                    {
                        i.Play();
                    }
                    else
                    {
                        i.Stop();
                    }
                }
            }
        }

        public void RecordStop(List<HyperDeck> hyperDecks = null)
        {
            //If not passed anything assume all
            if (hyperDecks == null) { hyperDecks = _hyperdecks; }

            Boolean allStopped = true;
            foreach (HyperDeck i in hyperDecks) { if (i.PlayerState != _BMDSwitcherHyperDeckPlayerState.bmdSwitcherHyperDeckStateIdle && i.Present) { allStopped = false; } }

            foreach (HyperDeck i in hyperDecks)
            {
                if (i.Present)
                {
                    if (allStopped)
                    {
                        i.Record();
                    }
                    else
                    {
                        i.Stop();
                    }
                }
            }
        }

        //Check if all the hyperdecks are of a state
        public Boolean AllPlayerState(_BMDSwitcherHyperDeckPlayerState state)
        {
            foreach (HyperDeck i in _hyperdecks)
            {
                if (i.Present)
                {
                    if (i.PlayerState != state) { return false; }
                }
            }

            return true;
        }
    }
}
