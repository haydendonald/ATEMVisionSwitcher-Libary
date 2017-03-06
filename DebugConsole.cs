/**
	ATEM Vision Switcher Libary By Hayden Donald 2017
	https://github.com/haydendonald/ATEMVisionSwitcher-Libary

	This libary is repsonsible for the interfacing with the Black Magic ATEM Vision Switcher using the given api
    found at https://www.blackmagicdesign.com/support
*/

using System;

namespace ATEMVisionSwitcher
{
    public class DebugConsole
    {
        public enum DebugLevel { Verbose, Info, Important, Errors, None};

        private DebugLevel _debugLevel;

        //Constructor
        public DebugConsole(DebugLevel debugLevel)
        {
            _debugLevel = debugLevel;
        }       

        public void sendVerbose(String text)
        {
            if (_debugLevel == DebugLevel.Verbose)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("[");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("INFO");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("] " + text);
            }
        }

        public void sendTabInfo(String text)
        {
            if (_debugLevel == DebugLevel.Info || _debugLevel == DebugLevel.Verbose)
            {
                Console.Write("      ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(text);
            }
        }

        public void sendTabVerbose(String text)
        {
            if (_debugLevel == DebugLevel.Verbose)
            {
                Console.Write("      ");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine(text);
            }
        }

        public void sendInfo(String text)
        {
            if (_debugLevel == DebugLevel.Info || _debugLevel == DebugLevel.Verbose)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("[");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("INFO");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("] " + text);
            }
        }

        public void sendError(String text)
        {
            if (_debugLevel != DebugLevel.None)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("[");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("ERROR");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("] " + text);
            }
        }

        public void sendWarning(String text)
        {
            if (_debugLevel != DebugLevel.Errors && _debugLevel != DebugLevel.None)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("[");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("WARN");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("] " + text);
            }
        }
    }
}
