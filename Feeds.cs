using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATEMVisionSwitcher
{
    public class Feeds
    {
        private List<Feed> _feeds;
        private Feed _selectedFeed;

        public event EventHandler SelectedFeedChanged;

        //Properties
        public Feed SelectedFeed { get { return _selectedFeed; } set { _selectedFeed = value; if (SelectedFeedChanged != null) { SelectedFeedChanged(this, null); } } }
        public List<Feed> List { get { return _feeds; } }

        //Constructor
        public Feeds(List<Feed> feeds = null)
        {
            if (feeds == null) { _feeds = new List<Feed> { }; }
            else { _feeds = feeds; _selectedFeed = _feeds[0]; }
        }

        //Add feed
        public void AddFeed(Feed feed)
        {
            _feeds.Add(feed);
            _selectedFeed = feed;
        }

        //Remove feed
        public void RemoveFeed(Feed feed)
        {
            _feeds.Remove(feed);
        }

        //Find a feed by id
        public Feed FindFeed(String name)
        {
            foreach(Feed i in _feeds)
            {
                if (i.Name.ToUpper() == name.ToUpper()) { return i; }
            }

            return null;
        }
    }
}
