//-----------------------------------------------------------------------
// <copyright file="Word3Grid.cs" company="Brian Rogers">
// Copyright (c) Brian Rogers. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Words1
{
    using System;
    using System.Text;

    public struct Word3Grid : IEquatable<Word3Grid>
    {
        private readonly char a00;
        private readonly char a01;
        private readonly char a02;
        private readonly char a10;
        private readonly char a11;
        private readonly char a12;
        private readonly char a20;
        private readonly char a21;
        private readonly char a22;

        public Word3Grid(Word3 row1, Word3 row2, Word3 row3)
        {
            this.a00 = row1.L1;
            this.a01 = row1.L2;
            this.a02 = row1.L3;
            this.a10 = row2.L1;
            this.a11 = row2.L2;
            this.a12 = row2.L3;
            this.a20 = row3.L1;
            this.a21 = row3.L2;
            this.a22 = row3.L3;
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

        public Word3 Row1
        {
            get { return new Word3(this.a00, this.a01, this.a02); }
        }

        public Word3 Row2
        {
            get { return new Word3(this.a10, this.a11, this.a12); }
        }
        
        public Word3 Row3
        {
            get { return new Word3(this.a20, this.a21, this.a22); }
        }
        
        public Word3 Column1
        {
            get { return new Word3(this.a00, this.a10, this.a20); }
        }

        public Word3 Column2
        {
            get { return new Word3(this.a01, this.a11, this.a21); }
        }

        public Word3 Column3
        {
            get { return new Word3(this.a02, this.a12, this.a22); }
        }

        public Word3Grid Transpose()
        {
            return new Word3Grid(this.Column1, this.Column2, this.Column3);
        }

        public bool Equals(Word3Grid other)
        {
            return
                (this.a00 == other.a00) &&
                (this.a01 == other.a01) &&
                (this.a02 == other.a02) &&
                (this.a10 == other.a10) &&
                (this.a11 == other.a11) &&
                (this.a12 == other.a12) &&
                (this.a20 == other.a20) &&
                (this.a21 == other.a21) &&
                (this.a22 == other.a22);
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
            onText(this.Row3.ToString());
        }
    }
}
