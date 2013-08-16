//-----------------------------------------------------------------------
// <copyright file="Word3TrieTest.cs" company="Brian Rogers">
// Copyright (c) Brian Rogers. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Words1.Test.Unit
{
    using System;
    using System.Collections.Generic;
    using Xunit;

    public class Word3TrieTest
    {
        public Word3TrieTest()
        {
        }

        [Fact]
        public void Construct_WordSequence_AddsToTrie()
        {
            Word3 w1 = new Word3("aaa");
            Word3 w2 = new Word3("zzz");

            Word3Trie trie = new Word3Trie(new Word3[] { w1, w2 });

            Assert.True(trie.Contains(w1));
            Assert.True(trie.Contains(w2));
        }

        [Fact]
        public void Add_FirstTimeReturnsTrueNextTimeReturnsFalse()
        {
            Word3Trie trie = new Word3Trie();

            Assert.True(trie.Add(new Word3("zzz")));
            Assert.False(trie.Add(new Word3("zzz")));
            Assert.False(trie.Add(new Word3("zzz")));

            Assert.True(trie.Add(new Word3("zzy")));
            Assert.False(trie.Add(new Word3("zzy")));
            Assert.False(trie.Add(new Word3("zzy")));

            Assert.True(trie.Add(new Word3("zxy")));
            Assert.False(trie.Add(new Word3("zxy")));
            Assert.False(trie.Add(new Word3("zxy")));

            Assert.True(trie.Add(new Word3("wxy")));
            Assert.False(trie.Add(new Word3("wxy")));
            Assert.False(trie.Add(new Word3("wxy")));
        }

        [Fact]
        public void Contains_ReturnsTrueIfFoundFalseOtherwise()
        {
            Word3Trie trie = new Word3Trie();

            Assert.False(trie.Contains(new Word3("abc")));

            trie.Add(new Word3("abc"));

            Assert.True(trie.Contains(new Word3("abc")));
            Assert.False(trie.Contains(new Word3("abd")));

            trie.Add(new Word3("abd"));

            Assert.True(trie.Contains(new Word3("abd")));

            trie.Remove(new Word3("abc"));

            Assert.False(trie.Contains(new Word3("abc")));
        }

        [Fact]
        public void Remove_TrieEmpty_AlwaysReturnsFalse()
        {
            Word3Trie trie = new Word3Trie();

            Assert.False(trie.Remove(new Word3("zzz")));
            Assert.False(trie.Remove(new Word3("zzy")));
            Assert.False(trie.Remove(new Word3("zxy")));
            Assert.False(trie.Remove(new Word3("wxy")));
        }

        [Fact]
        public void Remove_FirstTimeReturnsTrueNextTimeReturnsFalse()
        {
            Word3Trie trie = new Word3Trie();
            
            trie.Add(new Word3("zzz"));

            Assert.True(trie.Remove(new Word3("zzz")));
            Assert.False(trie.Remove(new Word3("zzz")));
            Assert.False(trie.Remove(new Word3("zzz")));

            trie.Add(new Word3("zzy"));

            Assert.True(trie.Remove(new Word3("zzy")));
            Assert.False(trie.Remove(new Word3("zzy")));
            Assert.False(trie.Remove(new Word3("zzy")));

            trie.Add(new Word3("zxy"));

            Assert.True(trie.Remove(new Word3("zxy")));
            Assert.False(trie.Remove(new Word3("zxy")));
            Assert.False(trie.Remove(new Word3("zxy")));

            trie.Add(new Word3("wxy"));

            Assert.True(trie.Remove(new Word3("wxy")));
            Assert.False(trie.Remove(new Word3("wxy")));
            Assert.False(trie.Remove(new Word3("wxy")));
        }

        [Fact]
        public void Match1_NullOnMatch_ThrowsArgumentNull()
        {
            Word3Trie trie = new Word3Trie();
            Action<Word3> onMatch = null;

            Exception e = Record.Exception(() => trie.Match1('a', onMatch));
            Assert.NotNull(e);
            ArgumentNullException ane = Assert.IsType<ArgumentNullException>(e);
            Assert.Equal("onMatch", ane.ParamName);
        }

        [Fact]
        public void Match1_EmptyTrie_DoesNothing()
        {
            Word3Trie trie = new Word3Trie();
            int count = 0;

            trie.Match1('a', w => ++count);

            Assert.Equal(0, count);
        }

        [Fact]
        public void Match1_NoMatch_DoesNothing()
        {
            Word3Trie trie = new Word3Trie();
            trie.Add(new Word3("bbb"));
            int count = 0;

            trie.Match1('a', w => ++count);

            Assert.Equal(0, count);
        }

        [Fact]
        public void Match1_WithMatches_ExecutesForEachPrefixMatch()
        {
            Word3Trie trie = new Word3Trie();
            trie.Add(new Word3("aab"));
            trie.Add(new Word3("aac"));
            trie.Add(new Word3("bac"));
            trie.Add(new Word3("baa"));
            List<string> wordsSeen = new List<string>();

            trie.Match1('a', w => wordsSeen.Add(w.ToString()));

            wordsSeen.Sort();
            Assert.Equal(2, wordsSeen.Count);
            Assert.Equal("aab", wordsSeen[0]);
            Assert.Equal("aac", wordsSeen[1]);
        }

        [Fact]
        public void Match2_NullOnMatch_ThrowsArgumentNull()
        {
            Word3Trie trie = new Word3Trie();
            Action<Word3> onMatch = null;

            Exception e = Record.Exception(() => trie.Match2('a', 'b', onMatch));
            Assert.NotNull(e);
            ArgumentNullException ane = Assert.IsType<ArgumentNullException>(e);
            Assert.Equal("onMatch", ane.ParamName);
        }

        [Fact]
        public void Match2_EmptyTrie_DoesNothing()
        {
            Word3Trie trie = new Word3Trie();
            int count = 0;

            trie.Match2('a', 'b', w => ++count);

            Assert.Equal(0, count);
        }

        [Fact]
        public void Match2_NoMatch_DoesNothing()
        {
            Word3Trie trie = new Word3Trie();
            trie.Add(new Word3("bbb"));
            int count = 0;

            trie.Match2('b', 'a', w => ++count);

            Assert.Equal(0, count);
        }

        [Fact]
        public void Match2_WithMatches_ExecutesForEachPrefixMatch()
        {
            Word3Trie trie = new Word3Trie();
            trie.Add(new Word3("aab"));
            trie.Add(new Word3("abc"));
            trie.Add(new Word3("aba"));
            trie.Add(new Word3("bbc"));
            trie.Add(new Word3("baa"));
            List<string> wordsSeen = new List<string>();

            trie.Match2('a', 'b', w => wordsSeen.Add(w.ToString()));

            wordsSeen.Sort();
            Assert.Equal(2, wordsSeen.Count);
            Assert.Equal("aba", wordsSeen[0]);
            Assert.Equal("abc", wordsSeen[1]);
        }

        [Fact]
        public void Enumerator_Empty_YieldsNothing()
        {
            Word3Trie trie = new Word3Trie();
            
            int count = 0;
            foreach (Word3 word in trie)
            {
                ++count;
            }

            Assert.Equal(0, count);
        }
        
        [Fact]
        public void Enumerator_YieldsEveryValue()
        {
            Word3Trie trie = new Word3Trie();
            trie.Add(new Word3("aab"));
            trie.Add(new Word3("abc"));
            trie.Add(new Word3("aba"));
            trie.Add(new Word3("bbc"));
            trie.Add(new Word3("baa"));
            List<string> wordsSeen = new List<string>();

            foreach (Word3 word in trie)
            {
                wordsSeen.Add(word.ToString());
            }

            wordsSeen.Sort();
            Assert.Equal(5, wordsSeen.Count);
            Assert.Equal("aab", wordsSeen[0]);
            Assert.Equal("aba", wordsSeen[1]);
            Assert.Equal("abc", wordsSeen[2]);
            Assert.Equal("baa", wordsSeen[3]);
            Assert.Equal("bbc", wordsSeen[4]);
        }
    }
}
