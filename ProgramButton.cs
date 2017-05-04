using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ATEMVisionSwitcher
{
    public partial class ProgramButton : UserControl
    {
        private Color DEFAULT_COLOR = Color.White;
        private Color SUB_COLOR = Color.Yellow;
        private Color LIVE_COLOR = Color.Red;
        private List<Color> LIVE_ME_COLOR = new List<Color> { Color.Aqua, Color.BlueViolet };

        public enum NameType { Short, Long, Id };

        private SwitcherInput _input;
        private List<MixEffectBlock> _mixEffectBlocks;
        private NameType _nameType;

        public ProgramButton()
        {
            InitializeComponent();
            _mixEffectBlocks = new List<MixEffectBlock> { };
        }

        //Set the parameters for the element
        public void SetParameters(SwitcherInput input, MixEffectBlock mixEffectBlock, NameType nameType = NameType.Short)
        {
            _input = input;
            _mixEffectBlocks = new List<MixEffectBlock> { };
            _mixEffectBlocks.Add(mixEffectBlock);
            _nameType = nameType;

            AddEvents();
            SetText();
            UpdateStatus();
        }

        //Set the parameters for the element
        public void SetParameters(SwitcherInput input, List<MixEffectBlock> mixEffectBlocks, NameType nameType = NameType.Short)
        {
            _input = input;
            _mixEffectBlocks = mixEffectBlocks;
            _nameType = nameType;

            AddEvents();
            SetText();
            UpdateStatus();
        }

        //Set the parameters for the element
        public void SetParameters(List<MixEffectBlock> mixEffectBlocks)
        {
            _mixEffectBlocks = mixEffectBlocks;
            AddEvents();
            SetText();
            UpdateStatus();
        }

        //Update the parameters for the element
        public void UpdateParameters(SwitcherInput input, MixEffectBlock mixEffectBlock, NameType nameType = NameType.Short)
        {
            _input = input;
            _mixEffectBlocks = new List<MixEffectBlock> { };
            _mixEffectBlocks.Add(mixEffectBlock);
            _nameType = nameType;

            UpdateMixEffectBlocks();
            SetText();
            UpdateStatus();
        }

        //Update the parameters for the element
        public void UpdateParameters(SwitcherInput input, List<MixEffectBlock> mixEffectBlocks, NameType nameType = NameType.Short)
        {
            _input = input;
            _mixEffectBlocks = mixEffectBlocks;
            _nameType = nameType;

            UpdateMixEffectBlocks();
            SetText();
            UpdateStatus();
        }

        //Update the parameters for the element
        public void UpdateParameters(List<MixEffectBlock> mixEffectBlocks)
        {
            _mixEffectBlocks = mixEffectBlocks;
            UpdateMixEffectBlocks();
            SetText();
            UpdateStatus();
        }

        //Add the events
        private void AddEvents()
        {
            //Input events
            switch (_nameType)
            {
                case NameType.Long:
                    _input.Monitor.LongNameChanged += new EventHandler((s, a) => SetText());
                    break;
                case NameType.Short:
                    _input.Monitor.ShortNameChanged += new EventHandler((s, a) => SetText());
                    break;
            }

            UpdateMixEffectBlocks();
        }

        //Update the mix effect blocks
        private void UpdateMixEffectBlocks()
        {
            //Mix effect block events
            foreach (MixEffectBlock i in _mixEffectBlocks)
            {
                i.Monitor.ProgramInput += new EventHandler((s, a) => UpdateStatus());
            }
        }

        //Update the buttons text
        private void SetText()
        {
            switch (_nameType)
            {
                case NameType.Id:
                    button.Text = _input.Id.ToString();
                    break;
                case NameType.Long:
                    button.Text = _input.LongName;
                    break;
                case NameType.Short:
                    button.Text = _input.ShortName;
                    break;
            }
        }

        //Update the button's status (backcolor)
        private void UpdateStatus()
        {
            Color colorToSet = DEFAULT_COLOR;

            int liveOn = 0;
            int index = 0;
            foreach (MixEffectBlock i in _mixEffectBlocks)
            {

                //Only 1 ME
                if (_mixEffectBlocks.Count == 1)
                {
                    if (i.ProgramInput == _input) { colorToSet = LIVE_COLOR; }
                }

                //Multiple MEs
                else
                {
                    if (liveOn > 0)
                    {
                        if (i.ProgramInput == _input)
                        {
                            liveOn++;

                            //Live on all MEs
                            if (_mixEffectBlocks.Count == liveOn)
                            {
                                colorToSet = LIVE_COLOR;
                            }
                            //Live on some
                            else
                            {
                                colorToSet = SUB_COLOR;
                            }
                        }
                    }
                    else if (i.ProgramInput == _input)
                    {
                        //Live on a single ME in multiple
                        liveOn++;
                        colorToSet = LIVE_ME_COLOR[index];
                    }

                    index++;
                }
            }

            button.BackColor = colorToSet;
        }
        
        //Set the input on the ME(s) program
        private void button_Click(object sender, EventArgs e)
        {
            foreach(MixEffectBlock i in _mixEffectBlocks)
            {
                i.ProgramInput = _input;
            }
        }
    }
}
