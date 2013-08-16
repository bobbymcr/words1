//-----------------------------------------------------------------------
// <copyright file="CrunchedWord4GridTest.cs" company="Brian Rogers">
// Copyright (c) Brian Rogers. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Words1.Test.Unit
{
    using System;
    using Xunit;

    public class CrunchedWord4GridTest
    {
        public CrunchedWord4GridTest()
        {
        }

        [Fact]
        public void Equals_ComparesCorrectly()
        {
            CrunchedWord4Grid grid1 = new CrunchedWord4Grid(Idx(1), Idx(2), Idx(3), Idx(4), Idx(5), Idx(6), Idx(7), Idx(8));
            CrunchedWord4Grid grid2 = new CrunchedWord4Grid(Idx(1), Idx(1), Idx(2), Idx(3), Idx(4), Idx(5), Idx(6), Idx(7));
            CrunchedWord4Grid grid3 = new CrunchedWord4Grid(Idx(1), Idx(1), Idx(1), Idx(2), Idx(3), Idx(4), Idx(5), Idx(6));
            CrunchedWord4Grid grid4 = new CrunchedWord4Grid(Idx(1), Idx(1), Idx(1), Idx(1), Idx(2), Idx(3), Idx(4), Idx(5));
            CrunchedWord4Grid grid5 = new CrunchedWord4Grid(Idx(1), Idx(1), Idx(1), Idx(1), Idx(1), Idx(2), Idx(3), Idx(4));
            CrunchedWord4Grid grid6 = new CrunchedWord4Grid(Idx(1), Idx(1), Idx(1), Idx(1), Idx(1), Idx(1), Idx(2), Idx(3));
            CrunchedWord4Grid grid7 = new CrunchedWord4Grid(Idx(1), Idx(1), Idx(1), Idx(1), Idx(1), Idx(1), Idx(1), Idx(2));
            CrunchedWord4Grid grid8 = new CrunchedWord4Grid(Idx(1), Idx(1), Idx(1), Idx(1), Idx(1), Idx(1), Idx(1), Idx(1));

            Assert.True(grid1.Equals(grid1));
            Assert.False(grid1.Equals(grid2));
            Assert.False(grid2.Equals(grid3));
            Assert.False(grid3.Equals(grid4));
            Assert.False(grid4.Equals(grid5));
            Assert.False(grid5.Equals(grid6));
            Assert.False(grid6.Equals(grid7));
            Assert.False(grid7.Equals(grid8));
            Assert.True(grid8.Equals(grid8));
        }

        [Fact]
        public void CompareTo_ComparesCorrectly()
        {
            CrunchedWord4Grid grid1 = new CrunchedWord4Grid(Idx(1), Idx(2), Idx(3), Idx(4), Idx(5), Idx(6), Idx(7), Idx(8));
            CrunchedWord4Grid grid2 = new CrunchedWord4Grid(Idx(1), Idx(1), Idx(2), Idx(3), Idx(4), Idx(5), Idx(6), Idx(7));
            CrunchedWord4Grid grid3 = new CrunchedWord4Grid(Idx(1), Idx(1), Idx(1), Idx(2), Idx(3), Idx(4), Idx(5), Idx(6));
            CrunchedWord4Grid grid4 = new CrunchedWord4Grid(Idx(1), Idx(1), Idx(1), Idx(1), Idx(2), Idx(3), Idx(4), Idx(5));
            CrunchedWord4Grid grid5 = new CrunchedWord4Grid(Idx(1), Idx(1), Idx(1), Idx(1), Idx(1), Idx(2), Idx(3), Idx(4));
            CrunchedWord4Grid grid6 = new CrunchedWord4Grid(Idx(1), Idx(1), Idx(1), Idx(1), Idx(1), Idx(1), Idx(2), Idx(3));
            CrunchedWord4Grid grid7 = new CrunchedWord4Grid(Idx(1), Idx(1), Idx(1), Idx(1), Idx(1), Idx(1), Idx(1), Idx(2));
            CrunchedWord4Grid grid8 = new CrunchedWord4Grid(Idx(1), Idx(1), Idx(1), Idx(1), Idx(1), Idx(1), Idx(1), Idx(1));

            Assert.True(grid1.CompareTo(grid1) == 0);
            Assert.True(grid1.CompareTo(grid2) > 0);
            Assert.True(grid2.CompareTo(grid1) < 0);
            Assert.True(grid2.CompareTo(grid3) > 0);
            Assert.True(grid3.CompareTo(grid4) > 0);
            Assert.True(grid4.CompareTo(grid5) > 0);
            Assert.True(grid5.CompareTo(grid6) > 0);
            Assert.True(grid6.CompareTo(grid7) > 0);
            Assert.True(grid7.CompareTo(grid8) > 0);
            Assert.True(grid8.CompareTo(grid7) < 0);
            Assert.True(grid8.CompareTo(grid8) == 0);
        }

        private static SortedTable<Word4>.Index Idx(short index)
        {
            return new SortedTable<Word4>.Index(index);
        }
    }
}
