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
    public partial class FeedSelection : UserControl
    {
        private Feeds _feeds;

        //Properties
        [Description("BackColor"), Category("Appearance")]
        public override Color BackColor
        {
            get { return table.BackColor; }
            set { table.BackColor = value; }
        }



        public FeedSelection()
        {
            InitializeComponent();
        }

        //Set the parameters
        public void SetParameters(Feeds feeds)
        {
            _feeds = feeds;
            AddButtons();
        }

        //Add the buttons
        private void AddButtons()
        {
            table.ColumnCount = _feeds.List.Count;

            foreach (Feed i in _feeds.List)
            {
                Button button = new Button();
                button.Text = i.Name;
                button.Dock = DockStyle.Fill;
                button.Click += new EventHandler(ChangeFeed);
                button.Tag = i;
                button.Font = new Font(FontFamily.GenericSansSerif, 8, FontStyle.Bold);
                table.Controls.Add(button);
            }

            UpdateButtons();
        }

        private void ChangeFeed(Object sender, EventArgs agrs)
        {
            _feeds.SelectedFeed = (Feed)((Button)sender).Tag;
            UpdateButtons();
        }

        private void UpdateButtons()
        {
            foreach (var i in table.Controls.OfType<Button>())
            {
                i.BackColor = Color.White;
                if (_feeds.SelectedFeed == i.Tag) { i.BackColor = Color.Yellow; }
            }
        }
    }
}