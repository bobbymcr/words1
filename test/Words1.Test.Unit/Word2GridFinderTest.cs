//-----------------------------------------------------------------------
// <copyright file="Word2GridFinderTest.cs" company="Brian Rogers">
// Copyright (c) Brian Rogers. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Words1.Test.Unit
{
    using System;
    using System.Collections.Generic;
    using Xunit;

    public class Word2GridFinderTest
    {
        public Word2GridFinderTest()
        {
        }

        [Fact]
        public void Find_AllowDuplicatesNoMatchesForInputWord_DoesNothing()
        {
            NoMatchesForInputWordInnerTest(true);
        }

        [Fact]
        public void Find_DisallowDuplicatesNoMatchesForInputWord_DoesNothing()
        {
            NoMatchesForInputWordInnerTest(false);
        }

        [Fact]
        public void Find_AllowDuplicatesMatchInputWordButNoOtherWords_DoesNothing()
        {
            MatchInputWordButNoOtherWordsInnerTest(true);
        }

        [Fact]
        public void Find_DisallowDuplicatesMatchInputWordButNoOtherWords_DoesNothing()
        {
            MatchInputWordButNoOtherWordsInnerTest(false);
        }

        [Fact]
        public void Find_AllowDuplicatesMatchesFirstRowAndColumnButNoOtherWords_DoesNothing()
        {
            Word2Trie trie = new Word2Trie();
            trie.Add(new Word2("ab"));
            trie.Add(new Word2("az"));
            Word2GridFinder finder = new Word2GridFinder(trie, true);
            
            int count = 0;
            finder.Find(new Word2("ab"), g => ++count);

            Assert.Equal(0, count);
        }

        [Fact]
        public void Find_AllowDuplicatesMismatchOnLastColumn_DoesNothing()
        {
            MismatchOnLastColumnInnerTest(true);
        }

        [Fact]
        public void Find_DisallowDuplicatesMismatchOnLastColumn_DoesNothing()
        {
            MismatchOnLastColumnInnerTest(false);
        }

        [Fact]
        public void Find_AllowDuplicatesExactlyOneMatchWithTwoWords_ExecutesOnFoundOnce()
        {
            Word2Trie trie = new Word2Trie();
            trie.Add(new Word2("ab"));
            trie.Add(new Word2("bb"));
            Word2GridFinder finder = new Word2GridFinder(trie, true);

            List<Word2Grid> grids = new List<Word2Grid>();
            finder.Find(new Word2("ab"), g => grids.Add(g));

            Assert.Equal(1, grids.Count);
            Assert.Equal(new Word2("ab"), grids[0].Row1);
            Assert.Equal(new Word2("bb"), grids[0].Row2);
        }

        [Fact]
        public void Find_DisallowDuplicatesNoMatchesWithThreeWords_DoesNothing()
        {
            Word2Trie trie = new Word2Trie();
            trie.Add(new Word2("ab"));
            trie.Add(new Word2("ac"));
            trie.Add(new Word2("bc"));
            Word2GridFinder finder = new Word2GridFinder(trie, false);

            int count = 0;
            finder.Find(new Word2("ab"), g => ++count);

            Assert.Equal(0, count);
        }

        [Fact]
        public void Find_DisallowDuplicatesExactlyTwoMatches_ExecutesOnFoundTwice()
        {
            Word2Trie trie = new Word2Trie();
            trie.Add(new Word2("ab"));
            trie.Add(new Word2("ac"));
            trie.Add(new Word2("bd"));
            trie.Add(new Word2("cd"));
            trie.Add(new Word2("ad"));
            trie.Add(new Word2("bc"));
            trie.Add(new Word2("dc"));
            Word2GridFinder finder = new Word2GridFinder(trie, false);

            List<Word2Grid> grids = new List<Word2Grid>();
            finder.Find(new Word2("ab"), g => grids.Add(g));

            Assert.Equal(2, grids.Count);
            Assert.Equal(new Word2("ab"), grids[0].Row1);
            Assert.Equal(new Word2("cd"), grids[0].Row2);
            Assert.Equal(new Word2("ab"), grids[1].Row1);
            Assert.Equal(new Word2("dc"), grids[1].Row2);
        }

        [Fact]
        public void Find_AllowDuplicatesTwoMatchesWithFourWords_ExecutesOnFoundTwice()
        {
            Word2Trie trie = new Word2Trie();
            trie.Add(new Word2("ah"));
            trie.Add(new Word2("am"));
            trie.Add(new Word2("me"));
            trie.Add(new Word2("he"));
            Word2GridFinder finder = new Word2GridFinder(trie, true);

            List<Word2Grid> grids = new List<Word2Grid>();
            finder.Find(new Word2("ah"), g => grids.Add(g));

            Assert.Equal(2, grids.Count);
            Assert.Equal(new Word2("ah"), grids[0].Row1);
            Assert.Equal(new Word2("he"), grids[0].Row2);
            Assert.Equal(new Word2("ah"), grids[1].Row1);
            Assert.Equal(new Word2("me"), grids[1].Row2);
        }

        [Fact]
        public void Find_DisallowDuplicatesExactlyOneMatchWithFourWords_ExecutesOnFoundOnce()
        {
            Word2Trie trie = new Word2Trie();
            trie.Add(new Word2("ah"));
            trie.Add(new Word2("am"));
            trie.Add(new Word2("me"));
            trie.Add(new Word2("he"));
            Word2GridFinder finder = new Word2GridFinder(trie, false);

            List<Word2Grid> grids = new List<Word2Grid>();
            finder.Find(new Word2("ah"), g => grids.Add(g));

            Assert.Equal(1, grids.Count);
            Assert.Equal(new Word2("ah"), grids[0].Row1);
            Assert.Equal(new Word2("me"), grids[0].Row2);
        }

        private static void NoMatchesForInputWordInnerTest(bool allowDuplicateWords)
        {
            Word2Trie trie = new Word2Trie();
            Word2GridFinder finder = new Word2GridFinder(trie, allowDuplicateWords);

            int count = 0;
            finder.Find(new Word2("ab"), g => ++count);

            Assert.Equal(0, count);
        }

        private static void MatchInputWordButNoOtherWordsInnerTest(bool allowDuplicateWords)
        {
            Word2Trie trie = new Word2Trie();
            trie.Add(new Word2("ab"));
            Word2GridFinder finder = new Word2GridFinder(trie, allowDuplicateWords);

            int count = 0;
            finder.Find(new Word2("ab"), g => ++count);

            Assert.Equal(0, count);
        }

        private static void MismatchOnLastColumnInnerTest(bool allowDuplicateWords)
        {
            Word2Trie trie = new Word2Trie();
            trie.Add(new Word2("ah"));
            trie.Add(new Word2("am"));
            trie.Add(new Word2("me"));
            Word2GridFinder finder = new Word2GridFinder(trie, allowDuplicateWords);

            int count = 0;
            finder.Find(new Word2("ah"), g => ++count);

            Assert.Equal(0, count);
        }
    }
}
