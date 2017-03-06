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
        private DebugConsole Console;
        private String _id;
        private long _number;

        //Constructor
        public DownstreamKeyerMonitor(DebugConsole console, String id, long number)
        {
            Console = console;
            id = _id;
            _number = number;

            Console.sendVerbose("Created DownstreamKeyerMonitor Object For Mix Effect Block " + id + " (" + number + ")");
        }

        //Events
        public event EventHandler ClipChanged;
        public event EventHandler FramesRemainingChanged;
        public event EventHandler GainChanged;
        public event EventHandler InputCutChanged;
        public event EventHandler InputFillChanged;
        public event EventHandler InverseChanged;
        public event EventHandler TypeInverseChanged;
        public event EventHandler IsAutoTransitioningChanged;
        public event EventHandler IsTransitioningChanged;
        public event EventHandler MaskBottomChanged;
        public event EventHandler MaskedChanged;
        public event EventHandler MaskLeftChanged;
        public event EventHandler MaskRightChanged;
        public event EventHandler MaskTopChanged;
        public event EventHandler OnAirChanged;
        public event EventHandler PreMultipliedChanged;
        public event EventHandler RateChanged;
        public event EventHandler TieChanged;

        void IBMDSwitcherDownstreamKeyCallback.Notify(_BMDSwitcherDownstreamKeyEventType eventType)
        {
            try
            {
                //Switch the event type
                switch (eventType)
                {                 
                    case _BMDSwitcherDownstreamKeyEventType.bmdSwitcherDownstreamKeyEventTypeClipChanged:
                        if (ClipChanged != null)
                        {
                            Console.sendVerbose("Clip Changed Has Changed On Downstream Keyer " + _id + " (" + _number + ")");
                            ClipChanged(this, null);
                        }
                        break;
                    case _BMDSwitcherDownstreamKeyEventType.bmdSwitcherDownstreamKeyEventTypeFramesRemainingChanged:
                        if (FramesRemainingChanged != null)
                        {
                            Console.sendVerbose("Frames Remaining Has Changed On Downstream Keyer " + _id + " (" + _number + ")");
                            FramesRemainingChanged(this, null);
                        }
                        break;
                    case _BMDSwitcherDownstreamKeyEventType.bmdSwitcherDownstreamKeyEventTypeGainChanged:
                        if (GainChanged != null)
                        {
                            Console.sendVerbose("Gain Has Changed On Downstream Keyer " + _id + " (" + _number + ")");
                            GainChanged(this, null);
                        }
                        break;
                    case _BMDSwitcherDownstreamKeyEventType.bmdSwitcherDownstreamKeyEventTypeInputCutChanged:
                        if (InputCutChanged != null)
                        {
                            Console.sendVerbose("Input Cut Has Changed On Downstream Keyer " + _id + " (" + _number + ")");
                            InputCutChanged(this, null);
                        }
                        break;
                    case _BMDSwitcherDownstreamKeyEventType.bmdSwitcherDownstreamKeyEventTypeInputFillChanged:
                        if (InputFillChanged != null)
                        {
                            Console.sendVerbose("Input Fill Has Changed On Downstream Keyer " + _id + " (" + _number + ")");
                            InputFillChanged(this, null);
                        }
                        break;
                    case _BMDSwitcherDownstreamKeyEventType.bmdSwitcherDownstreamKeyEventTypeInverseChanged:
                        if (TypeInverseChanged != null)
                        {
                            Console.sendVerbose("Inverse Changed Has Changed On Downstream Keyer " + _id + " (" + _number + ")");
                            TypeInverseChanged(this, null);
                        }
                        break;
                    case _BMDSwitcherDownstreamKeyEventType.bmdSwitcherDownstreamKeyEventTypeIsAutoTransitioningChanged:
                        if (IsAutoTransitioningChanged != null)
                        {
                            Console.sendVerbose("Is Auto Teansitioning Has Changed On Downstream Keyer " + _id + " (" + _number + ")");
                            IsAutoTransitioningChanged(this, null);
                        }
                        break;
                    case _BMDSwitcherDownstreamKeyEventType.bmdSwitcherDownstreamKeyEventTypeIsTransitioningChanged:
                        if (IsTransitioningChanged != null)
                        {
                            Console.sendVerbose("Is Transitioning Has Changed On Downstream Keyer " + _id + " (" + _number + ")");
                            IsTransitioningChanged(this, null);
                        }
                        break;
                    case _BMDSwitcherDownstreamKeyEventType.bmdSwitcherDownstreamKeyEventTypeMaskBottomChanged:
                        if (MaskBottomChanged != null)
                        {
                            Console.sendVerbose("Mask Bottom Has Changed On Downstream Keyer " + _id + " (" + _number + ")");
                            MaskBottomChanged(this, null);
                        }
                        break;
                    case _BMDSwitcherDownstreamKeyEventType.bmdSwitcherDownstreamKeyEventTypeMaskedChanged:
                        if (MaskedChanged != null)
                        {
                            Console.sendVerbose("Masked Has Changed On Downstream Keyer " + _id + " (" + _number + ")");
                            MaskedChanged(this, null);
                        }
                        break;
                    case _BMDSwitcherDownstreamKeyEventType.bmdSwitcherDownstreamKeyEventTypeMaskLeftChanged:
                        if (MaskLeftChanged != null)
                        {
                            Console.sendVerbose("Mask Left Has Changed On Downstream Keyer " + _id + " (" + _number + ")");
                            MaskLeftChanged(this, null);
                        }
                        break;
                    case _BMDSwitcherDownstreamKeyEventType.bmdSwitcherDownstreamKeyEventTypeMaskRightChanged:
                        if (MaskRightChanged != null)
                        {
                            Console.sendVerbose("Mask Right Has Changed On Downstream Keyer " + _id + " (" + _number + ")");
                            MaskRightChanged(this, null);
                        }
                        break;
                    case _BMDSwitcherDownstreamKeyEventType.bmdSwitcherDownstreamKeyEventTypeMaskTopChanged:
                        if (MaskTopChanged != null)
                        {
                            Console.sendVerbose("Mask Top Has Changed On Downstream Keyer " + _id + " (" + _number + ")");
                            MaskTopChanged(this, null);
                        }
                        break;
                    case _BMDSwitcherDownstreamKeyEventType.bmdSwitcherDownstreamKeyEventTypeOnAirChanged:
                        if (OnAirChanged != null)
                        {
                            Console.sendVerbose("On Air Has Changed On Downstream Keyer " + _id + " (" + _number + ")");
                            OnAirChanged(this, null);
                        }
                        break;
                    case _BMDSwitcherDownstreamKeyEventType.bmdSwitcherDownstreamKeyEventTypePreMultipliedChanged:
                        if (PreMultipliedChanged != null)
                        {
                            Console.sendVerbose("Pre Multiplied Has Changed On Downstream Keyer " + _id + " (" + _number + ")");
                            PreMultipliedChanged(this, null);
                        }
                        break;
                    case _BMDSwitcherDownstreamKeyEventType.bmdSwitcherDownstreamKeyEventTypeRateChanged:
                        if (RateChanged != null)
                        {
                            Console.sendVerbose("Rate Has Changed On Downstream Keyer " + _id + " (" + _number + ")");
                            RateChanged(this, null);
                        }
                        break;
                    case _BMDSwitcherDownstreamKeyEventType.bmdSwitcherDownstreamKeyEventTypeTieChanged:
                        if (TieChanged != null)
                        {
                            Console.sendVerbose("Tie Has Changed On Downstream Keyer " + _id + " (" + _number + ")");
                            TieChanged(this, null);
                        }
                        break;
                }
            }
            catch { }
        }
    }
}
