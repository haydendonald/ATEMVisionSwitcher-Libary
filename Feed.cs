using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATEMVisionSwitcher
{
    public class Feed
    {
        private String _name;
        private MixEffectBlocks _meBlocks;
        private List<KeyerFeed> _keyers;

        public String Name { get { return _name; } set { _name = value; } }
        public MixEffectBlocks MEBlocks { get { return _meBlocks; } set { _meBlocks = value;} }
        public List<KeyerFeed> Keyers { get { return _keyers; } set { _keyers = value; } }

        //Constructor
        public Feed(String name, MixEffectBlocks meBlocks, List<KeyerFeed> keyers)
        {
            _name = name;
            _meBlocks = meBlocks;
            _keyers = keyers;
        }

        //Constructor
        public Feed(String name, DebugConsole debugConsole, MixEffectBlock meBlock, Keyer keyer)
        {
            _name = name;
            _meBlocks = new MixEffectBlocks(debugConsole, meBlock);
            _keyers = new List<KeyerFeed> { new KeyerFeed("Auto Generated", keyer) };
        }

        //Constructor
        public Feed(String name, DebugConsole debugConsole, MixEffectBlock meBlock, List<KeyerFeed> keyers)
        {
            _name = name;
            _meBlocks = new MixEffectBlocks(debugConsole, meBlock);
            _keyers = keyers;
        }

        //Constructor
        public Feed(String name, DebugConsole debugConsole, MixEffectBlock meBlock, List<Keyer> keyers)
        {
            _name = name;
            _meBlocks = new MixEffectBlocks(debugConsole, meBlock);
            _keyers = new List<KeyerFeed> { new KeyerFeed("Auto Generated", keyers) };
        }

        //Perform an auto transition
        public void PerformAutoTransition()
        {
            _meBlocks.PerformAutoTransition();
        }

        //Perform a cut
        public void PerformCut()
        {
            _meBlocks.PerformCut();
        }

        //Fade to black
        public void PerformFadeToBlack()
        {
            _meBlocks.PerformFadeToBlack();
        }

        public Boolean ProgramInputActive(Input input, MixEffectBlocks meBlocks = null)
        {
            if(meBlocks == null) { meBlocks = _meBlocks; }
            return meBlocks.ProgramInputActive(input);
        }
    }
}
