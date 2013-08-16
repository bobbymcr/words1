//-----------------------------------------------------------------------
// <copyright file="Word4TrieTest.cs" company="Brian Rogers">
// Copyright (c) Brian Rogers. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Words1.Test.Unit
{
    using System;
    using System.Collections.Generic;
    using Xunit;

    public class Word4TrieTest
    {
        public Word4TrieTest()
        {
        }

        [Fact]
        public void Construct_WordSequence_AddsToTrie()
        {
            Word4 w1 = new Word4("aaaa");
            Word4 w2 = new Word4("zzzz");

            Word4Trie trie = new Word4Trie(new Word4[] { w1, w2 });
            
            Assert.True(trie.Contains(w1));
            Assert.True(trie.Contains(w2));
        }

        [Fact]
        public void Add_FirstTimeReturnsTrueNextTimeReturnsFalse()
        {
            Word4Trie trie = new Word4Trie();

            Assert.True(trie.Add(new Word4("zzzz")));
            Assert.False(trie.Add(new Word4("zzzz")));
            Assert.False(trie.Add(new Word4("zzzz")));

            Assert.True(trie.Add(new Word4("zzzy")));
            Assert.False(trie.Add(new Word4("zzzy")));
            Assert.False(trie.Add(new Word4("zzzy")));

            Assert.True(trie.Add(new Word4("zzxy")));
            Assert.False(trie.Add(new Word4("zzxy")));
            Assert.False(trie.Add(new Word4("zzxy")));

            Assert.True(trie.Add(new Word4("zwxy")));
            Assert.False(trie.Add(new Word4("zwxy")));
            Assert.False(trie.Add(new Word4("zwxy")));

            Assert.True(trie.Add(new Word4("vwxy")));
            Assert.False(trie.Add(new Word4("vwxy")));
            Assert.False(trie.Add(new Word4("vwxy")));
        }

        [Fact]
        public void Contains_ReturnsTrueIfFoundFalseOtherwise()
        {
            Word4Trie trie = new Word4Trie();

            Assert.False(trie.Contains(new Word4("abcd")));

            trie.Add(new Word4("abcd"));

            Assert.True(trie.Contains(new Word4("abcd")));
            Assert.False(trie.Contains(new Word4("abdd")));

            trie.Add(new Word4("abdd"));

            Assert.True(trie.Contains(new Word4("abdd")));

            trie.Remove(new Word4("abcd"));

            Assert.False(trie.Contains(new Word4("abcd")));
        }

        [Fact]
        public void Remove_TrieEmpty_AlwaysReturnsFalse()
        {
            Word4Trie trie = new Word4Trie();

            Assert.False(trie.Remove(new Word4("zzzz")));
            Assert.False(trie.Remove(new Word4("zzzy")));
            Assert.False(trie.Remove(new Word4("zzxy")));
            Assert.False(trie.Remove(new Word4("zwxy")));
            Assert.False(trie.Remove(new Word4("vwxy")));
        }

        [Fact]
        public void Remove_FirstTimeReturnsTrueNextTimeReturnsFalse()
        {
            Word4Trie trie = new Word4Trie();
            
            trie.Add(new Word4("zzzz"));

            Assert.True(trie.Remove(new Word4("zzzz")));
            Assert.False(trie.Remove(new Word4("zzzz")));
            Assert.False(trie.Remove(new Word4("zzzz")));

            trie.Add(new Word4("zzzy"));

            Assert.True(trie.Remove(new Word4("zzzy")));
            Assert.False(trie.Remove(new Word4("zzzy")));
            Assert.False(trie.Remove(new Word4("zzzy")));

            trie.Add(new Word4("zzxy"));

            Assert.True(trie.Remove(new Word4("zzxy")));
            Assert.False(trie.Remove(new Word4("zzxy")));
            Assert.False(trie.Remove(new Word4("zzxy")));

            trie.Add(new Word4("zwxy"));

            Assert.True(trie.Remove(new Word4("zwxy")));
            Assert.False(trie.Remove(new Word4("zwxy")));
            Assert.False(trie.Remove(new Word4("zwxy")));

            trie.Add(new Word4("vwxy"));

            Assert.True(trie.Remove(new Word4("vwxy")));
            Assert.False(trie.Remove(new Word4("vwxy")));
            Assert.False(trie.Remove(new Word4("vwxy")));
        }

        [Fact]
        public void Match1_NullOnMatch_ThrowsArgumentNull()
        {
            Word4Trie trie = new Word4Trie();
            Action<Word4> onMatch = null;

            Exception e = Record.Exception(() => trie.Match1('a', onMatch));
            Assert.NotNull(e);
            ArgumentNullException ane = Assert.IsType<ArgumentNullException>(e);
            Assert.Equal("onMatch", ane.ParamName);
        }

        [Fact]
        public void Match1_EmptyTrie_DoesNothing()
        {
            Word4Trie trie = new Word4Trie();
            int count = 0;

            trie.Match1('a', w => ++count);

            Assert.Equal(0, count);
        }

        [Fact]
        public void Match1_NoMatch_DoesNothing()
        {
            Word4Trie trie = new Word4Trie();
            trie.Add(new Word4("bbbb"));
            int count = 0;

            trie.Match1('a', w => ++count);

            Assert.Equal(0, count);
        }

        [Fact]
        public void Match1_WithMatches_ExecutesForEachPrefixMatch()
        {
            Word4Trie trie = new Word4Trie();
            trie.Add(new Word4("aabc"));
            trie.Add(new Word4("abcd"));
            trie.Add(new Word4("bacd"));
            trie.Add(new Word4("baaa"));
            List<string> wordsSeen = new List<string>();

            trie.Match1('a', w => wordsSeen.Add(w.ToString()));

            wordsSeen.Sort();
            Assert.Equal(2, wordsSeen.Count);
            Assert.Equal("aabc", wordsSeen[0]);
            Assert.Equal("abcd", wordsSeen[1]);
        }

        [Fact]
        public void Match2_NullAction_ThrowsArgumentNull()
        {
            Word4Trie trie = new Word4Trie();
            Action<Word4> action = null;

            Exception e = Record.Exception(() => trie.Match2('a', 'b', action));
            Assert.NotNull(e);
            ArgumentNullException ane = Assert.IsType<ArgumentNullException>(e);
            Assert.Equal("onMatch", ane.ParamName);
        }

        [Fact]
        public void Match2_EmptyTrie_DoesNothing()
        {
            Word4Trie trie = new Word4Trie();
            int count = 0;

            trie.Match2('a', 'b', w => ++count);

            Assert.Equal(0, count);
        }

        [Fact]
        public void Match2_NoMatch_DoesNothing()
        {
            Word4Trie trie = new Word4Trie();
            trie.Add(new Word4("bbbb"));
            int count = 0;

            trie.Match2('a', 'b', w => ++count);

            Assert.Equal(0, count);
        }

        [Fact]
        public void Match2_WithMatches_ExecutesForEachPrefixMatch()
        {
            Word4Trie trie = new Word4Trie();
            trie.Add(new Word4("aabc"));
            trie.Add(new Word4("abcd"));
            trie.Add(new Word4("baaa"));
            trie.Add(new Word4("bacd"));
            List<string> wordsSeen = new List<string>();

            trie.Match2('b', 'a', w => wordsSeen.Add(w.ToString()));

            wordsSeen.Sort();
            Assert.Equal(2, wordsSeen.Count);
            Assert.Equal("baaa", wordsSeen[0]);
            Assert.Equal("bacd", wordsSeen[1]);
        }

        [Fact]
        public void Match3_NullAction_ThrowsArgumentNull()
        {
            Word4Trie trie = new Word4Trie();
            Action<Word4> action = null;

            Exception e = Record.Exception(() => trie.Match3('a', 'b', 'c', action));
            Assert.NotNull(e);
            ArgumentNullException ane = Assert.IsType<ArgumentNullException>(e);
            Assert.Equal("onMatch", ane.ParamName);
        }

        [Fact]
        public void Match3_EmptyTrie_DoesNothing()
        {
            Word4Trie trie = new Word4Trie();
            int count = 0;

            trie.Match3('a', 'b', 'c', w => ++count);

            Assert.Equal(0, count);
        }

        [Fact]
        public void Match3_NoMatch_DoesNothing()
        {
            Word4Trie trie = new Word4Trie();
            trie.Add(new Word4("bbbb"));
            int count = 0;

            trie.Match3('a', 'b', 'c', w => ++count);

            Assert.Equal(0, count);
        }

        [Fact]
        public void Match3_WithMatches_ExecutesForEachPrefixMatch()
        {
            Word4Trie trie = new Word4Trie();
            trie.Add(new Word4("abbc"));
            trie.Add(new Word4("abbd"));
            trie.Add(new Word4("baaa"));
            trie.Add(new Word4("bacd"));
            List<string> wordsSeen = new List<string>();

            trie.Match3('a', 'b', 'b', w => wordsSeen.Add(w.ToString()));

            wordsSeen.Sort();
            Assert.Equal(2, wordsSeen.Count);
            Assert.Equal("abbc", wordsSeen[0]);
            Assert.Equal("abbd", wordsSeen[1]);
        }
    }
}
