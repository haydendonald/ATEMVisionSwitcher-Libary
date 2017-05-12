using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BMDSwitcherAPI;

namespace ATEMVisionSwitcher
{
    public partial class HyperDeckPlayRecordButton : UserControl
    {
        public enum HyperDeckPlayRecordButtonMode { Play, Record, Stop, PlayStop, RecordStop }

        private HyperDecks _hyperDecks;
        private HyperDeckPlayRecordButtonMode _mode;
        private String _id;

        public HyperDeckPlayRecordButton()
        {
            InitializeComponent();
        }

        //Set the parameters
        public void SetParameters(HyperDecks hyperDecks, HyperDeckPlayRecordButtonMode mode, String id)
        {
            _hyperDecks = hyperDecks;
            _mode = mode;
            _id = id;
            SetEvents();
        }

        //Set the parameters
        public void SetParameters(DebugConsole debugConsole, HyperDeck hyperDeck, HyperDeckPlayRecordButtonMode mode, String id)
        {
            _hyperDecks = new HyperDecks(debugConsole, hyperDeck);
            _mode = mode;
            _id = id;
            SetEvents();
        }

        private void SetEvents()
        {
            button.Text = _id;

            foreach(HyperDeck i in _hyperDecks.Decks)
            {
                i.Monitor.PlayerStateChanged += new EventHandler((s, a) => UpdateControl());
                i.Monitor.ErrorTypeMediaFull += new EventHandler((s, a) => UpdateControlError());
                i.Monitor.StorageMediaStateChanged += new EventHandler((s, a) => UpdateControlError());
                i.Monitor.ConnectionStatusChanged += new EventHandler((s, a) => UpdateControlError());
                i.Monitor.ErrorTypeNoInput += new EventHandler((s, a) => UpdateControlError());
                i.Monitor.ErrorTypeRemoteDisabled += new EventHandler((s, a) => UpdateControlError());
            }

            UpdateControl();
            UpdateControlError();
        }

        //Perform an auto transition
        private void button_Click(object sender, EventArgs e)
        {
            switch (_mode)
            {
                case HyperDeckPlayRecordButtonMode.Play:
                    _hyperDecks.Play();
                    break;
                case HyperDeckPlayRecordButtonMode.PlayStop:
                    _hyperDecks.PlayStop();
                    break;
                case HyperDeckPlayRecordButtonMode.Record:
                    _hyperDecks.Record();
                    break;
                case HyperDeckPlayRecordButtonMode.RecordStop:
                    _hyperDecks.RecordStop();
                    break;
                case HyperDeckPlayRecordButtonMode.Stop:
                    _hyperDecks.Stop();
                    break;
           }
        }

        //Update the control to show there is an error
        private void UpdateControlError()
        {
            String error = "";
            foreach (HyperDeck i in _hyperDecks.Decks)
            {
                if (i.Present)
                {
                    Console.WriteLine(i.Number + " :: " + i.StorageMediaCount);
                    if (i.ConnectionStatus != _BMDSwitcherHyperDeckConnectionStatus.bmdSwitcherHyperDeckConnectionStatusConnected) { error += i.Id + " (" + i.Number + ") Connection Failed\n"; }
                    else if (i.StorageState(0) == _BMDSwitcherHyperDeckStorageMediaState.bmdSwitcherHyperDeckStorageMediaStateUnavailable) { error += i.Id + " (" + i.Number + ") Media Unavalible\n"; }
                    else if (i.IsRemoteAccessEnabled == false) { error += i.Id + "(" + i.Number + ") Remote Disabled\n"; }
                    else if (i.SwitcherInput == null) { error += i.Id + "(" + i.Number + ") No Input\n"; }
                }
            }

            if (error != "")
            {
                button.BackColor = Color.Gray;
                button.Text = _id + "\n\n" + error;
            }
            else
            {
                UpdateControl();
            }
        }

        //Update the control
        private void UpdateControl()
        {
            Color colorToSet = Color.White;

            switch(_mode)
            {
                case HyperDeckPlayRecordButtonMode.Play:
                    if (_hyperDecks.AllPlayerState(_BMDSwitcherHyperDeckPlayerState.bmdSwitcherHyperDeckStatePlay)) { colorToSet = Color.Green; }
                    else if (_hyperDecks.AllPlayerState(_BMDSwitcherHyperDeckPlayerState.bmdSwitcherHyperDeckStateIdle)) { colorToSet = Color.White; }
                    else { colorToSet = colorToSet = Color.Yellow; }
                    break;
                case HyperDeckPlayRecordButtonMode.PlayStop:
                    if (_hyperDecks.AllPlayerState(_BMDSwitcherHyperDeckPlayerState.bmdSwitcherHyperDeckStatePlay)) { colorToSet = Color.Green; }
                    else if (_hyperDecks.AllPlayerState(_BMDSwitcherHyperDeckPlayerState.bmdSwitcherHyperDeckStateIdle)) { colorToSet = Color.White; }
                    else { colorToSet = colorToSet = Color.Yellow; }
                    break;
                case HyperDeckPlayRecordButtonMode.Record:
                    if (_hyperDecks.AllPlayerState(_BMDSwitcherHyperDeckPlayerState.bmdSwitcherHyperDeckStateRecord)) { colorToSet = Color.Red; }
                    else if (_hyperDecks.AllPlayerState(_BMDSwitcherHyperDeckPlayerState.bmdSwitcherHyperDeckStateIdle)) { colorToSet = Color.White; }
                    else { colorToSet = colorToSet = Color.Yellow; }
                    break;
                case HyperDeckPlayRecordButtonMode.RecordStop:
                    if (_hyperDecks.AllPlayerState(_BMDSwitcherHyperDeckPlayerState.bmdSwitcherHyperDeckStateRecord)) { colorToSet = Color.Red; }
                    else if (_hyperDecks.AllPlayerState(_BMDSwitcherHyperDeckPlayerState.bmdSwitcherHyperDeckStateIdle)) { colorToSet = Color.White; }
                    else { colorToSet = colorToSet = Color.Yellow; }
                    break;
                case HyperDeckPlayRecordButtonMode.Stop:
                    if (_hyperDecks.AllPlayerState(_BMDSwitcherHyperDeckPlayerState.bmdSwitcherHyperDeckStateIdle)) { colorToSet = Color.Red; }
                    else if (_hyperDecks.AllPlayerState(_BMDSwitcherHyperDeckPlayerState.bmdSwitcherHyperDeckStatePlay) || _hyperDecks.AllPlayerState(_BMDSwitcherHyperDeckPlayerState.bmdSwitcherHyperDeckStateRecord)) { colorToSet = Color.White; }
                    else { colorToSet = colorToSet = Color.Yellow; }
                    break;
            }

            button.BackColor = colorToSet;
        }
    }
}
