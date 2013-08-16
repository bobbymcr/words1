//-----------------------------------------------------------------------
// <copyright file="Word2Grid.cs" company="Brian Rogers">
// Copyright (c) Brian Rogers. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Words1
{
    using System;
    using System.Text;

    public struct Word2Grid : IEquatable<Word2Grid>
    {
        private readonly char a00;
        private readonly char a01;
        private readonly char a10;
        private readonly char a11;

        public Word2Grid(Word2 row1, Word2 row2)
        {
            this.a00 = row1.L1;
            this.a01 = row1.L2;
            this.a10 = row2.L1;
            this.a11 = row2.L2;
        }

        public char A00
        {
            get { return this.a00; }
        }

        public char A01
        {
            get { return this.a01; }
        }

        public char A10
        {
            get { return this.a10; }
        }

        public char A11
        {
            get { return this.a11; }
        }

        public Word2 Row1
        {
            get { return new Word2(this.a00, this.a01); }
        }

        public Word2 Row2
        {
            get { return new Word2(this.a10, this.a11); }
        }
        
        public Word2 Column1
        {
            get { return new Word2(this.a00, this.a10); }
        }

        public Word2 Column2
        {
            get { return new Word2(this.a01, this.a11); }
        }

        public Word2Grid Transpose()
        {
            return new Word2Grid(this.Column1, this.Column2);
        }

        public bool Equals(Word2Grid other)
        {
            return
                (this.a00 == other.a00) &&
                (this.a01 == other.a01) &&
                (this.a10 == other.a10) &&
                (this.a11 == other.a11);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            this.WriteBlock(b => sb.AppendLine(b));
            sb.Remove(sb.Length - 2, 2);
            return sb.ToString();
        }

        public void WriteBlock(Action<string> onText)
        {
            onText(this.Row1.ToString());
            onText(this.Row2.ToString());
        }
    }
}
