//-----------------------------------------------------------------------
// <copyright file="Word4Loader.cs" company="Brian Rogers">
// Copyright (c) Brian Rogers. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Words1
{
    using System;

    public static class Word4Loader
    {
        private static readonly char[] WhitespaceChars = new char[] { ' ', '\t', '\r', '\n' };

        public static void Load(string line, Action<Word4> onWordFound)
        {
            foreach (string s in line.Split(WhitespaceChars, StringSplitOptions.RemoveEmptyEntries))
            {
                if (s.Length == 4)
                {
                    Word4 word = new Word4(s);
                    onWordFound(word);
                }
            }
        }
    }
}
