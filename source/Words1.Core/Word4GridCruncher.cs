//-----------------------------------------------------------------------
// <copyright file="Word4GridCruncher.cs" company="Brian Rogers">
// Copyright (c) Brian Rogers. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Words1
{
    using System;

    public class Word4GridCruncher
    {
        private readonly SortedTable<Word4> table;

        public Word4GridCruncher(SortedTable<Word4> table)
        {
            this.table = table;
        }

        public CrunchedWord4Grid Crunch(Word4Grid input)
        {
            SortedTable<Word4>.Index r1 = this.table.Find(input.Row1);
            SortedTable<Word4>.Index r2 = this.table.Find(input.Row2);
            SortedTable<Word4>.Index r3 = this.table.Find(input.Row3);
            SortedTable<Word4>.Index r4 = this.table.Find(input.Row4);
            SortedTable<Word4>.Index c1 = this.table.Find(input.Column1);
            SortedTable<Word4>.Index c2 = this.table.Find(input.Column2);
            SortedTable<Word4>.Index c3 = this.table.Find(input.Column3);
            SortedTable<Word4>.Index c4 = this.table.Find(input.Column4);

            CrunchedWord4Grid crunchedGrid;
            int c = r1.CompareTo(c1);
            if (c == 0)
            {
                c = r2.CompareTo(c2);
                if (c == 0)
                {
                    c = r3.CompareTo(c3);
                }
            }

            if (c > 0)
            {
                crunchedGrid = new CrunchedWord4Grid(c1, c2, c3, c4, r1, r2, r3, r4);
            }
            else
            {
                crunchedGrid = new CrunchedWord4Grid(r1, r2, r3, r4, c1, c2, c3, c4);
            }

            return crunchedGrid;
        }
    }
}
