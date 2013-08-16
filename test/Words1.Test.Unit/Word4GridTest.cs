//-----------------------------------------------------------------------
// <copyright file="Word4GridTest.cs" company="Brian Rogers">
// Copyright (c) Brian Rogers. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Words1.Test.Unit
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Xunit;

    public class Word4GridTest
    {
        public Word4GridTest()
        {
        }

        [Fact]
        public void Construct_FromRows_SetsPropertyValues()
        {
            Word4[] rows = new Word4[] { new Word4("abcd"), new Word4("efgh"), new Word4("ijkl"), new Word4("mnop") };
            Word4Grid grid = new Word4Grid(rows[0], rows[1], rows[2], rows[3]);

            Assert.Equal('a', grid.A00);
            Assert.Equal('b', grid.A01);
            Assert.Equal('c', grid.A02);
            Assert.Equal('d', grid.A03);
            Assert.Equal('e', grid.A10);
            Assert.Equal('f', grid.A11);
            Assert.Equal('g', grid.A12);
            Assert.Equal('h', grid.A13);
            Assert.Equal('i', grid.A20);
            Assert.Equal('j', grid.A21);
            Assert.Equal('k', grid.A22);
            Assert.Equal('l', grid.A23);
            Assert.Equal('m', grid.A30);
            Assert.Equal('n', grid.A31);
            Assert.Equal('o', grid.A32);
            Assert.Equal('p', grid.A33);

            Assert.Equal(rows[0], grid.Row1);
            Assert.Equal(rows[1], grid.Row2);
            Assert.Equal(rows[2], grid.Row3);
            Assert.Equal(rows[3], grid.Row4);

            Assert.Equal(new Word4("aeim"), grid.Column1);
            Assert.Equal(new Word4("bfjn"), grid.Column2);
            Assert.Equal(new Word4("cgko"), grid.Column3);
            Assert.Equal(new Word4("dhlp"), grid.Column4);
        }

        [Fact]
        public void Equals_ComparesCorrectly()
        {
            Word4[] rows = new Word4[] { new Word4("abcd"), new Word4("efgh"), new Word4("ijkl"), new Word4("mnop") };
            Word4Grid grid1a = new Word4Grid(rows[0], rows[1], rows[2], rows[3]);
            Word4Grid grid1b = new Word4Grid(rows[0], rows[1], rows[2], rows[3]);
            Word4Grid grid2 = new Word4Grid(rows[0], rows[1], rows[2], rows[2]);

            Assert.True(grid1a.Equals(grid1b));
            Assert.True(grid1b.Equals(grid1a));
            Assert.False(grid1b.Equals(grid2));
            Assert.False(grid2.Equals(grid1a));
        }

        [Fact]
        public void Transpose_CreatesRowAndColumnSwappedGrid()
        {
            Word4[] rows = new Word4[] { new Word4("abcd"), new Word4("efgh"), new Word4("ijkl"), new Word4("mnop") };
            Word4Grid grid = new Word4Grid(rows[0], rows[1], rows[2], rows[3]);

            Word4Grid gridT = grid.Transpose();

            Assert.Equal(new Word4("aeim"), gridT.Row1);
            Assert.Equal(new Word4("bfjn"), gridT.Row2);
            Assert.Equal(new Word4("cgko"), gridT.Row3);
            Assert.Equal(new Word4("dhlp"), gridT.Row4);
        }

        [Fact]
        public void ToString_OutputsRowsToString()
        {
            Word4Grid grid = new Word4Grid(new Word4("abcd"), new Word4("efgh"), new Word4("ijkl"), new Word4("mnop"));

            Assert.Equal("abcd\r\nefgh\r\nijkl\r\nmnop", grid.ToString());
        }

        [Fact]
        public void WriteBlocks_CallsFuncForEachBlock()
        {
            Word4Grid grid = new Word4Grid(new Word4("abcd"), new Word4("efgh"), new Word4("ijkl"), new Word4("mnop"));

            List<string> blocks = new List<string>();
            grid.WriteBlocks(b => blocks.Add(b));

            Assert.Equal(new string[] { "abcd", "efgh", "ijkl", "mnop" }, blocks.ToArray());
        }
    }
}
