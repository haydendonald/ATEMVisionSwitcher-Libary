using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ATEMVisionSwitcher
{
    public partial class PreviewButton : UserControl
    {
        public enum NameType { Short, Long, Id };

        private Color _defaultColor;
        private Color _previewColor;
        private List<Color> _previewMEColor;
        private Color _subColor;
        private SwitcherInput _input;
        private MixEffectBlocks _mixEffectBlocks;
        private NameType _nameType;
        private Feeds _feeds;

        public PreviewButton()
        {
            InitializeComponent();
        }

        //Set the parameters for the element
        public void SetParameters(SwitcherInput input, DebugConsole debugConsole, MixEffectBlock mixEffectBlock, ATEM_VisionSwitcher switcher, NameType nameType = NameType.Short)
        {
            _input = input;
            _mixEffectBlocks = new MixEffectBlocks(debugConsole, mixEffectBlock);
            _nameType = nameType;

            _defaultColor = switcher.DefaultColor;
            _previewColor = switcher.PreviewColor;
            _previewMEColor = switcher.PreviewMEColor;
            _subColor = switcher.SubColor;

            AddEvents();
            SetText();
            UpdateStatus();
        }
        public void SetParameters(SwitcherInput input, DebugConsole debugConsole, List<MixEffectBlock> mixEffectBlocks, ATEM_VisionSwitcher switcher, NameType nameType = NameType.Short)
        {
            _input = input;
            _mixEffectBlocks = new MixEffectBlocks(debugConsole, mixEffectBlocks);
            _nameType = nameType;

            _defaultColor = switcher.DefaultColor;
            _previewColor = switcher.PreviewColor;
            _previewMEColor = switcher.PreviewMEColor;
            _subColor = switcher.SubColor;

            AddEvents();
            SetText();
            UpdateStatus();
        }
        public void SetParameters(SwitcherInput input, Feeds feeds, ATEM_VisionSwitcher switcher, NameType nameType = NameType.Short)
        {
            _input = input;
            _feeds = feeds;
            _mixEffectBlocks = _feeds.SelectedFeed.MEBlocks;
            feeds.SelectedFeedChanged += new EventHandler((s, a) => SelectedFeedChanged());
            _nameType = nameType;

            _defaultColor = switcher.DefaultColor;
            _previewColor = switcher.PreviewColor;
            _previewMEColor = switcher.PreviewMEColor;
            _subColor = switcher.SubColor;

            AddEvents();
            SetText();
            UpdateStatus();
        }

        //Update the parameters for the element
        public void UpdateMixEffectBlock(DebugConsole debugConsole, MixEffectBlock mixEffectBlock)
        {
            _mixEffectBlocks = new MixEffectBlocks(debugConsole, mixEffectBlock);
            UpdateMixEffectBlocks();
            SetText();
            UpdateStatus();
        }

        //Update the parameters for the element
        public void UpdateMixEffectBlock(DebugConsole debugConsole, List<MixEffectBlock> mixEffectBlocks)
        {
            _mixEffectBlocks = new MixEffectBlocks(debugConsole, mixEffectBlocks);
            UpdateMixEffectBlocks();
            SetText();
            UpdateStatus();
        }

        //Set a custom color
        public void SetCustomColor(ATEM_VisionSwitcher.ColorType colorType, Color color)
        {
            switch (colorType)
            {
                case ATEM_VisionSwitcher.ColorType.Default:
                    _defaultColor = color;
                    break;
                case ATEM_VisionSwitcher.ColorType.Preview:
                    _previewColor = color;
                    break;
                case ATEM_VisionSwitcher.ColorType.Sub:
                    _subColor = color;
                    break;
            }
        }

        //Selected feed has changed
        public void SelectedFeedChanged()
        {
            UpdateMixEffectBlocks();
        }

        //Set a custom color
        public void SetCustomColor(ATEM_VisionSwitcher.ColorType colorType, List<Color> color)
        {
            switch (colorType)
            {
                case ATEM_VisionSwitcher.ColorType.PreviewME:
                    _previewMEColor = color;
                    break;
            }
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
            foreach (MixEffectBlock i in _mixEffectBlocks.meBlocks)
            {
                i.Monitor.PreviewInput += new EventHandler((s, a) => UpdateStatus());
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
            Color colorToSet = _defaultColor;

            int liveOn = 0;
            int index = 0;
            foreach (MixEffectBlock i in _mixEffectBlocks.meBlocks)
            {
                //Only 1 ME
                if (_mixEffectBlocks.meBlocks.Count == 1)
                {
                    if (i.PreviewInput == _input) { colorToSet = _previewColor; }
                }

                //Multiple MEs
                else
                {
                    if (liveOn > 0)
                    {
                        if (i.PreviewInput == _input)
                        {
                            liveOn++;

                            //Live on all MEs
                            if (_mixEffectBlocks.meBlocks.Count == liveOn)
                            {
                                colorToSet = _previewColor;
                            }
                            //Live on some
                            else
                            {
                                colorToSet = _subColor;
                            }
                        }
                    }
                    else if (i.PreviewInput == _input)
                    {
                        //Live on a single ME in multiple
                        liveOn++;
                        colorToSet = _previewMEColor[index];
                    }

                    index++;
                }
            }

            button.BackColor = colorToSet;
        }
        
        //Set the input on the ME(s) preview
        private void button_Click(object sender, EventArgs e)
        {
            foreach(MixEffectBlock i in _mixEffectBlocks.meBlocks)
            {
                i.PreviewInput = _input;
            }
        }
    }
}
