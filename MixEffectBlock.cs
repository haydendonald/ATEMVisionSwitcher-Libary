using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BMDSwitcherAPI;

namespace ATEMVisionSwitcher
{
    public class MixEffectBlock
    {
        private IBMDSwitcherMixEffectBlock _meBlock;
        private Inputs _inputs;
        private MixEffectBlockMonitor _monitor;
        private String _id;
        private long _number;
        private DebugConsole Console;

        //Properties
        public IBMDSwitcherMixEffectBlock meBlock { get { return _meBlock; } }
        public String Id { get { return _id; } }
        public long Number { get { return _number; } }
        public MixEffectBlockMonitor Monitor { get { return _monitor; } }

        public Boolean FadeToBlackInTransition { get { return PropertyIdFadeToBlackInTransition == 1; } }
        public Boolean InFadeToBlack { get { return PropertyIdInFadeToBlack == 1; } }
        public Boolean InTransition { get { return PropertyIdInTransition == 1; } }
        public Boolean PreviewLive { get { return PropertyIdPreviewLive == 1; } }
        public Input PreviewInput { get { return _inputs.FindSwitcherInput(PropertyIdPreviewInput); } set { PropertyIdPreviewInput = _inputs.FindSwitcherInput(value); } }
        public Input ProgramInput { get { return _inputs.FindSwitcherInput(PropertyIdProgramInput); } set { PropertyIdProgramInput = _inputs.FindSwitcherInput(value); } }

