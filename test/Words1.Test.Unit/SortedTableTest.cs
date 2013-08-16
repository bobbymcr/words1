//-----------------------------------------------------------------------
// <copyright file="SortedTableTest.cs" company="Brian Rogers">
// Copyright (c) Brian Rogers. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Words1.Test.Unit
{
    using System;
    using System.Collections.Generic;
    using Xunit;

    public class SortedTableTest
    {
        public SortedTableTest()
        {
        }

        [Fact]
        public void Add_UpdatesCount()
        {
            SortedTable<int> table = new SortedTable<int>();

            Assert.Equal(0, table.Count);

            table.Add(1);
            Assert.Equal(1, table.Count);

            table.Add(2);
            Assert.Equal(2, table.Count);
        }

        [Fact]
        public void Add_ReturnsTrueIfAddedFalseIfAlreadyPresent()
        {
            SortedTable<int> table = new SortedTable<int>();

            Assert.True(table.Add(1));
            Assert.Equal(1, table.Count);

            Assert.False(table.Add(1));
            Assert.Equal(1, table.Count);

            Assert.True(table.Add(2));
            Assert.Equal(2, table.Count);

            Assert.False(table.Add(2));
            Assert.Equal(2, table.Count);
        }

        [Fact]
        public void Enumerator_Empty_YieldsNothing()
        {
            SortedTable<int> table = new SortedTable<int>();

            int count = 0;
            foreach (int item in table)
            {
                ++count;
            }

            Assert.Equal(0, count);
        }

        [Fact]
        public void Enumerator_YieldsInOrder()
        {
            SortedTable<int> table = new SortedTable<int>();

            table.Add(4);
            table.Add(2);
            table.Add(3);
            table.Add(1);

            List<int> items = new List<int>();
            foreach (int item in table)
            {
                items.Add(item);
            }

            Assert.Equal(new int[] { 1, 2, 3, 4 }, items.ToArray());
        }

        [Fact]
        public void Find_Empty_AlwaysReturnsInvalidIndex()
        {
            SortedTable<int> table = new SortedTable<int>();

            SortedTable<int>.Index index = table.Find(1);
            Assert.False(index.IsValid);

            index = table.Find(2);
            Assert.False(index.IsValid);
        }

        [Fact]
        public void Find_NotEmptyButNotPresent_ReturnsInvalidIndex()
        {
            SortedTable<int> table = new SortedTable<int>();

            table.Add(1);
            table.Add(2);

            SortedTable<int>.Index index = table.Find(3);

            Assert.False(index.IsValid);
        }

        [Fact]
        public void Find_NotEmptyAndPresent_ReturnsValidIndex()
        {
            SortedTable<int> table = new SortedTable<int>();

            table.Add(1);
            table.Add(2);
            table.Add(3);

            SortedTable<int>.Index index = table.Find(3);
            Assert.True(index.IsValid);

            index = table.Find(1);
            Assert.True(index.IsValid);
        }

        [Fact]
        public void Find_ReturnsIndexesWithExpectedOrdering()
        {
            SortedTable<int> table = new SortedTable<int>();

            table.Add(1);
            table.Add(2);
            table.Add(3);

            SortedTable<int>.Index index1 = table.Find(1);
            SortedTable<int>.Index index2 = table.Find(2);
            SortedTable<int>.Index index3 = table.Find(3);

            Assert.True(index1.CompareTo(index1) == 0);
            Assert.True(index1.Equals(index1));
            Assert.False(index1.Equals(index2));
            Assert.True(index1.CompareTo(index2) < 0);
            Assert.True(index1.CompareTo(index3) < 0);
            
            Assert.True(index2.CompareTo(index1) > 0);
            Assert.True(index2.CompareTo(index2) == 0);
            Assert.True(index2.Equals(index2));
            Assert.False(index2.Equals(index3));
            Assert.True(index2.CompareTo(index3) < 0);
            
            Assert.True(index3.CompareTo(index1) > 0);
            Assert.True(index3.CompareTo(index2) > 0);
            Assert.True(index3.CompareTo(index3) == 0);
            Assert.True(index3.Equals(index3));
            Assert.False(index3.Equals(index1));
        }
    }
}
