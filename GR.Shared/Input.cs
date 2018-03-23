﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GR.Shared
{
    public static class Input
    {
        /// <summary>
        /// Parses a line of text to convert to a Person object. Three seperator formats are supported (" | ", ", ", " ")
        /// </summary>
        /// <param name="Input">line of text to parse</param>
        /// <returns>Person object parsed from input</returns>
        public static Record ParseLine(this RecordFactory Factory, string Input)
        {
            // Attempt to split pipe delimited
            string[] pipes = Input.Split(new string[] { " | " }, StringSplitOptions.RemoveEmptyEntries);
            if (pipes.Count() == 5)
            {
                return Factory.GetRecord(pipes);
            }
            else
            {
                // Attempt to split comma delimited
                string[] commas = Input.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
                if (commas.Count() == 5)
                {
                    return Factory.GetRecord(commas);
                }
                else
                {
                    // Attempt to split space delimited
                    string[] spaces = Input.Split(' ');
                    if (spaces.Count() == 5)
                    {
                        return Factory.GetRecord(spaces);
                    }
                    else
                    {
                        // Unable to determine delimiter format
                        throw new FormatException("Unable to determine line format; split did not return 5 elements");
                    }
                }
            }
        }
    }
}