        //Property Ids
        public long PropertyIdFadeToBlackFramesRemaining
        {
            get
            {
                try
                {
                    long value;
                    _meBlock.GetInt(_BMDSwitcherMixEffectBlockPropertyId.bmdSwitcherMixEffectBlockPropertyIdFadeToBlackFramesRemaining, out value);
                    return value;
                }
                catch(Exception e) { Console.sendError("Could Not Get bmdSwitcherMixEffectBlockPropertyIdFadeToBlackFramesRemaining From Mix Effect Block " + _id); }
                return -1;
            }
        }
        public long PropertyIdFadeToBlackFullyBlack
        {
            get
            {
                try
                {
                    long value;
                    _meBlock.GetInt(_BMDSwitcherMixEffectBlockPropertyId.bmdSwitcherMixEffectBlockPropertyIdFadeToBlackFullyBlack, out value);
                    return value;
                }
                catch (Exception e) { Console.sendError("Could Not Get bmdSwitcherMixEffectBlockPropertyIdFadeToBlackFullyBlack From Mix Effect Block " + _id + " (" + _number + ")\nMore Information\n" + e); }
                return -1;
            }
        }
        public long PropertyIdFadeToBlackInTransition
        {
            get
            {
                try
                {
                    long value;
                    _meBlock.GetInt(_BMDSwitcherMixEffectBlockPropertyId.bmdSwitcherMixEffectBlockPropertyIdFadeToBlackInTransition, out value);
                    return value;
                }
                catch (Exception e) { Console.sendError("Could Not Get bmdSwitcherMixEffectBlockPropertyIdFadeToBlackInTransition From Mix Effect Block " + _id + " (" + _number + ")\nMore Information\n" + e); }
                return -1;
            }
        }
        public long PropertyIdFadeToBlackRate
        {
            get
            {
                try
                {
                    long value;
                    _meBlock.GetInt(_BMDSwitcherMixEffectBlockPropertyId.bmdSwitcherMixEffectBlockPropertyIdFadeToBlackRate, out value);
                    return value;
                }
                catch (Exception e) { Console.sendError("Could Not Get bmdSwitcherMixEffectBlockPropertyIdFadeToBlackRate From Mix Effect Block " + _id + " (" + _number + ")\nMore Information\n" + e); }
                return -1;
            }
        }
        public long PropertyIdInFadeToBlack
        {
            get
            {
                try
                {
                    long value;
                    _meBlock.GetInt(_BMDSwitcherMixEffectBlockPropertyId.bmdSwitcherMixEffectBlockPropertyIdInFadeToBlack, out value);
                    return value;
                }
                catch (Exception e) { Console.sendError("Could Not Get bmdSwitcherMixEffectBlockPropertyIdInFadeToBlack From Mix Effect Block " + _id + " (" + _number + ")\nMore Information\n" + e); }
                return -1;
            }
        }
        public long PropertyIdInputAvailabilityMask
        {
            get
            {
                try
                {
                    long value;
                    _meBlock.GetInt(_BMDSwitcherMixEffectBlockPropertyId.bmdSwitcherMixEffectBlockPropertyIdInputAvailabilityMask, out value);
                    return value;
                }
                catch (Exception e) { Console.sendError("Could Not Get bmdSwitcherMixEffectBlockPropertyIdInputAvailabilityMask From Mix Effect Block " + _id + " (" + _number + ")\nMore Information\n" + e); }
                return -1;
            }
        }
        public long PropertyIdInTransition
        {
            get
            {
                try
                {
                    long value;
                    _meBlock.GetInt(_BMDSwitcherMixEffectBlockPropertyId.bmdSwitcherMixEffectBlockPropertyIdInTransition, out value);
                    return value;
                }
                catch (Exception e) { Console.sendError("Could Not Get bmdSwitcherMixEffectBlockPropertyIdInTransition From Mix Effect Block " + _id + " (" + _number + ")\nMore Information\n" + e); }
                return -1;
            }
        }
        public long PropertyIdPreviewInput
        {
            get
            {
                try
                {
                    long value;
                    _meBlock.GetInt(_BMDSwitcherMixEffectBlockPropertyId.bmdSwitcherMixEffectBlockPropertyIdPreviewInput, out value);
                    return value;
                }
                catch (Exception e) { Console.sendError("Could Not Get Preview Input From Mix Effect Block " + _id + " (" + _number + ")\nMore Information\n" + e); }
                return -1;
            }

            set
            {
                try
                {
                    _meBlock.SetInt(_BMDSwitcherMixEffectBlockPropertyId.bmdSwitcherMixEffectBlockPropertyIdPreviewInput, value);
                }
                catch (Exception e) { Console.sendError("Could Not Set Preview Input On ME " + _id + " (" + _number + ")\nMore Information\n" + e); }
            }
        } 
        public long PropertyIdPreviewLive
        {
            get
            {
                try
                {
                    long value;
                    _meBlock.GetInt(_BMDSwitcherMixEffectBlockPropertyId.bmdSwitcherMixEffectBlockPropertyIdPreviewLive, out value);
                    return value;
                }
                catch (Exception e) { Console.sendError("Could Not Get bmdSwitcherMixEffectBlockPropertyIdPreviewLive From Mix Effect Block " + _id + " (" + _number + ")\nMore Information\n" + e); }
                return -1;
            }
        }
        public long PropertyIdPreviewTransition
        {
            get
            {
                try
                {
                    long value;
                    _meBlock.GetInt(_BMDSwitcherMixEffectBlockPropertyId.bmdSwitcherMixEffectBlockPropertyIdPreviewTransition, out value);
                    return value;
                }
                catch (Exception e) { Console.sendError("Could Not Get bmdSwitcherMixEffectBlockPropertyIdPreviewTransition From Mix Effect Block " + _id + " (" + _number + ")\nMore Information\n" + e); }
                return -1;
            }
        }
        public long PropertyIdProgramInput
        {
            get
            {
                try
                {
                    long value;
                    _meBlock.GetInt(_BMDSwitcherMixEffectBlockPropertyId.bmdSwitcherMixEffectBlockPropertyIdProgramInput, out value);
                    return value;
                }
                catch (Exception e) { Console.sendError("Could Not Get Program Input From Mix Effect Block " + _id + " (" + _number + ")\nMore Information\n" + e); }
                return -1;
            }

            set
            {
                try
                {
                    _meBlock.SetInt(_BMDSwitcherMixEffectBlockPropertyId.bmdSwitcherMixEffectBlockPropertyIdProgramInput, value);
                }
                catch(Exception e) { Console.sendError("Could Not Set Program Input On ME " + _id + " (" + _number + ")\nMore Information\n" + e); }
            }
        }
        public long PropertyIdTransitionFramesRemaining
        {
            get
            {
                try
                {
                    long value;
                    _meBlock.GetInt(_BMDSwitcherMixEffectBlockPropertyId.bmdSwitcherMixEffectBlockPropertyIdTransitionFramesRemaining, out value);
                    return value;
                }
                catch (Exception e) { Console.sendError("Could Not Get bmdSwitcherMixEffectBlockPropertyIdTransitionFramesRemaining From Mix Effect Block " + _id + " (" + _number + ")\nMore Information\n" + e); }
                return -1;
            }
        }
        public long PropertyIdTransitionPosition
        {
            get
            {
                try
                {
                    long value;
                    _meBlock.GetInt(_BMDSwitcherMixEffectBlockPropertyId.bmdSwitcherMixEffectBlockPropertyIdTransitionPosition, out value);
                    return value;
                }
                catch (Exception e) { Console.sendError("Could Not Get bmdSwitcherMixEffectBlockPropertyIdTransitionPosition From Mix Effect Block " + _id + " (" + _number + ")\nMore Information\n" + e); }
                return -1;
            }
        }

