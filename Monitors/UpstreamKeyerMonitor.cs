using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BMDSwitcherAPI;

namespace ATEMVisionSwitcher
{
    class UpstreamKeyerMonitor : IBMDSwitcherKeyCallback
    {
        void IBMDSwitcherKeyCallback.Notify(_BMDSwitcherKeyEventType eventType)
        {
        }
    }
}
