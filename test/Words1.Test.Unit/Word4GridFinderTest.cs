//-----------------------------------------------------------------------
// <copyright file="Word4GridFinderTest.cs" company="Brian Rogers">
// Copyright (c) Brian Rogers. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Words1.Test.Unit
{
    using System;
    using System.Collections.Generic;
    using Xunit;

    public class Word4GridFinderTest
    {
        public Word4GridFinderTest()
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
            Word4Trie trie = new Word4Trie();
            trie.Add(new Word4("abcd"));
            trie.Add(new Word4("bzzz"));
            Word4GridFinder finder = new Word4GridFinder(trie, true);
            
            int count = 0;
            finder.Find(new Word4("abcd"), g => ++count);

            Assert.Equal(0, count);
        }

        [Fact]
        public void Find_AllowDuplicatesMatchesFirstAndSecondRowAndColumnsButNoOtherWords_DoesNothing()
        {
            Word4Trie trie = new Word4Trie();
            trie.Add(new Word4("abcd"));
            trie.Add(new Word4("bcde"));
            Word4GridFinder finder = new Word4GridFinder(trie, true);
            
            int count = 0;
            finder.Find(new Word4("abcd"), g => ++count);

            Assert.Equal(0, count);
        }

        [Fact]
        public void Find_AllowDuplicatesMatchesFirstSecondAndThirdRowAndColumnsButNoOtherWords_DoesNothing()
        {
            Word4Trie trie = new Word4Trie();
            trie.Add(new Word4("abcd"));
            trie.Add(new Word4("bcde"));
            trie.Add(new Word4("cdef"));
            Word4GridFinder finder = new Word4GridFinder(trie, true);

            int count = 0;
            finder.Find(new Word4("abcd"), g => ++count);

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
        public void Find_AllowDuplicatesExactlyOneMatchWithFourWords_ExecutesOnFoundOnce()
        {
            Word4Trie trie = new Word4Trie();
            trie.Add(new Word4("abcd"));
            trie.Add(new Word4("bcde"));
            trie.Add(new Word4("cdef"));
            trie.Add(new Word4("defg"));
            Word4GridFinder finder = new Word4GridFinder(trie, true);

            List<Word4Grid> grids = new List<Word4Grid>();
            finder.Find(new Word4("abcd"), g => grids.Add(g));

            Assert.Equal(1, grids.Count);
            Assert.Equal(new Word4("abcd"), grids[0].Row1);
            Assert.Equal(new Word4("bcde"), grids[0].Row2);
            Assert.Equal(new Word4("cdef"), grids[0].Row3);
            Assert.Equal(new Word4("defg"), grids[0].Row4);
        }

        [Fact]
        public void Find_DisallowDuplicatesNoMatchesWithSixWords_DoesNothing()
        {
            Word4Trie trie = new Word4Trie();
            trie.Add(new Word4("abcd"));
            trie.Add(new Word4("abce"));
            trie.Add(new Word4("bcde"));
            trie.Add(new Word4("cdef"));
            trie.Add(new Word4("defg"));
            trie.Add(new Word4("eefg"));
            Word4GridFinder finder = new Word4GridFinder(trie, false);

            int count = 0;
            finder.Find(new Word4("abcd"), g => ++count);

            Assert.Equal(0, count);
        }

        [Fact]
        public void Find_DisallowDuplicatesNoMatchesWithSevenWords_DoesNothing()
        {
            Word4Trie trie = new Word4Trie();
            trie.Add(new Word4("abcd"));
            trie.Add(new Word4("abce"));
            trie.Add(new Word4("bcdf"));
            trie.Add(new Word4("bcdg"));
            trie.Add(new Word4("cdef"));
            trie.Add(new Word4("dgfg"));
            trie.Add(new Word4("effg"));
            Word4GridFinder finder = new Word4GridFinder(trie, false);

            int count = 0;
            finder.Find(new Word4("abcd"), g => ++count);

            Assert.Equal(0, count);
        }

        [Fact]
        public void Find_DisallowDuplicatesNoMatchesWithSevenWordsLastRow_DoesNothing()
        {
            Word4Trie trie = new Word4Trie();
            trie.Add(new Word4("abcc"));
            trie.Add(new Word4("acbc"));
            trie.Add(new Word4("babx"));
            trie.Add(new Word4("bbbx"));
            trie.Add(new Word4("cadx"));
            trie.Add(new Word4("cdbx"));
            trie.Add(new Word4("cxxx"));
            Word4GridFinder finder = new Word4GridFinder(trie, false);

            int count = 0;
            finder.Find(new Word4("abcc"), g => ++count);

            Assert.Equal(0, count);
        }

        [Fact]
        public void Find_AllowDuplicatesExactlyTwoMatches_ExecutesOnFoundTwice()
        {
            Word4Trie trie = new Word4Trie();
            trie.Add(new Word4("abcd"));
            trie.Add(new Word4("bcde"));
            trie.Add(new Word4("cdef"));
            trie.Add(new Word4("defg"));
            trie.Add(new Word4("defh"));
            Word4GridFinder finder = new Word4GridFinder(trie, true);

            List<Word4Grid> grids = new List<Word4Grid>();
            finder.Find(new Word4("abcd"), g => grids.Add(g));

            Assert.Equal(2, grids.Count);
            Assert.Equal(new Word4("abcd"), grids[0].Row1);
            Assert.Equal(new Word4("bcde"), grids[0].Row2);
            Assert.Equal(new Word4("cdef"), grids[0].Row3);
            Assert.Equal(new Word4("defg"), grids[0].Row4);
            Assert.Equal(new Word4("abcd"), grids[1].Row1);
            Assert.Equal(new Word4("bcde"), grids[1].Row2);
            Assert.Equal(new Word4("cdef"), grids[1].Row3);
            Assert.Equal(new Word4("defh"), grids[1].Row4);
        }

        [Fact]
        public void Find_DisallowDuplicatesExactlyTwoMatches_ExecutesOnFoundTwice()
        {
            Word4Trie trie = new Word4Trie();
            trie.Add(new Word4("abcd"));
            trie.Add(new Word4("acde"));
            trie.Add(new Word4("cdef"));
            trie.Add(new Word4("bdef"));
            trie.Add(new Word4("cefg"));
            trie.Add(new Word4("defg"));
            trie.Add(new Word4("efgh"));
            trie.Add(new Word4("dfgh"));
            trie.Add(new Word4("efgi"));
            trie.Add(new Word4("dfgi"));
            Word4GridFinder finder = new Word4GridFinder(trie, false);

            List<Word4Grid> grids = new List<Word4Grid>();
            finder.Find(new Word4("abcd"), g => grids.Add(g));

            Assert.Equal(2, grids.Count);
            Assert.Equal(new Word4("abcd"), grids[0].Row1);
            Assert.Equal(new Word4("cdef"), grids[0].Row2);
            Assert.Equal(new Word4("defg"), grids[0].Row3);
            Assert.Equal(new Word4("efgh"), grids[0].Row4);
            Assert.Equal(new Word4("abcd"), grids[1].Row1);
            Assert.Equal(new Word4("cdef"), grids[1].Row2);
            Assert.Equal(new Word4("defg"), grids[1].Row3);
            Assert.Equal(new Word4("efgi"), grids[1].Row4);
        }

        [Fact]
        public void Find_AllowDuplicatesExactlyOneMatchWithEightWords_ExecutesOnFoundOnce()
        {
            FindOneMatchEightWordsInnerTest(true);
        }

        [Fact]
        public void Find_DisallowDuplicatesExactlyOneMatchWithEightWords_ExecutesOnFoundOnce()
        {
            FindOneMatchEightWordsInnerTest(false);
        }

        private static void NoMatchesForInputWordInnerTest(bool allowDuplicateWords)
        {
            Word4Trie trie = new Word4Trie();
            Word4GridFinder finder = new Word4GridFinder(trie, allowDuplicateWords);

            int count = 0;
            finder.Find(new Word4("abcd"), g => ++count);

            Assert.Equal(0, count);
        }

        private static void MatchInputWordButNoOtherWordsInnerTest(bool allowDuplicateWords)
        {
            Word4Trie trie = new Word4Trie();
            trie.Add(new Word4("abcd"));
            Word4GridFinder finder = new Word4GridFinder(trie, allowDuplicateWords);

            int count = 0;
            finder.Find(new Word4("abcd"), g => ++count);

            Assert.Equal(0, count);
        }

        private static void MismatchOnLastColumnInnerTest(bool allowDuplicateWords)
        {
            Word4Trie trie = new Word4Trie();
            trie.Add(new Word4("arts"));
            trie.Add(new Word4("root"));
            trie.Add(new Word4("mire"));
            trie.Add(new Word4("sled"));
            trie.Add(new Word4("arms"));
            trie.Add(new Word4("roil"));
            trie.Add(new Word4("tore"));
            Word4GridFinder finder = new Word4GridFinder(trie, allowDuplicateWords);

            int count = 0;
            finder.Find(new Word4("arts"), g => ++count);

            Assert.Equal(0, count);
        }

        private static void FindOneMatchEightWordsInnerTest(bool allowDuplicateWords)
        {
            Word4Trie trie = new Word4Trie();
            trie.Add(new Word4("pray"));
            trie.Add(new Word4("hole"));
            trie.Add(new Word4("idea"));
            trie.Add(new Word4("seer"));
            trie.Add(new Word4("phis"));
            trie.Add(new Word4("rode"));
            trie.Add(new Word4("alee"));
            trie.Add(new Word4("year"));
            Word4GridFinder finder = new Word4GridFinder(trie, allowDuplicateWords);

            List<Word4Grid> grids = new List<Word4Grid>();
            finder.Find(new Word4("pray"), g => grids.Add(g));

            Assert.Equal(1, grids.Count);
            Assert.Equal(new Word4("pray"), grids[0].Row1);
            Assert.Equal(new Word4("hole"), grids[0].Row2);
            Assert.Equal(new Word4("idea"), grids[0].Row3);
            Assert.Equal(new Word4("seer"), grids[0].Row4);
        }
    }
}
