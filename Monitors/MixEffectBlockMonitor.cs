using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BMDSwitcherAPI;

namespace ATEMVisionSwitcher
{
    public class MixEffectBlockMonitor : IBMDSwitcherMixEffectBlockCallback
    {
        public void PropertyChanged(_BMDSwitcherMixEffectBlockPropertyId propertyId)
        {
            throw new NotImplementedException();
        }
    }
}
