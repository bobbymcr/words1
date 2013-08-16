//-----------------------------------------------------------------------
// <copyright file="Word3.cs" company="Brian Rogers">
// Copyright (c) Brian Rogers. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Words1
{
    using System;

    public struct Word3 : IComparable<Word3>, IEquatable<Word3>
    {
        private readonly char l1;
        private readonly char l2;
        private readonly char l3;

        public Word3(char l1, char l2, char l3)
        {
            this.l1 = l1;
            this.l2 = l2;
            this.l3 = l3;
        }

        public Word3(string word)
        {
            if (word == null)
            {
                throw new ArgumentNullException("word");
            }

            if (word.Length != 3)
            {
                throw new ArgumentException("Word must have exactly three letters.", "word");
            }

            this = new Word3(word[0], word[1], word[2]);
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

        public override bool Equals(object obj)
        {
            bool isEqual = false;
            if (obj is Word3)
            {
                isEqual = this.Equals((Word3)obj);
            }

            return isEqual;
        }

        public override int GetHashCode()
        {
            ulong l = ((ulong)this.l1) << 32;
            l |= ((uint)this.l2) << 16;
            l |= (ushort)this.l3;
            return l.GetHashCode();
        }

        public override string ToString()
        {
            return string.Empty + this.l1 + this.l2 + this.l3;
        }

        public bool Equals(Word3 other)
        {
            return this.CompareTo(other) == 0;
        }

        public int CompareTo(Word3 other)
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
            
            return this.l3.CompareTo(other.l3);
        }
    }
}
