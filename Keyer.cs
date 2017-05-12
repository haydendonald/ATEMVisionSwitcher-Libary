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
    public interface Keyer
    {
        long Number { get; }
        String Id { get; set; }

        _BMDSwitcherInputAvailability CutInputAvailabilityMask { get; }
        _BMDSwitcherInputAvailability FillInputAvailabilityMask { get; }
   
        long InputCut { get; set; }
        long InputFill { get; set; }    
        double MaskBottom { get; set; }
        Boolean Masked { get; set; }
        double MaskLeft { get; set; }
        double MaskRight { get; set; }
        double MaskTop { get; set; }
        Boolean OnAir { get; set; }

        Boolean SetOnAir();
        Boolean TakeOffAir();
        Boolean IsOnAir();
        Boolean Release();
    }
}
