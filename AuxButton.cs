using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ATEMVisionSwitcher
{
    public partial class AuxButton : UserControl
    {
        public enum TextMode { AuxAndInputShort, AuxAndInputLong, AuxLong, AuxShort, InputLong, InputShort };

        private Color _static = Color.White;
        private Color _allLive = Color.Red;
  
        AuxInput _auxInput;
        Input _input;
        TextMode _textMode;

        public AuxButton()
        {
            InitializeComponent();
        }

        //Set the parameters
        public void SetParameters(AuxInput auxInput, Input input, TextMode textMode)
        {
            _auxInput = auxInput;
            _input = input;
            _textMode = textMode;
            UpdateText();
            UpdateColor();
            SetEvents();
        }

        //Set the events
        public void SetEvents()
        { 
            _auxInput.Monitor.InputSourceChanged += new EventHandler((s, a) => UpdateColor());
        }

        //Update the text of the button
        public void UpdateText()
        {
            switch (_textMode)
            {
                case TextMode.AuxAndInputLong:
                    button.Text = _auxInput.LongName + "\n" + _input.LongName;
                    break;
                case TextMode.AuxAndInputShort:
                    button.Text = _auxInput.ShortName + "\n" + _input.ShortName;
                    break;
                case TextMode.AuxLong:
                    button.Text = _auxInput.LongName;
                    break;
                case TextMode.AuxShort:
                    button.Text = _auxInput.ShortName;
                    break;
                case TextMode.InputLong:
                    button.Text = _input.LongName;
                    break;
                case TextMode.InputShort:
                    button.Text = _input.ShortName;
                    break;
            }
        }

        //Update the color according to the status
        public void UpdateColor()
        {
            Color colorToSet = _static;
            if(_input == _auxInput.Input) { colorToSet = _allLive; }
            button.BackColor = colorToSet;
        }

        //Set the aux to an input
        private void button_Click(object sender, EventArgs e)
        {
            _auxInput.Input = _input;
        }
    }
}
