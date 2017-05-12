using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ATEMVisionSwitcher
{
    public partial class KeyerButton : UserControl
    {
        private Color _defaultColor;
        private Color _liveColor;
        private List<Color> _liveMEColor;
        private Color _subColor;
        private List<Keyer> _keyers;
        private String _name;
        private Feeds _feeds;

        public KeyerButton()
        {
            InitializeComponent();
            _keyers = new List<Keyer> { };
        }

        //Set the parameters for the element
        public void SetParameters(String name, Keyer keyer, ATEM_VisionSwitcher switcher)
        {
            _keyers = new List<Keyer> { keyer };
            _name = name;

            _defaultColor = switcher.DefaultColor;
            _liveColor = switcher.LiveColor;
            _liveMEColor = switcher.LiveMEColor;
            _subColor = switcher.SubColor;

            AddEvents();
            SetText();
            UpdateStatus();
        }
        public void SetParameters(String name, List<Keyer> keyers, ATEM_VisionSwitcher switcher)
        {
            _keyers = keyers;
            _name = name;

            _defaultColor = switcher.DefaultColor;
            _liveColor = switcher.LiveColor;
            _liveMEColor = switcher.LiveMEColor;
            _subColor = switcher.SubColor;

            AddEvents();
            SetText();
            UpdateStatus();
        }
        public void SetParameters(String name, Feeds feeds, ATEM_VisionSwitcher switcher)
        {
            _feeds = feeds;
            feeds.SelectedFeedChanged += new EventHandler((s, a) => SelectedFeedChanged());
            _name = name;

            _defaultColor = switcher.DefaultColor;
            _liveColor = switcher.LiveColor;
            _liveMEColor = switcher.LiveMEColor;
            _subColor = switcher.SubColor;

            SelectedFeedChanged();
            AddEvents();
            SetText();
            UpdateStatus();
        }
        public void SetParameters(String name, Feed feed, ATEM_VisionSwitcher switcher)
        {
            _feeds = new Feeds(new List<Feed> { feed });
            _feeds.SelectedFeedChanged += new EventHandler((s, a) => SelectedFeedChanged());
            _name = name;

            _defaultColor = switcher.DefaultColor;
            _liveColor = switcher.LiveColor;
            _liveMEColor = switcher.LiveMEColor;
            _subColor = switcher.SubColor;

            AddEvents();
            SelectedFeedChanged();
            SetText();
            UpdateStatus();
        }

        //Selected feed has changed
        public void SelectedFeedChanged()
        {
            UpdateKeyers(_feeds.SelectedFeed.Keyers);
        }

        //Add the events
        private void AddEvents()
        {
            AddKeyerEvents();
        }

        //Update the mix effect blocks
        private void AddKeyerEvents()
        {
            //Mix effect block events
            foreach (Keyer i in _keyers)
            {
                if(i.GetType() == typeof(UpstreamKeyer))
                {
                    //Upstream Keyers
                    ((UpstreamKeyer)i).Monitor.OnAirChanged += new EventHandler((s, a) => UpdateStatus());
                }
                else
                {
                    //Downstream Keyers
                    ((DownstreamKeyer)i).Monitor.OnAirChanged += new EventHandler((s, a) => UpdateStatus());
                }

            }
        }

        //Update the buttons text
        private void SetText()
        {
            button.Text = _name;
        }

        //Update the button's status (backcolor)
        private void UpdateStatus()
        {
            Color colorToSet = _defaultColor;

            int liveOn = 0;
            int index = 0;
            foreach (Keyer i in _keyers)
            {

                //Only 1 ME
                if (_keyers.Count == 1)
                {
                    if (i.OnAir == true) { colorToSet = _liveColor; }
                }

                //Multiple MEs
                else
                {
                    if (liveOn > 0)
                    {
                        if (i.OnAir == true)
                        {
                            liveOn++;

                            //Live on all MEs
                            if (_keyers.Count == liveOn)
                            {
                                colorToSet = _liveColor;
                            }
                            //Live on some
                            else
                            {
                                colorToSet = _subColor;
                            }
                        }
                    }
                    else if (i.OnAir == true)
                    {
                        //Live on a single ME in multiple
                        liveOn++;
                        colorToSet = _liveMEColor[index];
                    }

                    index++;
                }
            }

            button.BackColor = colorToSet;
        }

        //Set the input on the ME(s) preview
        private void button_Click(object sender, EventArgs e)
        {
            int keyerOnAirCount = 0;

            foreach (Keyer i in _keyers) { if (i.OnAir) { keyerOnAirCount++; } }

            if (keyerOnAirCount > 0)
            {
                Boolean set = true;
                if (keyerOnAirCount == _keyers.Count) { set = false; }
                foreach (Keyer i in _keyers) { i.OnAir = set; }
            }
            else
            {
                foreach (Keyer i in _keyers) { i.OnAir = true; }
            }
        }

        //Update the parameters for the element
        public void UpdateKeyers(Keyer keyer)
        {
            _keyers = new List<Keyer> { keyer };
            AddKeyerEvents();
            SetText();
            UpdateStatus();
        }

        //Update the parameters for the element
        public void UpdateKeyers(List<Keyer> keyers)
        {
            _keyers = keyers;
            AddKeyerEvents();
            SetText();
            UpdateStatus();
        }

        //Update the parameters for the element
        public void UpdateKeyers(List<KeyerFeed> keyers)
        {
            _keyers = new List<Keyer> { };
            foreach (KeyerFeed i in keyers)
            {
                if (i.Name == _name)
                {
                    foreach (Keyer j in i.Keyers)
                    {
                        _keyers.Add(j);
                    }
                }
            }

            AddKeyerEvents();
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
                case ATEM_VisionSwitcher.ColorType.Live:
                    _liveColor = color;
                    break;
                case ATEM_VisionSwitcher.ColorType.Sub:
                    _subColor = color;
                    break;
            }
        }

        //Set a custom color
        public void SetCustomColor(ATEM_VisionSwitcher.ColorType colorType, List<Color> color)
        {
            switch (colorType)
            {
                case ATEM_VisionSwitcher.ColorType.LiveME:
                    _liveMEColor = color;
                    break;
            }
        }

    }
}
