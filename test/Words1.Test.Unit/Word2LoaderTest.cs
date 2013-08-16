//-----------------------------------------------------------------------
// <copyright file="Word2LoaderTest.cs" company="Brian Rogers">
// Copyright (c) Brian Rogers. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Words1.Test.Unit
{
    using System;
    using System.Collections.Generic;
    using Xunit;

    public class Word2LoaderTest
    {
        public Word2LoaderTest()
        {
        }

        [Fact]
        public void Load_EmptyString_DoesNothing()
        {
            int count = 0;
            Word2Loader.Load(string.Empty, w => ++count);

            Assert.Equal(0, count);
        }

        [Fact]
        public void Load_AllShortWords_DoesNothing()
        {
            int count = 0;
            Word2Loader.Load("a b", w => ++count);

            Assert.Equal(0, count);
        }

        [Fact]
        public void Load_AllLongWords_DoesNothing()
        {
            int count = 0;
            Word2Loader.Load("abcd aaaa bbbbb", w => ++count);

            Assert.Equal(0, count);
        }

        [Fact]
        public void Load_MixOfWords_FindsOnlyValidWord2ItemsSeparateByWhitespace()
        {
            List<string> words = new List<string>();
            Word2Loader.Load("  abcd aaaa    ab bbbbb cd\tde\rddddd\ngh   ", w => words.Add(w.ToString()));

            Assert.Equal(4, words.Count);
            Assert.Equal("ab", words[0]);
            Assert.Equal("cd", words[1]);
            Assert.Equal("de", words[2]);
            Assert.Equal("gh", words[3]);
        }
    }
}
