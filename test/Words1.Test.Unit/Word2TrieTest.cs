//-----------------------------------------------------------------------
// <copyright file="Word2TrieTest.cs" company="Brian Rogers">
// Copyright (c) Brian Rogers. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Words1.Test.Unit
{
    using System;
    using System.Collections.Generic;
    using Xunit;

    public class Word2TrieTest
    {
        public Word2TrieTest()
        {
        }

        [Fact]
        public void Construct_WordSequence_AddsToTrie()
        {
            Word2 w1 = new Word2("aa");
            Word2 w2 = new Word2("zz");

            Word2Trie trie = new Word2Trie(new Word2[] { w1, w2 });

            Assert.True(trie.Contains(w1));
            Assert.True(trie.Contains(w2));
        }

        [Fact]
        public void Add_FirstTimeReturnsTrueNextTimeReturnsFalse()
        {
            Word2Trie trie = new Word2Trie();

            Assert.True(trie.Add(new Word2("zz")));
            Assert.False(trie.Add(new Word2("zz")));
            Assert.False(trie.Add(new Word2("zz")));

            Assert.True(trie.Add(new Word2("zy")));
            Assert.False(trie.Add(new Word2("zy")));
            Assert.False(trie.Add(new Word2("zy")));

            Assert.True(trie.Add(new Word2("yz")));
            Assert.False(trie.Add(new Word2("yz")));
            Assert.False(trie.Add(new Word2("yz")));
        }

        [Fact]
        public void Contains_ReturnsTrueIfFoundFalseOtherwise()
        {
            Word2Trie trie = new Word2Trie();

            Assert.False(trie.Contains(new Word2("ab")));

            trie.Add(new Word2("ab"));

            Assert.True(trie.Contains(new Word2("ab")));
            Assert.False(trie.Contains(new Word2("ac")));

            trie.Add(new Word2("ac"));

            Assert.True(trie.Contains(new Word2("ac")));

            trie.Remove(new Word2("ac"));

            Assert.False(trie.Contains(new Word2("ac")));
        }

        [Fact]
        public void Remove_TrieEmpty_AlwaysReturnsFalse()
        {
            Word2Trie trie = new Word2Trie();

            Assert.False(trie.Remove(new Word2("zz")));
            Assert.False(trie.Remove(new Word2("zy")));
            Assert.False(trie.Remove(new Word2("zx")));
            Assert.False(trie.Remove(new Word2("xy")));
        }

        [Fact]
        public void Remove_FirstTimeReturnsTrueNextTimeReturnsFalse()
        {
            Word2Trie trie = new Word2Trie();
            
            trie.Add(new Word2("zz"));

            Assert.True(trie.Remove(new Word2("zz")));
            Assert.False(trie.Remove(new Word2("zz")));
            Assert.False(trie.Remove(new Word2("zz")));

            trie.Add(new Word2("zy"));

            Assert.True(trie.Remove(new Word2("zy")));
            Assert.False(trie.Remove(new Word2("zy")));
            Assert.False(trie.Remove(new Word2("zy")));

            trie.Add(new Word2("wx"));

            Assert.True(trie.Remove(new Word2("wx")));
            Assert.False(trie.Remove(new Word2("wx")));
            Assert.False(trie.Remove(new Word2("wx")));
        }

        [Fact]
        public void Match1_NullOnMatch_ThrowsArgumentNull()
        {
            Word2Trie trie = new Word2Trie();
            Action<Word2> onMatch = null;

            Exception e = Record.Exception(() => trie.Match1('a', onMatch));
            Assert.NotNull(e);
            ArgumentNullException ane = Assert.IsType<ArgumentNullException>(e);
            Assert.Equal("onMatch", ane.ParamName);
        }

        [Fact]
        public void Match1_EmptyTrie_DoesNothing()
        {
            Word2Trie trie = new Word2Trie();
            int count = 0;

            trie.Match1('a', w => ++count);

            Assert.Equal(0, count);
        }

        [Fact]
        public void Match1_NoMatch_DoesNothing()
        {
            Word2Trie trie = new Word2Trie();
            trie.Add(new Word2("bb"));
            int count = 0;

            trie.Match1('a', w => ++count);

            Assert.Equal(0, count);
        }

        [Fact]
        public void Match1_WithMatches_ExecutesForEachPrefixMatch()
        {
            Word2Trie trie = new Word2Trie();
            trie.Add(new Word2("ab"));
            trie.Add(new Word2("ac"));
            trie.Add(new Word2("ba"));
            trie.Add(new Word2("bc"));
            List<string> wordsSeen = new List<string>();

            trie.Match1('a', w => wordsSeen.Add(w.ToString()));

            wordsSeen.Sort();
            Assert.Equal(2, wordsSeen.Count);
            Assert.Equal("ab", wordsSeen[0]);
            Assert.Equal("ac", wordsSeen[1]);
        }

        [Fact]
        public void Enumerator_Empty_YieldsNothing()
        {
            Word2Trie trie = new Word2Trie();
            
            int count = 0;
            foreach (Word2 word in trie)
            {
                ++count;
            }

            Assert.Equal(0, count);
        }
        
        [Fact]
        public void Enumerator_YieldsEveryValue()
        {
            Word2Trie trie = new Word2Trie();
            trie.Add(new Word2("ab"));
            trie.Add(new Word2("ac"));
            trie.Add(new Word2("bc"));
            trie.Add(new Word2("ba"));
            List<string> wordsSeen = new List<string>();

            foreach (Word2 word in trie)
            {
                wordsSeen.Add(word.ToString());
            }

            wordsSeen.Sort();
            Assert.Equal(4, wordsSeen.Count);
            Assert.Equal("ab", wordsSeen[0]);
            Assert.Equal("ac", wordsSeen[1]);
            Assert.Equal("ba", wordsSeen[2]);
            Assert.Equal("bc", wordsSeen[3]);
        }
    }
}
