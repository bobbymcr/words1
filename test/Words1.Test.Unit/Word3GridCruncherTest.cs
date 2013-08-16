//-----------------------------------------------------------------------
// <copyright file="Word3GridCruncherTest.cs" company="Brian Rogers">
// Copyright (c) Brian Rogers. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Words1.Test.Unit
{
    using System;
    using Xunit;

    public class Word3GridCruncherTest
    {
        public Word3GridCruncherTest()
        {
        }

        [Fact]
        public void Crunch_RowsLessThanColumns_ReturnsRowIndexesFirst()
        {
            Word3Grid grid = new Word3Grid(new Word3("abc"), new Word3("zef"), new Word3("ahi"));
            SortedTable<Word3> table = new SortedTable<Word3>();
            table.Add(new Word3("abc"));
            table.Add(new Word3("ahi"));
            table.Add(new Word3("aza"));
            table.Add(new Word3("beh"));
            table.Add(new Word3("cfi"));
            table.Add(new Word3("zef"));

            Word3GridCruncher cruncher = new Word3GridCruncher(table);            
            CrunchedWord3Grid crunchedGrid = cruncher.Crunch(grid);

            CrunchedWord3Grid expectedGrid = new CrunchedWord3Grid(Idx(1), Idx(6), Idx(2), Idx(3), Idx(4), Idx(5));
            Assert.Equal(expectedGrid, crunchedGrid);
        }

        [Fact]
        public void Crunch_ColumnsLessThanRows_ReturnsColumnIndexesFirst()
        {
            Word3Grid grid = new Word3Grid(new Word3("zbc"), new Word3("aef"), new Word3("ahi"));
            SortedTable<Word3> table = new SortedTable<Word3>();
            table.Add(new Word3("aef"));
            table.Add(new Word3("ahi"));
            table.Add(new Word3("beh"));
            table.Add(new Word3("cfi"));
            table.Add(new Word3("zaa"));
            table.Add(new Word3("zbc"));

            Word3GridCruncher cruncher = new Word3GridCruncher(table);
            CrunchedWord3Grid crunchedGrid = cruncher.Crunch(grid);

            CrunchedWord3Grid expectedGrid = new CrunchedWord3Grid(Idx(5), Idx(3), Idx(4), Idx(6), Idx(1), Idx(2));
            Assert.Equal(expectedGrid, crunchedGrid);
        }

        [Fact]
        public void Crunch_FirstColumnAndRowEqualButSecondRowGreater_ReturnsColumnIndexesFirst()
        {
            Word3Grid grid = new Word3Grid(new Word3("abc"), new Word3("bzz"), new Word3("caa"));
            SortedTable<Word3> table = new SortedTable<Word3>();
            table.Add(new Word3("abc"));
            table.Add(new Word3("bza"));
            table.Add(new Word3("bzz"));
            table.Add(new Word3("caa"));
            table.Add(new Word3("cza"));

            Word3GridCruncher cruncher = new Word3GridCruncher(table);
            CrunchedWord3Grid crunchedGrid = cruncher.Crunch(grid);

            CrunchedWord3Grid expectedGrid = new CrunchedWord3Grid(Idx(1), Idx(2), Idx(5), Idx(1), Idx(3), Idx(4));
            Assert.Equal(expectedGrid, crunchedGrid);
        }

        [Fact]
        public void Crunch_FirstColumnAndRowEqualButSecondColumnGreater_ReturnsRowIndexesFirst()
        {
            Word3Grid grid = new Word3Grid(new Word3("abc"), new Word3("baa"), new Word3("cza"));
            SortedTable<Word3> table = new SortedTable<Word3>();
            table.Add(new Word3("abc"));
            table.Add(new Word3("baa"));
            table.Add(new Word3("baz"));
            table.Add(new Word3("caa"));
            table.Add(new Word3("cza"));

            Word3GridCruncher cruncher = new Word3GridCruncher(table);
            CrunchedWord3Grid crunchedGrid = cruncher.Crunch(grid);

            CrunchedWord3Grid expectedGrid = new CrunchedWord3Grid(Idx(1), Idx(2), Idx(5), Idx(1), Idx(3), Idx(4));
            Assert.Equal(expectedGrid, crunchedGrid);
        }

        private static SortedTable<Word3>.Index Idx(short index)
        {
            return new SortedTable<Word3>.Index(index);
        }
    }
}
