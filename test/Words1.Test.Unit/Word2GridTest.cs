//-----------------------------------------------------------------------
// <copyright file="Word2GridTest.cs" company="Brian Rogers">
// Copyright (c) Brian Rogers. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Words1.Test.Unit
{
    using System.Collections.Generic;
    using Xunit;

    public class Word2GridTest
    {
        public Word2GridTest()
        {
        }

        [Fact]
        public void Construct_FromRows_SetsPropertyValues()
        {
            Word2[] rows = new Word2[] { new Word2("ab"), new Word2("ef") };
            Word2Grid grid = new Word2Grid(rows[0], rows[1]);

            Assert.Equal('a', grid.A00);
            Assert.Equal('b', grid.A01);
            Assert.Equal('e', grid.A10);
            Assert.Equal('f', grid.A11);

            Assert.Equal(rows[0], grid.Row1);
            Assert.Equal(rows[1], grid.Row2);

            Assert.Equal(new Word2("ae"), grid.Column1);
            Assert.Equal(new Word2("bf"), grid.Column2);
        }

        [Fact]
        public void Equals_ComparesCorrectly()
        {
            Word2[] rows = new Word2[] { new Word2("ab"), new Word2("ef") };
            Word2Grid grid1a = new Word2Grid(rows[0], rows[1]);
            Word2Grid grid1b = new Word2Grid(rows[0], rows[1]);
            Word2Grid grid2 = new Word2Grid(rows[1], rows[1]);

            Assert.True(grid1a.Equals(grid1b));
            Assert.True(grid1b.Equals(grid1a));
            Assert.False(grid1b.Equals(grid2));
            Assert.False(grid2.Equals(grid1a));
        }

        [Fact]
        public void Transpose_CreatesRowAndColumnSwappedGrid()
        {
            Word2[] rows = new Word2[] { new Word2("ab"), new Word2("ef") };
            Word2Grid grid = new Word2Grid(rows[0], rows[1]);

            Word2Grid gridT = grid.Transpose();

            Assert.Equal(new Word2("ae"), gridT.Row1);
            Assert.Equal(new Word2("bf"), gridT.Row2);
        }

        [Fact]
        public void ToString_OutputsRowsToString()
        {
            Word2Grid grid = new Word2Grid(new Word2("ab"), new Word2("ef"));

            Assert.Equal("ab\r\nef", grid.ToString());
        }

        [Fact]
        public void WriteBlocks_CallsFuncForEachBlock()
        {
            Word2Grid grid = new Word2Grid(new Word2("ab"), new Word2("ef"));

            List<string> blocks = new List<string>();
            grid.WriteBlock(b => blocks.Add(b));

            Assert.Equal(new string[] { "ab", "ef" }, blocks.ToArray());
        }
    }
}
