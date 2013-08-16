//-----------------------------------------------------------------------
// <copyright file="Word3GridTest.cs" company="Brian Rogers">
// Copyright (c) Brian Rogers. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Words1.Test.Unit
{
    using System.Collections.Generic;
    using Xunit;

    public class Word3GridTest
    {
        public Word3GridTest()
        {
        }

        [Fact]
        public void Construct_FromRows_SetsPropertyValues()
        {
            Word3[] rows = new Word3[] { new Word3("abc"), new Word3("efg"), new Word3("ijk") };
            Word3Grid grid = new Word3Grid(rows[0], rows[1], rows[2]);

            Assert.Equal('a', grid.A00);
            Assert.Equal('b', grid.A01);
            Assert.Equal('c', grid.A02);
            Assert.Equal('e', grid.A10);
            Assert.Equal('f', grid.A11);
            Assert.Equal('g', grid.A12);
            Assert.Equal('i', grid.A20);
            Assert.Equal('j', grid.A21);
            Assert.Equal('k', grid.A22);

            Assert.Equal(rows[0], grid.Row1);
            Assert.Equal(rows[1], grid.Row2);
            Assert.Equal(rows[2], grid.Row3);

            Assert.Equal(new Word3("aei"), grid.Column1);
            Assert.Equal(new Word3("bfj"), grid.Column2);
            Assert.Equal(new Word3("cgk"), grid.Column3);
        }

        [Fact]
        public void Equals_ComparesCorrectly()
        {
            Word3[] rows = new Word3[] { new Word3("abc"), new Word3("efg"), new Word3("ijk") };
            Word3Grid grid1a = new Word3Grid(rows[0], rows[1], rows[2]);
            Word3Grid grid1b = new Word3Grid(rows[0], rows[1], rows[2]);
            Word3Grid grid2 = new Word3Grid(rows[0], rows[1], rows[1]);

            Assert.True(grid1a.Equals(grid1b));
            Assert.True(grid1b.Equals(grid1a));
            Assert.False(grid1b.Equals(grid2));
            Assert.False(grid2.Equals(grid1a));
        }

        [Fact]
        public void Transpose_CreatesRowAndColumnSwappedGrid()
        {
            Word3[] rows = new Word3[] { new Word3("abc"), new Word3("efg"), new Word3("ijk") };
            Word3Grid grid = new Word3Grid(rows[0], rows[1], rows[2]);

            Word3Grid gridT = grid.Transpose();

            Assert.Equal(new Word3("aei"), gridT.Row1);
            Assert.Equal(new Word3("bfj"), gridT.Row2);
            Assert.Equal(new Word3("cgk"), gridT.Row3);
        }

        [Fact]
        public void ToString_OutputsRowsToString()
        {
            Word3Grid grid = new Word3Grid(new Word3("abc"), new Word3("efg"), new Word3("ijk"));

            Assert.Equal("abc\r\nefg\r\nijk", grid.ToString());
        }

        [Fact]
        public void WriteBlocks_CallsFuncForEachBlock()
        {
            Word3Grid grid = new Word3Grid(new Word3("abc"), new Word3("efg"), new Word3("ijk"));

            List<string> blocks = new List<string>();
            grid.WriteBlock(b => blocks.Add(b));

            Assert.Equal(new string[] { "abc", "efg", "ijk" }, blocks.ToArray());
        }
    }
}