        //Constructor
        public MixEffectBlock(DebugConsole console, IBMDSwitcherMixEffectBlock meBlock, Inputs inputs, long number, String id = "")
        {
            Console = console;
            _meBlock = meBlock;
            _id = id;
            _number = number;
            _monitor = new MixEffectBlockMonitor(Console, _id, _number);

            //Add the monitor to the callback
            _meBlock.AddCallback(_monitor);
            _inputs = inputs;
        }

        //Change the program
        public void ChangeProgram(Input input)
        {
            ProgramInput = input;
        }
        public void ChangeProgram(long id)
        {
            ProgramInput = _inputs.FindSwitcherInput(id);
        }

        //Change the preview
        public void ChangePreview(Input input)
        {
            PreviewInput = input;
        }
        public void ChangePreview(long id)
        {
            PreviewInput = _inputs.FindSwitcherInput(id);
        }

        //Get a property id
        public long GetPropertyId(_BMDSwitcherMixEffectBlockPropertyId id)
        {
            long returnValue = -1;
            try
            {
                _meBlock.GetInt(id, out returnValue);
                return -1;
            }
            catch (Exception e) { Console.sendError("Could Not Get Int " + id.ToString() + " On Mix Effect Block " + Id + "\nMore Information:\n" + e); }
            return returnValue;
        }

        //Set a property id
        public Boolean SetPropertyId(_BMDSwitcherMixEffectBlockPropertyId id, long value)
        {
            try
            {
                _meBlock.SetInt(id, value);
                return true;
            }
            catch (Exception e) { Console.sendError("Could Not Set Int " + id.ToString() + " On Mix Effect Block " + Id + "\nMore Information:\n" + e); return false; }
        }

        //Perform an auto transition
        public Boolean PerformAutoTransition()
        {
            try
            {
                _meBlock.PerformAutoTransition();
                Console.sendVerbose("Performed An Auto Transition On Mix Effect Block " + Id);
                return true;
            }
            catch (Exception e) { Console.sendError("Could Not Perform An Auto Transition On Mix Effect Block " + Id + "\nMore Information:\n" + e); return false; }
        }

        //Perform an cut transition
        public Boolean PerformCut()
        {
            try
            {
                _meBlock.PerformCut();
                return true;
            }
            catch (Exception e) { Console.sendError("Could Not Perform Cut On Mix Effect Block " + Id + "\nMore Information:\n" + e); return false; }
        }

        //Perform a fade to black
        public Boolean PerformFadeToBlack()
        {
            try
            {
                _meBlock.PerformFadeToBlack();
                return true;
            }
            catch (Exception e) { Console.sendError("Could Not Perform Fade To Black On Mix Effect Block " + Id + "\nMore Information:\n" + e); return false; }
        }
    }
}
