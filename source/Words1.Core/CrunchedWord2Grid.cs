//-----------------------------------------------------------------------
// <copyright file="CrunchedWord2Grid.cs" company="Brian Rogers">
// Copyright (c) Brian Rogers. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Words1
{
    using System;

    public struct CrunchedWord2Grid : IEquatable<CrunchedWord2Grid>, IComparable<CrunchedWord2Grid>
    {
        private readonly SortedTable<Word2>.Index i1;
        private readonly SortedTable<Word2>.Index i2;
        private readonly SortedTable<Word2>.Index i3;
        private readonly SortedTable<Word2>.Index i4;

        public CrunchedWord2Grid(
            SortedTable<Word2>.Index i1,
            SortedTable<Word2>.Index i2,
            SortedTable<Word2>.Index i3,
            SortedTable<Word2>.Index i4)
        {
            this.i1 = i1;
            this.i2 = i2;
            this.i3 = i3;
            this.i4 = i4;
        }

        public bool Equals(CrunchedWord2Grid other)
        {
            return this.CompareTo(other) == 0;
        }

        public int CompareTo(CrunchedWord2Grid other)
        {
            int c = this.i1.CompareTo(other.i1);
            if (c != 0)
            {
                return c;
            }

            c = this.i2.CompareTo(other.i2);
            if (c != 0)
            {
                return c;
            }

            c = this.i3.CompareTo(other.i3);
            if (c != 0)
            {
                return c;
            }

            return this.i4.CompareTo(other.i4);
        }
    }
}
