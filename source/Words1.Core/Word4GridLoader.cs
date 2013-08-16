//-----------------------------------------------------------------------
// <copyright file="Word4GridLoader.cs" company="Brian Rogers">
// Copyright (c) Brian Rogers. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Words1
{
    using System;

    public static class Word4GridLoader
    {
        private static readonly char[] SpaceChar = new char[] { ' ' };

        public static void Load(string line1, string line2, string line3, string line4, Action<Word4Grid> onGridFound)
        {
            string[] row1 = line1.Split(SpaceChar, StringSplitOptions.RemoveEmptyEntries);
            string[] row2 = line2.Split(SpaceChar, StringSplitOptions.RemoveEmptyEntries);
            string[] row3 = line3.Split(SpaceChar, StringSplitOptions.RemoveEmptyEntries);
            string[] row4 = line4.Split(SpaceChar, StringSplitOptions.RemoveEmptyEntries);

            int minLength = row1.Length;
            if (row2.Length < minLength)
            {
                minLength = row2.Length;
            }

            if (row3.Length < minLength)
            {
                minLength = row3.Length;
            }

            if (row4.Length < minLength)
            {
                minLength = row4.Length;
            }

            for (int i = 0; i < minLength; ++i)
            {
                if ((row1[i].Length == 4) && (row2[i].Length == 4) && (row3[i].Length == 4) && (row4[i].Length == 4))
                {
                    Word4 wr1 = new Word4(row1[i]);
                    Word4 wr2 = new Word4(row2[i]);
                    Word4 wr3 = new Word4(row3[i]);
                    Word4 wr4 = new Word4(row4[i]);

                    Word4Grid grid = new Word4Grid(wr1, wr2, wr3, wr4);
                    onGridFound(grid);
                }
            }
        }
    }
}
