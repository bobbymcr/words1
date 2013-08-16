//-----------------------------------------------------------------------
// <copyright file="SortedTable.cs" company="Brian Rogers">
// Copyright (c) Brian Rogers. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Words1
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class SortedTable<T> : IEnumerable<T>
    {
        private readonly List<T> items;

        public SortedTable()
        {
            this.items = new List<T>();
        }

        public int Count
        {
            get { return this.items.Count; }
        }

        public bool Add(T word)
        {
            bool added = false;
            int c = this.items.BinarySearch(word);
            if (c < 0)
            {
                this.items.Insert(~c, word);
                added = true;
            }

            return added;
        }

        public Index Find(T item)
        {
            int c = this.items.BinarySearch(item);
            Index index = new Index();
            if (c >= 0)
            {
                index = new Index((short)(c + 1));
            }

            return index;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this.items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public struct Index : IComparable<Index>, IEquatable<Index>
        {
            private readonly short index;

            public Index(short index)
            {
                this.index = index;
            }

            public bool IsValid
            {
                get { return this.index > 0; }
            }

            public int CompareTo(Index other)
            {
                return this.index.CompareTo(other.index);
            }

            public bool Equals(Index other)
            {
                return this.CompareTo(other) == 0;
            }
        }
    }
}
