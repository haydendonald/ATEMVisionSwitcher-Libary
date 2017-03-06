/**
	ATEM Vision Switcher Libary By Hayden Donald 2017
	https://github.com/haydendonald/ATEMVisionSwitcher-Libary

	This libary is repsonsible for the interfacing with the Black Magic ATEM Vision Switcher using the given api
    found at https://www.blackmagicdesign.com/support
*/

using System; 
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
            _id = id;
            _number = number;

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
                        if (FadeToBlackFramesRemaining != null)
                        {
                            Console.sendVerbose("Fade To Black Frames Remaining Has Changed On ME " + _id + " (" + _number + ")");
                            FadeToBlackFramesRemaining(this, null);
                        }
                        break;
                    case _BMDSwitcherMixEffectBlockPropertyId.bmdSwitcherMixEffectBlockPropertyIdFadeToBlackFullyBlack:
                        if (FadeToBlackFullyBlack != null)
                        {
                            Console.sendVerbose("Fade To Black Fully Black Has Changed On ME " + _id + " (" + _number + ")");
                            FadeToBlackFullyBlack(this, null);
                        }
                        break;
                    case _BMDSwitcherMixEffectBlockPropertyId.bmdSwitcherMixEffectBlockPropertyIdFadeToBlackInTransition:
                        if (FadeToBlackInTransition != null)
                        {
                            Console.sendVerbose("Fade To Black In Transition Has Changed On ME " + _id + " (" + _number + ")");
                            FadeToBlackInTransition(this, null);
                        }
                        break;
                    case _BMDSwitcherMixEffectBlockPropertyId.bmdSwitcherMixEffectBlockPropertyIdFadeToBlackRate:
                        if (FadeToBlackRate != null)
                        {
                            Console.sendVerbose("Fade To Black Rate Has Changed On ME " + _id + " (" + _number + ")");
                            FadeToBlackRate(this, null);
                        }
                        break;
                    case _BMDSwitcherMixEffectBlockPropertyId.bmdSwitcherMixEffectBlockPropertyIdInFadeToBlack:
                        if (InFadeToBlack != null)
                        {
                            Console.sendVerbose("In Fade To Black Has Changed On ME " + _id + " (" + _number + ")");
                            FadeToBlackInTransition(this, null);
                        }
                        break;
                    case _BMDSwitcherMixEffectBlockPropertyId.bmdSwitcherMixEffectBlockPropertyIdInputAvailabilityMask:
                        if (InputAvailabilityMask != null)
                        {
                            Console.sendVerbose("Input Availability Mask Has Changed On ME " + _id + " (" + _number + ")");
                            InputAvailabilityMask(this, null);
                        }
                        break;
                    case _BMDSwitcherMixEffectBlockPropertyId.bmdSwitcherMixEffectBlockPropertyIdInTransition:
                        if (InTransition != null)
                        {
                            Console.sendVerbose("In Transition Has Changed On ME " + _id + " (" + _number + ")");
                            InTransition(this, null);
                        }
                        break;
                    case _BMDSwitcherMixEffectBlockPropertyId.bmdSwitcherMixEffectBlockPropertyIdPreviewInput:
                        if (PreviewInput != null)
                        {
                            Console.sendVerbose("Preview Input Has Changed On ME " + _id + " (" + _number + ")");
                            PreviewInput(this, null);
                        }
                        break;
                    case _BMDSwitcherMixEffectBlockPropertyId.bmdSwitcherMixEffectBlockPropertyIdPreviewLive:
                        if (PreviewLive != null)
                        {
                            Console.sendVerbose("Preview Live Has Changed On ME " + _id + " (" + _number + ")");
                            PreviewLive(this, null);
                        }
                        break;
                    case _BMDSwitcherMixEffectBlockPropertyId.bmdSwitcherMixEffectBlockPropertyIdPreviewTransition:
                        if (PreviewTransition != null)
                        {
                            Console.sendVerbose("Preview Transition Has Changed On ME " + _id + " (" + _number + ")");
                            PreviewTransition(this, null);
                        }
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
                        if (TransitionPosition != null)
                        {
                            Console.sendVerbose("Transition Position Has Changed On ME " + _id + " (" + _number + ")");
                            PreviewInput(this, null);
                        }
                        break;
                }
            }
            catch { }
        }
    }

}
