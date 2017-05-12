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
    public partial class FTBButton : UserControl
    {
        private Feeds _feeds;

        public FTBButton()
        {
            InitializeComponent();
        }

        //Set the parameters
        public void SetParameters(Feed feed)
        {
            _feeds = new Feeds(new List<Feed> { feed });
        }
        public void SetParameters(Feeds feeds)
        {
            _feeds = feeds;
            _feeds.SelectedFeedChanged += new EventHandler((s, a) => UpdateControl());
        }

        //Perform an auto transition
        private void button_Click(object sender, EventArgs e)
        {
            _feeds.SelectedFeed.PerformFadeToBlack();
        }

        //Update the control
        private void UpdateControl()
        {
        }
    }
}
