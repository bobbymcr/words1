//-----------------------------------------------------------------------
// <copyright file="Word4LoaderTest.cs" company="Brian Rogers">
// Copyright (c) Brian Rogers. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Words1.Test.Unit
{
    using System;
    using System.Collections.Generic;
    using Xunit;

    public class Word4LoaderTest
    {
        public Word4LoaderTest()
        {
        }

        [Fact]
        public void Load_EmptyString_DoesNothing()
        {
            int count = 0;
            Word4Loader.Load(string.Empty, w => ++count);

            Assert.Equal(0, count);
        }

        [Fact]
        public void Load_AllShortWords_DoesNothing()
        {
            int count = 0;
            Word4Loader.Load("a aa bbc", w => ++count);

            Assert.Equal(0, count);
        }

        [Fact]
        public void Load_AllLongWords_DoesNothing()
        {
            int count = 0;
            Word4Loader.Load("abcde aaaab bbbbbc", w => ++count);

            Assert.Equal(0, count);
        }

        [Fact]
        public void Load_MixOfWords_FindsOnlyValidWord4ItemsSeparateByWhitespace()
        {
            List<string> words = new List<string>();
            Word4Loader.Load("  abcde aaaae    abcd bbbbbe cdef\tdefg\rddddd\nghij   ", w => words.Add(w.ToString()));

            Assert.Equal(4, words.Count);
            Assert.Equal("abcd", words[0]);
            Assert.Equal("cdef", words[1]);
            Assert.Equal("defg", words[2]);
            Assert.Equal("ghij", words[3]);
        }
    }
}
