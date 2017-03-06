/**
	ATEM Vision Switcher Libary By Hayden Donald 2017
	https://github.com/haydendonald/ATEMVisionSwitcher-Libary

	This libary is repsonsible for the interfacing with the Black Magic ATEM Vision Switcher using the given api
    found at https://www.blackmagicdesign.com/support
*/

using System;

namespace ATEMVisionSwitcher
{
    public interface Input
    {
        //Properties
        String ShortName { get; set; }
        String LongName { get; set; }
        long Id { get; }

        Boolean Release();
    }
}
