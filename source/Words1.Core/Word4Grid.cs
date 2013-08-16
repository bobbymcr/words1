//-----------------------------------------------------------------------
// <copyright file="Word4Grid.cs" company="Brian Rogers">
// Copyright (c) Brian Rogers. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Words1
{
    using System;
    using System.Text;

    public struct Word4Grid : IEquatable<Word4Grid>
    {
        private readonly char a00;
        private readonly char a01;
        private readonly char a02;
        private readonly char a03;
        private readonly char a10;
        private readonly char a11;
        private readonly char a12;
        private readonly char a13;
        private readonly char a20;
        private readonly char a21;
        private readonly char a22;
        private readonly char a23;
        private readonly char a30;
        private readonly char a31;
        private readonly char a32;
        private readonly char a33;

        public Word4Grid(Word4 row1, Word4 row2, Word4 row3, Word4 row4)
        {
            this.a00 = row1.L1;
            this.a01 = row1.L2;
            this.a02 = row1.L3;
            this.a03 = row1.L4;
            this.a10 = row2.L1;
            this.a11 = row2.L2;
            this.a12 = row2.L3;
            this.a13 = row2.L4;
            this.a20 = row3.L1;
            this.a21 = row3.L2;
            this.a22 = row3.L3;
            this.a23 = row3.L4;
            this.a30 = row4.L1;
            this.a31 = row4.L2;
            this.a32 = row4.L3;
            this.a33 = row4.L4;
        }

        public char A00
        {
            get { return this.a00; }
        }

        public char A01
        {
            get { return this.a01; }
        }

        public char A02
        {
            get { return this.a02; }
        }

        public char A03
        {
            get { return this.a03; }
        }

        public char A10
        {
            get { return this.a10; }
        }

        public char A11
        {
            get { return this.a11; }
        }

        public char A12
        {
            get { return this.a12; }
        }

        public char A13
        {
            get { return this.a13; }
        }

        public char A20
        {
            get { return this.a20; }
        }

        public char A21
        {
            get { return this.a21; }
        }

        public char A22
        {
            get { return this.a22; }
        }

        public char A23
        {
            get { return this.a23; }
        }

        public char A30
        {
            get { return this.a30; }
        }

        public char A31
        {
            get { return this.a31; }
        }

        public char A32
        {
            get { return this.a32; }
        }

        public char A33
        {
            get { return this.a33; }
        }

        public Word4 Row1
        {
            get { return new Word4(this.a00, this.a01, this.a02, this.a03); }
        }

        public Word4 Row2
        {
            get { return new Word4(this.a10, this.a11, this.a12, this.a13); }
        }
        
        public Word4 Row3
        {
            get { return new Word4(this.a20, this.a21, this.a22, this.a23); }
        }
        
        public Word4 Row4
        {
            get { return new Word4(this.a30, this.a31, this.a32, this.a33); }
        }

        public Word4 Column1
        {
            get { return new Word4(this.a00, this.a10, this.a20, this.a30); }
        }

        public Word4 Column2
        {
            get { return new Word4(this.a01, this.a11, this.a21, this.a31); }
        }

        public Word4 Column3
        {
            get { return new Word4(this.a02, this.a12, this.a22, this.a32); }
        }

        public Word4 Column4
        {
            get { return new Word4(this.a03, this.a13, this.a23, this.a33); }
        }

        public Word4Grid Transpose()
        {
            return new Word4Grid(this.Column1, this.Column2, this.Column3, this.Column4);
        }

        public bool Equals(Word4Grid other)
        {
            return
                (this.a00 == other.a00) &&
                (this.a01 == other.a01) &&
                (this.a02 == other.a02) &&
                (this.a03 == other.a03) &&
                (this.a10 == other.a10) &&
                (this.a11 == other.a11) &&
                (this.a12 == other.a12) &&
                (this.a13 == other.a13) &&
                (this.a20 == other.a20) &&
                (this.a21 == other.a21) &&
                (this.a22 == other.a22) &&
                (this.a23 == other.a23) &&
                (this.a30 == other.a30) &&
                (this.a31 == other.a31) &&
                (this.a32 == other.a32) &&
                (this.a33 == other.a33);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            this.WriteBlocks(b => sb.AppendLine(b));
            sb.Remove(sb.Length - 2, 2);
            return sb.ToString();
        }

        public void WriteBlocks(Action<string> onBlock)
        {
            onBlock(this.Row1.ToString());
            onBlock(this.Row2.ToString());
            onBlock(this.Row3.ToString());
            onBlock(this.Row4.ToString());
        }
    }
}
