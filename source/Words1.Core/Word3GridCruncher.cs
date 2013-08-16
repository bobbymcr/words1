//-----------------------------------------------------------------------
// <copyright file="Word3GridCruncher.cs" company="Brian Rogers">
// Copyright (c) Brian Rogers. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Words1
{
    using System;

    public class Word3GridCruncher
    {
        private readonly SortedTable<Word3> table;

        public Word3GridCruncher(SortedTable<Word3> table)
        {
            this.table = table;
        }

        public CrunchedWord3Grid Crunch(Word3Grid input)
        {
            SortedTable<Word3>.Index r1 = this.table.Find(input.Row1);
            SortedTable<Word3>.Index r2 = this.table.Find(input.Row2);
            SortedTable<Word3>.Index r3 = this.table.Find(input.Row3);
            SortedTable<Word3>.Index c1 = this.table.Find(input.Column1);
            SortedTable<Word3>.Index c2 = this.table.Find(input.Column2);
            SortedTable<Word3>.Index c3 = this.table.Find(input.Column3);

            CrunchedWord3Grid crunchedGrid;
            int c = r1.CompareTo(c1);
            if (c == 0)
            {
                c = r2.CompareTo(c2);
            }

            if (c > 0)
            {
                crunchedGrid = new CrunchedWord3Grid(c1, c2, c3, r1, r2, r3);
            }
            else
            {
                crunchedGrid = new CrunchedWord3Grid(r1, r2, r3, c1, c2, c3);
            }

            return crunchedGrid;
        }
    }
}
