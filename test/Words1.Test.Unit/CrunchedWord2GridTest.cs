//-----------------------------------------------------------------------
// <copyright file="CrunchedWord2GridTest.cs" company="Brian Rogers">
// Copyright (c) Brian Rogers. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Words1.Test.Unit
{
    using System;
    using Xunit;

    public class CrunchedWord2GridTest
    {
        public CrunchedWord2GridTest()
        {
        }

        [Fact]
        public void Equals_ComparesCorrectly()
        {
            CrunchedWord2Grid grid1 = new CrunchedWord2Grid(Idx(1), Idx(2), Idx(3), Idx(4));
            CrunchedWord2Grid grid2 = new CrunchedWord2Grid(Idx(1), Idx(1), Idx(2), Idx(3));
            CrunchedWord2Grid grid3 = new CrunchedWord2Grid(Idx(1), Idx(1), Idx(1), Idx(2));
            CrunchedWord2Grid grid4 = new CrunchedWord2Grid(Idx(1), Idx(1), Idx(1), Idx(1));

            Assert.True(grid1.Equals(grid1));
            Assert.False(grid1.Equals(grid2));
            Assert.False(grid2.Equals(grid3));
            Assert.False(grid3.Equals(grid4));
            Assert.True(grid4.Equals(grid4));
        }

        [Fact]
        public void CompareTo_ComparesCorrectly()
        {
            CrunchedWord2Grid grid1 = new CrunchedWord2Grid(Idx(1), Idx(2), Idx(3), Idx(4));
            CrunchedWord2Grid grid2 = new CrunchedWord2Grid(Idx(1), Idx(1), Idx(2), Idx(3));
            CrunchedWord2Grid grid3 = new CrunchedWord2Grid(Idx(1), Idx(1), Idx(1), Idx(2));
            CrunchedWord2Grid grid4 = new CrunchedWord2Grid(Idx(1), Idx(1), Idx(1), Idx(1));

            Assert.True(grid1.CompareTo(grid1) == 0);
            Assert.True(grid1.CompareTo(grid2) > 0);
            Assert.True(grid2.CompareTo(grid1) < 0);
            Assert.True(grid2.CompareTo(grid3) > 0);
            Assert.True(grid3.CompareTo(grid4) > 0);
            Assert.True(grid4.CompareTo(grid4) == 0);
        }

        private static SortedTable<Word2>.Index Idx(short index)
        {
            return new SortedTable<Word2>.Index(index);
        }
    }
}
