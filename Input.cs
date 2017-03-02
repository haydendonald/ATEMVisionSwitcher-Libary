using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATEMVisionSwitcher
{
    public abstract class Input
    {
        private long _id;
        private String _shortName;
        private String _longName;

        //Properties
        public String ShortName
        {
            get { return _shortName; }
            set { _shortName = value; }
        }

        public String LongName
        {
            get { return _longName; }
            set { _longName = value; }
        }

        public long Id
        {
            get { return _id; }
            set { _id = value; }
        }
    }
}
