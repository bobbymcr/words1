//-----------------------------------------------------------------------
// <copyright file="Word3Trie.cs" company="Brian Rogers">
// Copyright (c) Brian Rogers. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Words1
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Word3Trie : IEnumerable<Word3>
    {
        private readonly Dictionary<char, Dictionary<char, HashSet<char>>> data;

        public Word3Trie(IEnumerable<Word3> words)
            : this()
        {
            foreach (Word3 word in words)
            {
                this.Add(word);
            }
        }

        public Word3Trie()
        {
            this.data = new Dictionary<char, Dictionary<char, HashSet<char>>>();
        }

        public bool Add(Word3 item)
        {
            Dictionary<char, HashSet<char>> level2;
            if (!this.data.TryGetValue(item.L1, out level2))
            {
                level2 = new Dictionary<char, HashSet<char>>();
                this.data.Add(item.L1, level2);
            }

            HashSet<char> level3;
            if (!level2.TryGetValue(item.L2, out level3))
            {
                level3 = new HashSet<char>();
                level2.Add(item.L2, level3);
            }

            return level3.Add(item.L3);
        }

        public bool Remove(Word3 item)
        {
            bool removed = false;
            Dictionary<char, HashSet<char>> level2;
            if (this.data.TryGetValue(item.L1, out level2))
            {
                HashSet<char> level3;
                if (level2.TryGetValue(item.L2, out level3))
                {
                    removed = level3.Remove(item.L3);
                }
            }

            return removed;
        }

        public bool Contains(Word3 item)
        {
            bool found = false;
            Dictionary<char, HashSet<char>> level2;
            if (this.data.TryGetValue(item.L1, out level2))
            {
                HashSet<char> level3;
                if (level2.TryGetValue(item.L2, out level3))
                {
                    found = level3.Contains(item.L3);
                }
            }

            return found;
        }

        public void Match1(char l1, Action<Word3> onMatch)
        {
            if (onMatch == null)
            {
                throw new ArgumentNullException("onMatch");
            }

            Dictionary<char, HashSet<char>> level2;
            if (this.data.TryGetValue(l1, out level2))
            {
                foreach (KeyValuePair<char, HashSet<char>> level23 in level2)
                {
                    MatchInner(l1, level23.Key, level23.Value, onMatch);
                }
            }
        }

        public void Match2(char l1, char l2, Action<Word3> onMatch)
        {
            if (onMatch == null)
            {
                throw new ArgumentNullException("onMatch");
            }

            Dictionary<char, HashSet<char>> level2;
            HashSet<char> level3;
            if (this.data.TryGetValue(l1, out level2) && level2.TryGetValue(l2, out level3))
            {
                MatchInner(l1, l2, level3, onMatch);
            }
        }

        public IEnumerator<Word3> GetEnumerator()
        {
            foreach (KeyValuePair<char, Dictionary<char, HashSet<char>>> level12 in this.data)
            {
                char l1 = level12.Key;
                foreach (KeyValuePair<char, HashSet<char>> level23 in level12.Value)
                {
                    char l2 = level23.Key;
                    foreach (char l3 in level23.Value)
                    {
                        yield return new Word3(l1, l2, l3);
                    }
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private static void MatchInner(char l1, char l2, HashSet<char> level3, Action<Word3> onMatch)
        {
            foreach (char l3 in level3)
            {
                Word3 word = new Word3(l1, l2, l3);
                onMatch(word);
            }
        }
    }
}
