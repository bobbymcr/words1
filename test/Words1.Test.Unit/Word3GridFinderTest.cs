//-----------------------------------------------------------------------
// <copyright file="Word3GridFinderTest.cs" company="Brian Rogers">
// Copyright (c) Brian Rogers. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Words1.Test.Unit
{
    using System;
    using System.Collections.Generic;
    using Xunit;

    public class Word3GridFinderTest
    {
        public Word3GridFinderTest()
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
        public void Find_AllowDuplicatesMatchesFirstAndSecondRowButNoOtherWords_DoesNothing()
        {
            Word3Trie trie = new Word3Trie();
            trie.Add(new Word3("abc"));
            trie.Add(new Word3("bzz"));
            Word3GridFinder finder = new Word3GridFinder(trie, true);
            
            int count = 0;
            finder.Find(new Word3("abc"), g => ++count);

            Assert.Equal(0, count);
        }

        [Fact]
        public void Find_AllowDuplicatesMatchesFirstSecondAndThirdRowAndColumnsButNoOtherWords_DoesNothing()
        {
            Word3Trie trie = new Word3Trie();
            trie.Add(new Word3("abc"));
            trie.Add(new Word3("bde"));
            trie.Add(new Word3("cde"));
            Word3GridFinder finder = new Word3GridFinder(trie, true);

            int count = 0;
            finder.Find(new Word3("abc"), g => ++count);

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
        public void Find_AllowDuplicatesExactlyOneMatchWithThreeWords_ExecutesOnFoundOnce()
        {
            Word3Trie trie = new Word3Trie();
            trie.Add(new Word3("abc"));
            trie.Add(new Word3("bcd"));
            trie.Add(new Word3("cde"));
            Word3GridFinder finder = new Word3GridFinder(trie, true);

            List<Word3Grid> grids = new List<Word3Grid>();
            finder.Find(new Word3("abc"), g => grids.Add(g));

            Assert.Equal(1, grids.Count);
            Assert.Equal(new Word3("abc"), grids[0].Row1);
            Assert.Equal(new Word3("bcd"), grids[0].Row2);
            Assert.Equal(new Word3("cde"), grids[0].Row3);
        }

        [Fact]
        public void Find_DisallowDuplicatesNoMatchesWithFiveWords_DoesNothing()
        {
            Word3Trie trie = new Word3Trie();
            trie.Add(new Word3("abc"));
            trie.Add(new Word3("abd"));
            trie.Add(new Word3("bcd"));
            trie.Add(new Word3("bce"));
            trie.Add(new Word3("cdg"));
            Word3GridFinder finder = new Word3GridFinder(trie, false);

            int count = 0;
            finder.Find(new Word3("abc"), g => ++count);

            Assert.Equal(0, count);
        }

        [Fact]
        public void Find_DisallowDuplicatesNoMatchesWithFiveWordsMatchingLastRowAndColumn_DoesNothing()
        {
            Word3Trie trie = new Word3Trie();
            trie.Add(new Word3("abc"));
            trie.Add(new Word3("aad"));
            trie.Add(new Word3("aac"));
            trie.Add(new Word3("bad"));
            trie.Add(new Word3("cde"));
            Word3GridFinder finder = new Word3GridFinder(trie, false);

            int count = 0;
            finder.Find(new Word3("abc"), g => ++count);

            Assert.Equal(0, count);
        }

        [Fact]
        public void Find_DisallowDuplicatesNoMatchesWithSixWords_DoesNothing()
        {
            Word3Trie trie = new Word3Trie();
            trie.Add(new Word3("abc"));
            trie.Add(new Word3("abd"));
            trie.Add(new Word3("bcd"));
            trie.Add(new Word3("bce"));
            trie.Add(new Word3("def"));
            trie.Add(new Word3("cdg"));
            Word3GridFinder finder = new Word3GridFinder(trie, false);

            int count = 0;
            finder.Find(new Word3("abc"), g => ++count);

            Assert.Equal(0, count);
        }

        [Fact]
        public void Find_AllowDuplicatesExactlyTwoMatches_ExecutesOnFoundTwice()
        {
            Word3Trie trie = new Word3Trie();
            trie.Add(new Word3("abc"));
            trie.Add(new Word3("bcd"));
            trie.Add(new Word3("cde"));
            trie.Add(new Word3("cdf"));
            Word3GridFinder finder = new Word3GridFinder(trie, true);

            List<Word3Grid> grids = new List<Word3Grid>();
            finder.Find(new Word3("abc"), g => grids.Add(g));

            Assert.Equal(2, grids.Count);
            Assert.Equal(new Word3("abc"), grids[0].Row1);
            Assert.Equal(new Word3("bcd"), grids[0].Row2);
            Assert.Equal(new Word3("cde"), grids[0].Row3);
            Assert.Equal(new Word3("abc"), grids[1].Row1);
            Assert.Equal(new Word3("bcd"), grids[1].Row2);
            Assert.Equal(new Word3("cdf"), grids[1].Row3);
        }

        [Fact]
        public void Find_DisallowDuplicatesExactlyTwoMatches_ExecutesOnFoundTwice()
        {
            Word3Trie trie = new Word3Trie();
            trie.Add(new Word3("abc"));
            trie.Add(new Word3("abd"));
            trie.Add(new Word3("bcd"));
            trie.Add(new Word3("bce"));
            trie.Add(new Word3("cdf"));
            trie.Add(new Word3("def"));
            trie.Add(new Word3("cdg"));
            trie.Add(new Word3("deg"));
            Word3GridFinder finder = new Word3GridFinder(trie, false);

            List<Word3Grid> grids = new List<Word3Grid>();
            finder.Find(new Word3("abc"), g => grids.Add(g));

            Assert.Equal(2, grids.Count);
            Assert.Equal(new Word3("abc"), grids[0].Row1);
            Assert.Equal(new Word3("bcd"), grids[0].Row2);
            Assert.Equal(new Word3("def"), grids[0].Row3);
            Assert.Equal(new Word3("abc"), grids[1].Row1);
            Assert.Equal(new Word3("bcd"), grids[1].Row2);
            Assert.Equal(new Word3("deg"), grids[1].Row3);
        }

        [Fact]
        public void Find_AllowDuplicatesExactlyOneMatchWithSixWords_ExecutesOnFoundOnce()
        {
            FindOneMatchSixWordsInnerTest(true);
        }

        [Fact]
        public void Find_DisallowDuplicatesExactlyOneMatchWithSixWords_ExecutesOnFoundOnce()
        {
            FindOneMatchSixWordsInnerTest(false);
        }

        private static void NoMatchesForInputWordInnerTest(bool allowDuplicateWords)
        {
            Word3Trie trie = new Word3Trie();
            Word3GridFinder finder = new Word3GridFinder(trie, allowDuplicateWords);

            int count = 0;
            finder.Find(new Word3("abc"), g => ++count);

            Assert.Equal(0, count);
        }

        private static void MatchInputWordButNoOtherWordsInnerTest(bool allowDuplicateWords)
        {
            Word3Trie trie = new Word3Trie();
            trie.Add(new Word3("abc"));
            Word3GridFinder finder = new Word3GridFinder(trie, allowDuplicateWords);

            int count = 0;
            finder.Find(new Word3("abc"), g => ++count);

            Assert.Equal(0, count);
        }

        private static void MismatchOnLastColumnInnerTest(bool allowDuplicateWords)
        {
            Word3Trie trie = new Word3Trie();
            trie.Add(new Word3("art"));
            trie.Add(new Word3("loo"));
            trie.Add(new Word3("lek"));
            trie.Add(new Word3("all"));
            trie.Add(new Word3("roe"));
            Word3GridFinder finder = new Word3GridFinder(trie, allowDuplicateWords);

            int count = 0;
            finder.Find(new Word3("art"), g => ++count);

            Assert.Equal(0, count);
        }

        private static void FindOneMatchSixWordsInnerTest(bool allowDuplicateWords)
        {
            Word3Trie trie = new Word3Trie();
            trie.Add(new Word3("pro"));
            trie.Add(new Word3("hop"));
            trie.Add(new Word3("ids"));
            trie.Add(new Word3("phi"));
            trie.Add(new Word3("rod"));
            trie.Add(new Word3("ops"));
            Word3GridFinder finder = new Word3GridFinder(trie, allowDuplicateWords);

            List<Word3Grid> grids = new List<Word3Grid>();
            finder.Find(new Word3("pro"), g => grids.Add(g));

            Assert.Equal(1, grids.Count);
            Assert.Equal(new Word3("pro"), grids[0].Row1);
            Assert.Equal(new Word3("hop"), grids[0].Row2);
            Assert.Equal(new Word3("ids"), grids[0].Row3);
        }
    }
}
