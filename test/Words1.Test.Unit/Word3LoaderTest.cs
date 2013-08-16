//-----------------------------------------------------------------------
// <copyright file="Word3LoaderTest.cs" company="Brian Rogers">
// Copyright (c) Brian Rogers. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Words1.Test.Unit
{
    using System;
    using System.Collections.Generic;
    using Xunit;

    public class Word3LoaderTest
    {
        public Word3LoaderTest()
        {
        }

        [Fact]
        public void Load_EmptyString_DoesNothing()
        {
            int count = 0;
            Word3Loader.Load(string.Empty, w => ++count);

            Assert.Equal(0, count);
        }

        [Fact]
        public void Load_AllShortWords_DoesNothing()
        {
            int count = 0;
            Word3Loader.Load("a aa bb", w => ++count);

            Assert.Equal(0, count);
        }

        [Fact]
        public void Load_AllLongWords_DoesNothing()
        {
            int count = 0;
            Word3Loader.Load("abcd aaaa bbbbb", w => ++count);

            Assert.Equal(0, count);
        }

        [Fact]
        public void Load_MixOfWords_FindsOnlyValidWord3ItemsSeparateByWhitespace()
        {
            List<string> words = new List<string>();
            Word3Loader.Load("  abcd aaaa    abc bbbbb cde\tdef\rddddd\nghi   ", w => words.Add(w.ToString()));

            Assert.Equal(4, words.Count);
            Assert.Equal("abc", words[0]);
            Assert.Equal("cde", words[1]);
            Assert.Equal("def", words[2]);
            Assert.Equal("ghi", words[3]);
        }
    }
}
