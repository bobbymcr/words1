//-----------------------------------------------------------------------
// <copyright file="Word2Loader.cs" company="Brian Rogers">
// Copyright (c) Brian Rogers. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Words1
{
    using System;

    public static class Word2Loader
    {
        private static readonly char[] WhitespaceChars = new char[] { ' ', '\t', '\r', '\n' };

        public static void Load(string line, Action<Word2> onWordFound)
        {
            foreach (string s in line.Split(WhitespaceChars, StringSplitOptions.RemoveEmptyEntries))
            {
                if (s.Length == 2)
                {
                    Word2 word = new Word2(s);
                    onWordFound(word);
                }
            }
        }
    }
}
