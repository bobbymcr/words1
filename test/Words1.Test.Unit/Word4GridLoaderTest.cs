//-----------------------------------------------------------------------
// <copyright file="Word4GridLoaderTest.cs" company="Brian Rogers">
// Copyright (c) Brian Rogers. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Words1.Test.Unit
{
    using System;
    using System.Collections.Generic;
    using Xunit;

    public class Word4GridLoaderTest
    {
        public Word4GridLoaderTest()
        {
        }

        [Fact]
        public void Load_EmptyString_DoesNothing()
        {
            int count = 0;
            Word4GridLoader.Load(string.Empty, string.Empty, string.Empty, string.Empty, g => ++count);

            Assert.Equal(0, count);
        }

        [Fact]
        public void Load_AllShortWords_DoesNothing()
        {
            int count = 0;
            Word4GridLoader.Load("a aa bbc", "a aa bbc", "a aa bbc", "a aa bbc", g => ++count);

            Assert.Equal(0, count);
        }

        [Fact]
        public void Load_AllLongWords_DoesNothing()
        {
            int count = 0;
            Word4GridLoader.Load("abcde aaaab bbbbbc", "abcde aaaab bbbbbc", "abcde aaaab bbbbbc", "abcde aaaab bbbbbc", g => ++count);

            Assert.Equal(0, count);
        }

        [Fact]
        public void Load_MixOfWords_FindsOnlyValidWord4Grids()
        {
            List<Word4Grid> grids = new List<Word4Grid>();
            string line1 = "  abcde aaaae    abcd bbbbbe cdef defg ddddd ghij   ";
            string line2 = "  abcde aaaae    bcda bbbbbe defc efgd ddddd hijg   ";
            string line3 = "  abcde aaaae    cdab bbbbbe efcd fgde ddddd ijgh   ";
            string line4 = "  abcde aaaae    dabc bbbbbe fcde gdef ddddd jghi   ";
            Word4GridLoader.Load(line1, line2, line3, line4, g => grids.Add(g));

            Assert.Equal(4, grids.Count);
            Assert.Equal(new Word4("abcd"), grids[0].Row1);
            Assert.Equal(new Word4("bcda"), grids[0].Row2);
            Assert.Equal(new Word4("cdab"), grids[0].Row3);
            Assert.Equal(new Word4("dabc"), grids[0].Row4);
            Assert.Equal(new Word4("cdef"), grids[1].Row1);
            Assert.Equal(new Word4("defc"), grids[1].Row2);
            Assert.Equal(new Word4("efcd"), grids[1].Row3);
            Assert.Equal(new Word4("fcde"), grids[1].Row4);
            Assert.Equal(new Word4("defg"), grids[2].Row1);
            Assert.Equal(new Word4("efgd"), grids[2].Row2);
            Assert.Equal(new Word4("fgde"), grids[2].Row3);
            Assert.Equal(new Word4("gdef"), grids[2].Row4);
            Assert.Equal(new Word4("ghij"), grids[3].Row1);
            Assert.Equal(new Word4("hijg"), grids[3].Row2);
            Assert.Equal(new Word4("ijgh"), grids[3].Row3);
            Assert.Equal(new Word4("jghi"), grids[3].Row4);
        }
    }
}
