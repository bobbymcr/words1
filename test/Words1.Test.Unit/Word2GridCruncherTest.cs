//-----------------------------------------------------------------------
// <copyright file="Word2GridCruncherTest.cs" company="Brian Rogers">
// Copyright (c) Brian Rogers. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Words1.Test.Unit
{
    using System;
    using Xunit;

    public class Word2GridCruncherTest
    {
        public Word2GridCruncherTest()
        {
        }

        [Fact]
        public void Crunch_RowsLessThanColumns_ReturnsRowIndexesFirst()
        {
            Word2Grid grid = new Word2Grid(new Word2("ab"), new Word2("ze"));
            SortedTable<Word2> table = new SortedTable<Word2>();
            table.Add(new Word2("ab"));
            table.Add(new Word2("az"));
            table.Add(new Word2("be"));
            table.Add(new Word2("ze"));

            Word2GridCruncher cruncher = new Word2GridCruncher(table);            
            CrunchedWord2Grid crunchedGrid = cruncher.Crunch(grid);

            CrunchedWord2Grid expectedGrid = new CrunchedWord2Grid(Idx(1), Idx(4), Idx(2), Idx(3));
            Assert.Equal(expectedGrid, crunchedGrid);
        }

        [Fact]
        public void Crunch_ColumnsLessThanRows_ReturnsColumnIndexesFirst()
        {
            Word2Grid grid = new Word2Grid(new Word2("zb"), new Word2("ae"));
            SortedTable<Word2> table = new SortedTable<Word2>();
            table.Add(new Word2("ae"));
            table.Add(new Word2("be"));
            table.Add(new Word2("za"));
            table.Add(new Word2("zb"));

            Word2GridCruncher cruncher = new Word2GridCruncher(table);
            CrunchedWord2Grid crunchedGrid = cruncher.Crunch(grid);

            CrunchedWord2Grid expectedGrid = new CrunchedWord2Grid(Idx(3), Idx(2), Idx(4), Idx(1));
            Assert.Equal(expectedGrid, crunchedGrid);
        }

        private static SortedTable<Word2>.Index Idx(short index)
        {
            return new SortedTable<Word2>.Index(index);
        }
    }
}
