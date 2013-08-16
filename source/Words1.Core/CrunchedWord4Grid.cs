//-----------------------------------------------------------------------
// <copyright file="CrunchedWord4Grid.cs" company="Brian Rogers">
// Copyright (c) Brian Rogers. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Words1
{
    using System;

    public struct CrunchedWord4Grid : IEquatable<CrunchedWord4Grid>, IComparable<CrunchedWord4Grid>
    {
        private readonly SortedTable<Word4>.Index i1;
        private readonly SortedTable<Word4>.Index i2;
        private readonly SortedTable<Word4>.Index i3;
        private readonly SortedTable<Word4>.Index i4;
        private readonly SortedTable<Word4>.Index i5;
        private readonly SortedTable<Word4>.Index i6;
        private readonly SortedTable<Word4>.Index i7;
        private readonly SortedTable<Word4>.Index i8;

        public CrunchedWord4Grid(
            SortedTable<Word4>.Index i1,
            SortedTable<Word4>.Index i2,
            SortedTable<Word4>.Index i3,
            SortedTable<Word4>.Index i4,
            SortedTable<Word4>.Index i5,
            SortedTable<Word4>.Index i6,
            SortedTable<Word4>.Index i7,
            SortedTable<Word4>.Index i8)
        {
            this.i1 = i1;
            this.i2 = i2;
            this.i3 = i3;
            this.i4 = i4;
            this.i5 = i5;
            this.i6 = i6;
            this.i7 = i7;
            this.i8 = i8;
        }

        public bool Equals(CrunchedWord4Grid other)
        {
            return this.CompareTo(other) == 0;
        }

        public int CompareTo(CrunchedWord4Grid other)
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

            c = this.i4.CompareTo(other.i4);
            if (c != 0)            
            {
                return c;
            }

            c = this.i5.CompareTo(other.i5);
            if (c != 0)
            {
                return c;
            }

            c = this.i6.CompareTo(other.i6);
            if (c != 0)
            {
                return c;
            }

            c = this.i7.CompareTo(other.i7);
            if (c != 0)
            {
                return c;
            }

            return this.i8.CompareTo(other.i8);
        }
    }
}
