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
        private DebugConsole Console;
        private String _id;
        private long _number;

        //Constructor
        public MixEffectBlockMonitor(DebugConsole console, String id, long number)
        {
            Console = console;
            id = _id;
            number = _number;

            Console.sendVerbose("Created MixEffectBlockMonitor Object For Mix Effect Block " + id + " (" + number + ")");
        }

        //Events
        public event EventHandler FadeToBlackFramesRemaining;
        public event EventHandler FadeToBlackFullyBlack;
        public event EventHandler FadeToBlackInTransition;
        public event EventHandler FadeToBlackRate;
        public event EventHandler InFadeToBlack;
        public event EventHandler InputAvailabilityMask;
        public event EventHandler InTransition;
        public event EventHandler PreviewInput;
        public event EventHandler PreviewLive;
        public event EventHandler PreviewTransition;
        public event EventHandler ProgramInput;
        public event EventHandler TransitionFramesRemaining;
        public event EventHandler TransitionPosition;

        void IBMDSwitcherMixEffectBlockCallback.PropertyChanged(_BMDSwitcherMixEffectBlockPropertyId propId)
        {
            try
            {
                //Switch the Property Id
                switch (propId)
                {
                    case _BMDSwitcherMixEffectBlockPropertyId.bmdSwitcherMixEffectBlockPropertyIdFadeToBlackFramesRemaining:
                        FadeToBlackFramesRemaining(this, null);
                        break;
                    case _BMDSwitcherMixEffectBlockPropertyId.bmdSwitcherMixEffectBlockPropertyIdFadeToBlackFullyBlack:
                        FadeToBlackFullyBlack(this, null);
                        break;
                    case _BMDSwitcherMixEffectBlockPropertyId.bmdSwitcherMixEffectBlockPropertyIdFadeToBlackInTransition:
                        FadeToBlackInTransition(this, null);
                        break;
                    case _BMDSwitcherMixEffectBlockPropertyId.bmdSwitcherMixEffectBlockPropertyIdFadeToBlackRate:
                        FadeToBlackRate(this, null);
                        break;
                    case _BMDSwitcherMixEffectBlockPropertyId.bmdSwitcherMixEffectBlockPropertyIdInFadeToBlack:
                        InFadeToBlack(this, null);
                        break;
                    case _BMDSwitcherMixEffectBlockPropertyId.bmdSwitcherMixEffectBlockPropertyIdInputAvailabilityMask:
                        InputAvailabilityMask(this, null);
                        break;
                    case _BMDSwitcherMixEffectBlockPropertyId.bmdSwitcherMixEffectBlockPropertyIdInTransition:
                        InTransition(this, null);
                        break;
                    case _BMDSwitcherMixEffectBlockPropertyId.bmdSwitcherMixEffectBlockPropertyIdPreviewInput:
                        PreviewInput(this, null);
                        break;
                    case _BMDSwitcherMixEffectBlockPropertyId.bmdSwitcherMixEffectBlockPropertyIdPreviewLive:
                        PreviewLive(this, null);
                        break;
                    case _BMDSwitcherMixEffectBlockPropertyId.bmdSwitcherMixEffectBlockPropertyIdPreviewTransition:
                        PreviewTransition(this, null);
                        break;
                    case _BMDSwitcherMixEffectBlockPropertyId.bmdSwitcherMixEffectBlockPropertyIdProgramInput:
                        if (ProgramInput != null)
                        {
                            Console.sendVerbose("Program Input Has Changed On ME " + _id + " (" + _number + ")");
                            ProgramInput(this, null);
                        }
                        break;
                    case _BMDSwitcherMixEffectBlockPropertyId.bmdSwitcherMixEffectBlockPropertyIdTransitionFramesRemaining:
                        if (TransitionFramesRemaining != null)
                        {
                            TransitionFramesRemaining(this, null);
                            Console.sendVerbose("Transition Frames Remaining Has Changed On ME " + _id + " (" + _number + ")");
                        }
                        break;
                    case _BMDSwitcherMixEffectBlockPropertyId.bmdSwitcherMixEffectBlockPropertyIdTransitionPosition:
                        if (TransitionPosition != null) { TransitionPosition(this, null); }
                        break;

                }
            }
            catch { }
        }
    }

}
