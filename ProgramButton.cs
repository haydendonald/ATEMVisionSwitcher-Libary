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
    public partial class ProgramButton : UserControl
    {
        public enum NameType { Short, Long, Id };

        private SwitcherInput _input;
        private MixEffectBlock _mixEffectBlock;
        private NameType _nameType;


        public ProgramButton()
        {
            InitializeComponent();
        }

        //Set the parameters for the element
        public void SetParameters(SwitcherInput input, MixEffectBlock mixEffectBlock, NameType nameType = NameType.Short)
        {
            _input = input;
            _mixEffectBlock = mixEffectBlock;
        }

        //Add the events
        private void AddEvents()
        {
            _input.
        }

        //Update the buttons text
        private void SetText()
        {
            switch (_nameType)
            {
                case NameType.Id:
                    button.Text = _input.Id.ToString();
                    break;
                case NameType.Long:
                    button.Text = _input.LongName;
                    break;
                case NameType.Short:
                    button.Text = _input.ShortName;
                    break;
            }
        }

        private void button_Click(object sender, EventArgs e)
        {

        }
    }
}
