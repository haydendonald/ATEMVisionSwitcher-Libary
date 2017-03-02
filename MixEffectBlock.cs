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
        private MixEffectBlockMonitor _monitor;
        private List<SwitcherInput> _inputs;
        private long _id;
        private DebugConsole Console;

        //Properties
        public IBMDSwitcherMixEffectBlock meBlock { get { return _meBlock; } }
        public long Id { get { return _id; } }

        public Boolean FadeToBlackInTransition { get { return PropertyIdFadeToBlackInTransition == 1; } }
        public Boolean InFadeToBlack { get { return PropertyIdInFadeToBlack == 1; } }
        public Boolean InTransition { get { return PropertyIdInTransition == 1; } }
        public Boolean PreviewLive { get { return PropertyIdPreviewLive == 1; } }
        public Input PreviewInput { get { try { foreach (Input i in _inputs) { if (i.Id == PropertyIdPreviewInput) { return i; } } } catch (Exception e) { Console.sendError("Could Not Get Preview On Mix Effect Block " + _id + "\nMore Information:\n" + e); } return null;  } }
        public Input ProgramInput { get { try { foreach (Input i in _inputs) { if (i.Id == PropertyIdProgramInput) { return i; } } } catch (Exception e) { Console.sendError("Could Not Get Program On Mix Effect Block " + _id + "\nMore Information:\n" + e); } return null; } }

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
                catch (Exception e) { Console.sendError("Could Not Get bmdSwitcherMixEffectBlockPropertyIdFadeToBlackFullyBlack From Mix Effect Block " + _id); }
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
                catch (Exception e) { Console.sendError("Could Not Get bmdSwitcherMixEffectBlockPropertyIdFadeToBlackInTransition From Mix Effect Block " + _id); }
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
                catch (Exception e) { Console.sendError("Could Not Get bmdSwitcherMixEffectBlockPropertyIdFadeToBlackRate From Mix Effect Block " + _id); }
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
                catch (Exception e) { Console.sendError("Could Not Get bmdSwitcherMixEffectBlockPropertyIdInFadeToBlack From Mix Effect Block " + _id); }
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
                catch (Exception e) { Console.sendError("Could Not Get bmdSwitcherMixEffectBlockPropertyIdInputAvailabilityMask From Mix Effect Block " + _id); }
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
                catch (Exception e) { Console.sendError("Could Not Get bmdSwitcherMixEffectBlockPropertyIdInTransition From Mix Effect Block " + _id); }
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
                catch (Exception e) { Console.sendError("Could Not Get bmdSwitcherMixEffectBlockPropertyIdPreviewInput From Mix Effect Block " + _id); }
                return -1;
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
                catch (Exception e) { Console.sendError("Could Not Get bmdSwitcherMixEffectBlockPropertyIdPreviewLive From Mix Effect Block " + _id); }
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
                catch (Exception e) { Console.sendError("Could Not Get bmdSwitcherMixEffectBlockPropertyIdPreviewTransition From Mix Effect Block " + _id); }
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
                catch (Exception e) { Console.sendError("Could Not Get bmdSwitcherMixEffectBlockPropertyIdProgramInput From Mix Effect Block " + _id); }
                return -1;
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
                catch (Exception e) { Console.sendError("Could Not Get bmdSwitcherMixEffectBlockPropertyIdTransitionFramesRemaining From Mix Effect Block " + _id); }
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
                catch (Exception e) { Console.sendError("Could Not Get bmdSwitcherMixEffectBlockPropertyIdTransitionPosition From Mix Effect Block " + _id); }
                return -1;
            }
        }

        //Constructor
        public MixEffectBlock(DebugConsole console, IBMDSwitcherMixEffectBlock meBlock, List<SwitcherInput> inputs, long id)
        {
            Console = console;
            _meBlock = meBlock;
            _id = id;
            _monitor = new MixEffectBlockMonitor();

            //Add the monitor to the callback
            _meBlock.AddCallback(_monitor);
            _inputs = inputs;
        }

        //Deconstructor
        ~MixEffectBlock()
        {
            try
            {
                _meBlock.RemoveCallback(_monitor);
                _id = -1;
                _meBlock = null;
            }
            catch (Exception e) { Console.sendError("Could Not Release Mix Effect Block " + _id + "\nMore Information:\n" + e); }
        } 

        //Change the program
        public Boolean ChangeProgram(Input input)
        {
            try
            {
                SetPropertyId(_BMDSwitcherMixEffectBlockPropertyId.bmdSwitcherMixEffectBlockPropertyIdProgramInput, input.Id);
                return true;
            }
            catch(Exception e) { Console.sendError("Could Not Change Program Input On Mix Effect Block " + _id + " To Input " + input.LongName + "(" + input.Id + ")\nMore Information:\n" + e); }
            return false;
        }

        //Change the program
        public Boolean ChangePreview(Input input)
        {
            try
            {
                SetPropertyId(_BMDSwitcherMixEffectBlockPropertyId.bmdSwitcherMixEffectBlockPropertyIdPreviewInput, input.Id);
                return true;
            }
            catch (Exception e) { Console.sendError("Could Not Change Preview Input On Mix Effect Block " + _id + " To Input " + input.LongName + "(" + input.Id + ")\nMore Information:\n" + e); }
            return false;
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
            catch (Exception e) { Console.sendError("Could Not Get Int " + id.ToString() + " On Mix Effect Block " + Id + "\nMore Informationj:\n" + e); }
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
            catch (Exception e) { Console.sendError("Could Not Set Int " + id.ToString() + " On Mix Effect Block " + Id + "\nMore Informationj:\n" + e); return false; }
        }
    }
}
