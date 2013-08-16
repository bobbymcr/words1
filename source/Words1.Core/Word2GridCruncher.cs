//-----------------------------------------------------------------------
// <copyright file="Word2GridCruncher.cs" company="Brian Rogers">
// Copyright (c) Brian Rogers. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Words1
{
    using System;

    public class Word2GridCruncher
    {
        private readonly SortedTable<Word2> table;

        public Word2GridCruncher(SortedTable<Word2> table)
        {
            this.table = table;
        }

        public CrunchedWord2Grid Crunch(Word2Grid input)
        {
            SortedTable<Word2>.Index r1 = this.table.Find(input.Row1);
            SortedTable<Word2>.Index r2 = this.table.Find(input.Row2);
            SortedTable<Word2>.Index c1 = this.table.Find(input.Column1);
            SortedTable<Word2>.Index c2 = this.table.Find(input.Column2);

            CrunchedWord2Grid crunchedGrid;
            int c = r1.CompareTo(c1);
            if (c > 0)
            {
                crunchedGrid = new CrunchedWord2Grid(c1, c2, r1, r2);
            }
            else
            {
                crunchedGrid = new CrunchedWord2Grid(r1, r2, c1, c2);
            }

            return crunchedGrid;
        }
    }
}
