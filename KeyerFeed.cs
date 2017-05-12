using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATEMVisionSwitcher
{
    public class KeyerFeed
    {
        private List<Keyer> _keyers;
        private String _name;

        //Properties
        public List<Keyer> Keyers { get { return _keyers; } }
        public String Name { get { return _name; } set { _name = value; } }


        //Constructor
        public KeyerFeed(String name, List<Keyer> keyers)
        {
            _name = name;
            _keyers = keyers;
        }
        public KeyerFeed(String name, Keyer keyer)
        {
            _name = name;
            _keyers = new List<Keyer> { keyer };
        }
    }
}
