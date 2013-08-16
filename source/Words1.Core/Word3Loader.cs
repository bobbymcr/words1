//-----------------------------------------------------------------------
// <copyright file="Word3Loader.cs" company="Brian Rogers">
// Copyright (c) Brian Rogers. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Words1
{
    using System;

    public static class Word3Loader
    {
        private static readonly char[] WhitespaceChars = new char[] { ' ', '\t', '\r', '\n' };

        public static void Load(string line, Action<Word3> onWordFound)
        {
            foreach (string s in line.Split(WhitespaceChars, StringSplitOptions.RemoveEmptyEntries))
            {
                if (s.Length == 3)
                {
                    Word3 word = new Word3(s);
                    onWordFound(word);
                }
            }
        }
    }
}
