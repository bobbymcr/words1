//-----------------------------------------------------------------------
// <copyright file="Word4GridCruncherTest.cs" company="Brian Rogers">
// Copyright (c) Brian Rogers. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Words1.Test.Unit
{
    using System;
    using Xunit;

    public class Word4GridCruncherTest
    {
        public Word4GridCruncherTest()
        {
        }

        [Fact]
        public void Crunch_RowsLessThanColumns_ReturnsRowIndexesFirst()
        {
            Word4Grid grid = new Word4Grid(new Word4("abcd"), new Word4("zefg"), new Word4("ahij"), new Word4("aklm"));
            SortedTable<Word4> table = new SortedTable<Word4>();
            table.Add(new Word4("abcd"));
            table.Add(new Word4("ahij"));
            table.Add(new Word4("aklm"));
            table.Add(new Word4("azaa"));
            table.Add(new Word4("behk"));
            table.Add(new Word4("cfil"));
            table.Add(new Word4("dgjm"));
            table.Add(new Word4("zefg"));

            Word4GridCruncher cruncher = new Word4GridCruncher(table);            
            CrunchedWord4Grid crunchedGrid = cruncher.Crunch(grid);

            CrunchedWord4Grid expectedGrid = new CrunchedWord4Grid(Idx(1), Idx(8), Idx(2), Idx(3), Idx(4), Idx(5), Idx(6), Idx(7));
            Assert.Equal(expectedGrid, crunchedGrid);
        }

        [Fact]
        public void Crunch_ColumnsLessThanRows_ReturnsColumnIndexesFirst()
        {
            Word4Grid grid = new Word4Grid(new Word4("zbcd"), new Word4("aefg"), new Word4("ahij"), new Word4("aklm"));
            SortedTable<Word4> table = new SortedTable<Word4>();
            table.Add(new Word4("aefg"));
            table.Add(new Word4("ahij"));
            table.Add(new Word4("aklm"));
            table.Add(new Word4("behk"));
            table.Add(new Word4("cfil"));
            table.Add(new Word4("dgjm"));
            table.Add(new Word4("zaaa"));
            table.Add(new Word4("zbcd"));

            Word4GridCruncher cruncher = new Word4GridCruncher(table);
            CrunchedWord4Grid crunchedGrid = cruncher.Crunch(grid);

            CrunchedWord4Grid expectedGrid = new CrunchedWord4Grid(Idx(7), Idx(4), Idx(5), Idx(6), Idx(8), Idx(1), Idx(2), Idx(3));
            Assert.Equal(expectedGrid, crunchedGrid);
        }

        [Fact]
        public void Crunch_FirstColumnAndRowEqualButSecondRowGreater_ReturnsColumnIndexesFirst()
        {
            Word4Grid grid = new Word4Grid(new Word4("abcd"), new Word4("bzzz"), new Word4("caaa"), new Word4("daaa"));
            SortedTable<Word4> table = new SortedTable<Word4>();
            table.Add(new Word4("abcd"));
            table.Add(new Word4("bzaa"));
            table.Add(new Word4("bzzz"));
            table.Add(new Word4("caaa"));
            table.Add(new Word4("czaa"));
            table.Add(new Word4("daaa"));
            table.Add(new Word4("dzaa"));

            Word4GridCruncher cruncher = new Word4GridCruncher(table);
            CrunchedWord4Grid crunchedGrid = cruncher.Crunch(grid);

            CrunchedWord4Grid expectedGrid = new CrunchedWord4Grid(Idx(1), Idx(2), Idx(5), Idx(7), Idx(1), Idx(3), Idx(4), Idx(6));
            Assert.Equal(expectedGrid, crunchedGrid);
        }

        [Fact]
        public void Crunch_FirstColumnAndRowEqualButSecondColumnGreater_ReturnsRowIndexesFirst()
        {
            Word4Grid grid = new Word4Grid(new Word4("abcd"), new Word4("baaa"), new Word4("czaa"), new Word4("dzaa"));
            SortedTable<Word4> table = new SortedTable<Word4>();
            table.Add(new Word4("abcd"));
            table.Add(new Word4("baaa"));
            table.Add(new Word4("bazz"));
            table.Add(new Word4("caaa"));
            table.Add(new Word4("czaa"));
            table.Add(new Word4("daaa"));
            table.Add(new Word4("dzaa"));

            Word4GridCruncher cruncher = new Word4GridCruncher(table);
            CrunchedWord4Grid crunchedGrid = cruncher.Crunch(grid);

            CrunchedWord4Grid expectedGrid = new CrunchedWord4Grid(Idx(1), Idx(2), Idx(5), Idx(7), Idx(1), Idx(3), Idx(4), Idx(6));
            Assert.Equal(expectedGrid, crunchedGrid);
        }

        [Fact]
        public void Crunch_FirstAndSecondColumnAndRowEqualButThirdColumnGreater_ReturnsRowIndexesFirst()
        {
            Word4Grid grid = new Word4Grid(new Word4("abcd"), new Word4("bcde"), new Word4("cdza"), new Word4("deza"));
            SortedTable<Word4> table = new SortedTable<Word4>();
            table.Add(new Word4("abcd"));
            table.Add(new Word4("bcde"));
            table.Add(new Word4("cdza"));
            table.Add(new Word4("cdzz"));
            table.Add(new Word4("deaa"));
            table.Add(new Word4("deza"));

            Word4GridCruncher cruncher = new Word4GridCruncher(table);
            CrunchedWord4Grid crunchedGrid = cruncher.Crunch(grid);

            CrunchedWord4Grid expectedGrid = new CrunchedWord4Grid(Idx(1), Idx(2), Idx(3), Idx(6), Idx(1), Idx(2), Idx(4), Idx(5));
            Assert.Equal(expectedGrid, crunchedGrid);
        }

        [Fact]
        public void Crunch_FirstAndSecondColumnAndRowEqualButThirdRowGreater_ReturnsColumnIndexesFirst()
        {
            Word4Grid grid = new Word4Grid(new Word4("abcd"), new Word4("bcde"), new Word4("cdaz"), new Word4("deaa"));
            SortedTable<Word4> table = new SortedTable<Word4>();
            table.Add(new Word4("abcd"));
            table.Add(new Word4("bcde"));
            table.Add(new Word4("cdaa"));
            table.Add(new Word4("cdaz"));
            table.Add(new Word4("deaa"));
            table.Add(new Word4("deza"));

            Word4GridCruncher cruncher = new Word4GridCruncher(table);
            CrunchedWord4Grid crunchedGrid = cruncher.Crunch(grid);

            CrunchedWord4Grid expectedGrid = new CrunchedWord4Grid(Idx(1), Idx(2), Idx(3), Idx(6), Idx(1), Idx(2), Idx(4), Idx(5));
            Assert.Equal(expectedGrid, crunchedGrid);
        }

        private static SortedTable<Word4>.Index Idx(short index)
        {
            return new SortedTable<Word4>.Index(index);
        }
    }
}
