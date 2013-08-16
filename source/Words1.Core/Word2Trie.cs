//-----------------------------------------------------------------------
// <copyright file="Word2Trie.cs" company="Brian Rogers">
// Copyright (c) Brian Rogers. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Words1
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Word2Trie : IEnumerable<Word2>
    {
        private readonly Dictionary<char, HashSet<char>> data;

        public Word2Trie(IEnumerable<Word2> words)
            : this()
        {
            foreach (Word2 word in words)
            {
                this.Add(word);
            }
        }

        public Word2Trie()
        {
            this.data = new Dictionary<char, HashSet<char>>();
        }

        public bool Add(Word2 item)
        {
            HashSet<char> level2;
            if (!this.data.TryGetValue(item.L1, out level2))
            {
                level2 = new HashSet<char>();
                this.data.Add(item.L1, level2);
            }

            return level2.Add(item.L2);
        }

        public bool Remove(Word2 item)
        {
            bool removed = false;
            HashSet<char> level2;
            if (this.data.TryGetValue(item.L1, out level2))
            {
                removed = level2.Remove(item.L2);
            }

            return removed;
        }

        public bool Contains(Word2 item)
        {
            bool found = false;
            HashSet<char> level2;
            if (this.data.TryGetValue(item.L1, out level2))
            {
                found = level2.Contains(item.L2);
            }

            return found;
        }

        public void Match1(char l1, Action<Word2> onMatch)
        {
            if (onMatch == null)
            {
                throw new ArgumentNullException("onMatch");
            }

            HashSet<char> level2;
            if (this.data.TryGetValue(l1, out level2))
            {
                MatchInner(l1, level2, onMatch);
            }
        }

        public IEnumerator<Word2> GetEnumerator()
        {
            foreach (KeyValuePair<char, HashSet<char>> level12 in this.data)
            {
                char l1 = level12.Key;
                foreach (char l2 in level12.Value)
                {
                    yield return new Word2(l1, l2);
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private static void MatchInner(char l1, HashSet<char> level2, Action<Word2> onMatch)
        {
            foreach (char l2 in level2)
            {
                Word2 word = new Word2(l1, l2);
                onMatch(word);
            }
        }
    }
}
