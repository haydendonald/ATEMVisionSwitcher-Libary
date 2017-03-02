using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BMDSwitcherAPI;

namespace ATEMVisionSwitcher
{
    public class DownstreamKeyerMonitor : IBMDSwitcherDownstreamKeyCallback
    {
        void IBMDSwitcherDownstreamKeyCallback.Notify(_BMDSwitcherDownstreamKeyEventType eventType)
        {
        }
    }
}
