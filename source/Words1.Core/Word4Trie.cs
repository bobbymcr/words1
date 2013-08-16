//-----------------------------------------------------------------------
// <copyright file="Word4Trie.cs" company="Brian Rogers">
// Copyright (c) Brian Rogers. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Words1
{
    using System;
    using System.Collections.Generic;

    public class Word4Trie
    {
        private readonly Dictionary<char, Dictionary<char, Dictionary<char, HashSet<char>>>> data;

        public Word4Trie(IEnumerable<Word4> words)
            : this()
        {
            foreach (Word4 word in words)
            {
                this.Add(word);
            }
        }

        public Word4Trie()
        {
            this.data = new Dictionary<char, Dictionary<char, Dictionary<char, HashSet<char>>>>();
        }

        public bool Add(Word4 item)
        {
            Dictionary<char, Dictionary<char, HashSet<char>>> level2;
            if (!this.data.TryGetValue(item.L1, out level2))
            {
                level2 = new Dictionary<char, Dictionary<char, HashSet<char>>>();
                this.data.Add(item.L1, level2);
            }

            Dictionary<char, HashSet<char>> level3;
            if (!level2.TryGetValue(item.L2, out level3))
            {
                level3 = new Dictionary<char, HashSet<char>>();
                level2.Add(item.L2, level3);
            }

            HashSet<char> level4;
            if (!level3.TryGetValue(item.L3, out level4))
            {
                level4 = new HashSet<char>();
                level3.Add(item.L3, level4);
            }

            return level4.Add(item.L4);
        }

        public bool Remove(Word4 item)
        {
            bool removed = false;
            Dictionary<char, Dictionary<char, HashSet<char>>> level2;
            if (this.data.TryGetValue(item.L1, out level2))
            {
                Dictionary<char, HashSet<char>> level3;
                if (level2.TryGetValue(item.L2, out level3))
                {
                    HashSet<char> level4;
                    if (level3.TryGetValue(item.L3, out level4))
                    {
                        removed = level4.Remove(item.L4);
                    }
                }
            }

            return removed;
        }

        public bool Contains(Word4 item)
        {
            bool found = false;
            Dictionary<char, Dictionary<char, HashSet<char>>> level2;
            if (this.data.TryGetValue(item.L1, out level2))
            {
                Dictionary<char, HashSet<char>> level3;
                if (level2.TryGetValue(item.L2, out level3))
                {
                    HashSet<char> level4;
                    if (level3.TryGetValue(item.L3, out level4))
                    {
                        found = level4.Contains(item.L4);
                    }
                }
            }

            return found;
        }

        public void Match1(char l1, Action<Word4> onMatch)
        {
            if (onMatch == null)
            {
                throw new ArgumentNullException("onMatch");
            }

            Dictionary<char, Dictionary<char, HashSet<char>>> level2;
            if (this.data.TryGetValue(l1, out level2))
            {
                foreach (KeyValuePair<char, Dictionary<char, HashSet<char>>> level23 in level2)
                {
                    MatchInner(l1, level23.Key, level23.Value, onMatch);
                }
            }
        }

        public void Match2(char l1, char l2, Action<Word4> onMatch)
        {
            if (onMatch == null)
            {
                throw new ArgumentNullException("onMatch");
            }

            Dictionary<char, Dictionary<char, HashSet<char>>> level2;
            Dictionary<char, HashSet<char>> level3;
            if (this.data.TryGetValue(l1, out level2) && level2.TryGetValue(l2, out level3))
            {
                MatchInner(l1, l2, level3, onMatch);
            }
        }

        public void Match3(char l1, char l2, char l3, Action<Word4> onMatch)
        {
            if (onMatch == null)
            {
                throw new ArgumentNullException("onMatch");
            }

            Dictionary<char, Dictionary<char, HashSet<char>>> level2;
            Dictionary<char, HashSet<char>> level3;
            HashSet<char> level4;
            if (this.data.TryGetValue(l1, out level2) && level2.TryGetValue(l2, out level3) && level3.TryGetValue(l3, out level4))
            {
                foreach (char l4 in level4)
                {
                    Word4 word = new Word4(l1, l2, l3, l4);
                    onMatch(word);
                }
            }
        }

        private static void MatchInner(char l1, char l2, Dictionary<char, HashSet<char>> level3, Action<Word4> onMatch)
        {
            foreach (KeyValuePair<char, HashSet<char>> level34 in level3)
            {
                char l3 = level34.Key;
                foreach (char l4 in level34.Value)
                {
                    Word4 word = new Word4(l1, l2, l3, l4);
                    onMatch(word);
                }
            }
        }
    }
}
