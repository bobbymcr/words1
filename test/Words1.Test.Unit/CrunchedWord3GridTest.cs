//-----------------------------------------------------------------------
// <copyright file="CrunchedWord3GridTest.cs" company="Brian Rogers">
// Copyright (c) Brian Rogers. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Words1.Test.Unit
{
    using System;
    using Xunit;

    public class CrunchedWord3GridTest
    {
        public CrunchedWord3GridTest()
        {
        }

        [Fact]
        public void Equals_ComparesCorrectly()
        {
            CrunchedWord3Grid grid1 = new CrunchedWord3Grid(Idx(1), Idx(2), Idx(3), Idx(4), Idx(5), Idx(6));
            CrunchedWord3Grid grid2 = new CrunchedWord3Grid(Idx(1), Idx(1), Idx(2), Idx(3), Idx(4), Idx(5));
            CrunchedWord3Grid grid3 = new CrunchedWord3Grid(Idx(1), Idx(1), Idx(1), Idx(2), Idx(3), Idx(4));
            CrunchedWord3Grid grid4 = new CrunchedWord3Grid(Idx(1), Idx(1), Idx(1), Idx(1), Idx(2), Idx(3));
            CrunchedWord3Grid grid5 = new CrunchedWord3Grid(Idx(1), Idx(1), Idx(1), Idx(1), Idx(1), Idx(2));
            CrunchedWord3Grid grid6 = new CrunchedWord3Grid(Idx(1), Idx(1), Idx(1), Idx(1), Idx(1), Idx(1));

            Assert.True(grid1.Equals(grid1));
            Assert.False(grid1.Equals(grid2));
            Assert.False(grid2.Equals(grid3));
            Assert.False(grid3.Equals(grid4));
            Assert.False(grid4.Equals(grid5));
            Assert.False(grid5.Equals(grid6));
            Assert.True(grid6.Equals(grid6));
        }

        [Fact]
        public void CompareTo_ComparesCorrectly()
        {
            CrunchedWord3Grid grid1 = new CrunchedWord3Grid(Idx(1), Idx(2), Idx(3), Idx(4), Idx(5), Idx(6));
            CrunchedWord3Grid grid2 = new CrunchedWord3Grid(Idx(1), Idx(1), Idx(2), Idx(3), Idx(4), Idx(5));
            CrunchedWord3Grid grid3 = new CrunchedWord3Grid(Idx(1), Idx(1), Idx(1), Idx(2), Idx(3), Idx(4));
            CrunchedWord3Grid grid4 = new CrunchedWord3Grid(Idx(1), Idx(1), Idx(1), Idx(1), Idx(2), Idx(3));
            CrunchedWord3Grid grid5 = new CrunchedWord3Grid(Idx(1), Idx(1), Idx(1), Idx(1), Idx(1), Idx(2));
            CrunchedWord3Grid grid6 = new CrunchedWord3Grid(Idx(1), Idx(1), Idx(1), Idx(1), Idx(1), Idx(1));

            Assert.True(grid1.CompareTo(grid1) == 0);
            Assert.True(grid1.CompareTo(grid2) > 0);
            Assert.True(grid2.CompareTo(grid1) < 0);
            Assert.True(grid2.CompareTo(grid3) > 0);
            Assert.True(grid3.CompareTo(grid4) > 0);
            Assert.True(grid4.CompareTo(grid5) > 0);
            Assert.True(grid5.CompareTo(grid6) > 0);
            Assert.True(grid6.CompareTo(grid6) == 0);
        }

        private static SortedTable<Word3>.Index Idx(short index)
        {
            return new SortedTable<Word3>.Index(index);
        }
    }
}
