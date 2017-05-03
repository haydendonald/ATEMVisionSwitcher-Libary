using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            //Mix effect block events
            foreach(MixEffectBlock i in _mixEffectBlocks)
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
            button.BackColor = DEFAULT_COLOR;

            int liveOn = 0;
            int index = 0;
            foreach (MixEffectBlock i in _mixEffectBlocks)
            {
                if (i.ProgramInput == _input)
                {
                    liveOn++;

                    //If we're only live on one ME set it's color
                    if (liveOn == 1)
                    {
                        button.BackColor = LIVE_ME_COLOR[index];
                    }
                    else
                    {
                        //If we're live on all inputs
                        Console.WriteLine(_mixEffectBlocks.Count);
                        if (liveOn == _mixEffectBlocks.Count)
                        {
                            button.BackColor = LIVE_COLOR;
                        }
                        else
                        {
                            button.BackColor = SUB_COLOR;
                        }
                    }
                }


                index++;
            }
        }
        
        private void button_Click(object sender, EventArgs e)
        {
            foreach(MixEffectBlock i in _mixEffectBlocks)
            {
                i.ProgramInput = _input;
            }
        }
    }
}
