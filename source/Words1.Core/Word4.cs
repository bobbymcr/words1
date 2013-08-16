//-----------------------------------------------------------------------
// <copyright file="Word4.cs" company="Brian Rogers">
// Copyright (c) Brian Rogers. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Words1
{
    using System;

    public struct Word4 : IComparable<Word4>, IEquatable<Word4>
    {
        private readonly char l1;
        private readonly char l2;
        private readonly char l3;
        private readonly char l4;

        public Word4(char l1, char l2, char l3, char l4)
        {
            this.l1 = l1;
            this.l2 = l2;
            this.l3 = l3;
            this.l4 = l4;
        }

        public Word4(string word)
        {
            if (word == null)
            {
                throw new ArgumentNullException("word");
            }

            if (word.Length != 4)
            {
                throw new ArgumentException("Word must have exactly three letters.", "word");
            }

            this = new Word4(word[0], word[1], word[2], word[3]);
        }

        public char L1
        {
            get { return this.l1; }
        }

        public char L2
        {
            get { return this.l2; }
        }

        public char L3
        {
            get { return this.l3; }
        }

        public char L4
        {
            get { return this.l4; }
        }

        public override bool Equals(object obj)
        {
            bool isEqual = false;
            if (obj is Word4)
            {
                isEqual = this.Equals((Word4)obj);
            }

            return isEqual;
        }

        public override int GetHashCode()
        {
            ulong l = ((ulong)this.l1) << 48;
            l |= ((ulong)this.l2) << 32;
            l |= ((uint)this.l3) << 16;
            l |= this.l4;
            return l.GetHashCode();
        }

        public override string ToString()
        {
            return string.Empty + this.l1 + this.l2 + this.l3 + this.l4;
        }

        public bool Equals(Word4 other)
        {
            return this.CompareTo(other) == 0;
        }

        public int CompareTo(Word4 other)
        {
            int c = this.l1.CompareTo(other.l1);
            if (c != 0)
            {
                return c;
            }

            c = this.l2.CompareTo(other.l2);
            if (c != 0)
            {
                return c;
            }
            
            c = this.l3.CompareTo(other.l3);           
            if (c != 0)
            {
                return c;
            }
            
            return this.l4.CompareTo(other.l4);
        }
    }
}
