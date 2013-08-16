//-----------------------------------------------------------------------
// <copyright file="Word2.cs" company="Brian Rogers">
// Copyright (c) Brian Rogers. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Words1
{
    using System;

    public struct Word2 : IComparable<Word2>, IEquatable<Word2>
    {
        private readonly char l1;
        private readonly char l2;

        public Word2(char l1, char l2)
        {
            this.l1 = l1;
            this.l2 = l2;
        }

        public Word2(string word)
        {
            if (word == null)
            {
                throw new ArgumentNullException("word");
            }

            if (word.Length != 2)
            {
                throw new ArgumentException("Word must have exactly two letters.", "word");
            }

            this = new Word2(word[0], word[1]);
        }

        public char L1
        {
            get { return this.l1; }
        }

        public char L2
        {
            get { return this.l2; }
        }

        public override bool Equals(object obj)
        {
            bool isEqual = false;
            if (obj is Word2)
            {
                isEqual = this.Equals((Word2)obj);
            }

            return isEqual;
        }

        public override int GetHashCode()
        {
            int l = this.l1 << 16;
            l |= this.l2;
            return l;
        }

        public override string ToString()
        {
            return string.Empty + this.l1 + this.l2;
        }

        public bool Equals(Word2 other)
        {
            return this.CompareTo(other) == 0;
        }

        public int CompareTo(Word2 other)
        {
            int c = this.l1.CompareTo(other.l1);
            if (c != 0)
            {
                return c;
            }

            return this.l2.CompareTo(other.l2);
        }
    }
}
