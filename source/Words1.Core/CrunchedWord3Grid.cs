//-----------------------------------------------------------------------
// <copyright file="CrunchedWord3Grid.cs" company="Brian Rogers">
// Copyright (c) Brian Rogers. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Words1
{
    using System;

    public struct CrunchedWord3Grid : IEquatable<CrunchedWord3Grid>, IComparable<CrunchedWord3Grid>
    {
        private readonly SortedTable<Word3>.Index i1;
        private readonly SortedTable<Word3>.Index i2;
        private readonly SortedTable<Word3>.Index i3;
        private readonly SortedTable<Word3>.Index i4;
        private readonly SortedTable<Word3>.Index i5;
        private readonly SortedTable<Word3>.Index i6;

        public CrunchedWord3Grid(
            SortedTable<Word3>.Index i1,
            SortedTable<Word3>.Index i2,
            SortedTable<Word3>.Index i3,
            SortedTable<Word3>.Index i4,
            SortedTable<Word3>.Index i5,
            SortedTable<Word3>.Index i6)
        {
            this.i1 = i1;
            this.i2 = i2;
            this.i3 = i3;
            this.i4 = i4;
            this.i5 = i5;
            this.i6 = i6;
        }

        public bool Equals(CrunchedWord3Grid other)
        {
            return this.CompareTo(other) == 0;
        }

        public int CompareTo(CrunchedWord3Grid other)
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

            return this.i6.CompareTo(other.i6);
        }
    }
}
