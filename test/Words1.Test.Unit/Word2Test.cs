//-----------------------------------------------------------------------
// <copyright file="Word2Test.cs" company="Brian Rogers">
// Copyright (c) Brian Rogers. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Words1.Test.Unit
{
    using System;
    using Xunit;

    public class Word2Test
    {
        public Word2Test()
        {
        }

        [Fact]
        public void Construct_FromString_SetsPropertyValues()
        {
            Word2 c = new Word2("ab");
            
            Assert.Equal('a', c.L1);
            Assert.Equal('b', c.L2);
        }

        [Fact]
        public void Construct_FromChars_SetsPropertyValues()
        {
            Word2 c = new Word2('a', 'b');

            Assert.Equal('a', c.L1);
            Assert.Equal('b', c.L2);
        }

        [Fact]
        public void Construct_WordTooLong_ThrowsArgument()
        {
            Exception e = Record.Exception(() => new Word2("long"));
            Assert.NotNull(e);
            ArgumentException ae = Assert.IsType<ArgumentException>(e);
            Assert.Equal("word", ae.ParamName);
        }

        [Fact]
        public void Construct_WordTooShort_ThrowsArgument()
        {
            Exception e = Record.Exception(() => new Word2("a"));
            Assert.NotNull(e);
            ArgumentException ae = Assert.IsType<ArgumentException>(e);
            Assert.Equal("word", ae.ParamName);
        }

        [Fact]
        public void Construct_NullWord_ThrowsArgumentNull()
        {
            string word = null;
            Exception e = Record.Exception(() => new Word2(word));
            Assert.NotNull(e);
            ArgumentNullException ane = Assert.IsType<ArgumentNullException>(e);
            Assert.Equal("word", ane.ParamName);
        }

        [Fact]
        public void ToString_ReturnsWord()
        {
            Word2 word = new Word2("ab");

            Assert.Equal("ab", word.ToString());
        }

        [Fact]
        public void GetHashCode_UniqueUnlessValuesAreEqual()
        {
            Word2 one = new Word2("on");
            Word2 oneA = new Word2("on");
            Word2 two = new Word2("to");
            Word2 twoA = new Word2("to");

            int c1 = one.GetHashCode();
            int c2 = two.GetHashCode();
            int c1a = oneA.GetHashCode();
            int c2a = twoA.GetHashCode();

            Assert.Equal(c1, c1a);
            Assert.Equal(c2, c2a);
            Assert.NotEqual(c1, c2);
        }

        [Fact]
        public void Equals_ComparesCorrectly()
        {
            Word2 one = new Word2("on");
            Word2 oneA = new Word2("on");
            Word2 two = new Word2("to");
            Word2 twoA = new Word2("to");
            object twoO = two;

            Assert.True(one.Equals(oneA));
            Assert.True(oneA.Equals(one));
            Assert.True(two.Equals(twoA));
            Assert.True(twoA.Equals(two));
            Assert.True(two.Equals(twoO));

            Assert.False(one.Equals(two));
            Assert.False(two.Equals(one));
            Assert.False(two.Equals(null));
        }

        [Fact]
        public void CompareTo_ComparesCorrectly()
        {
            Word2 one = new Word2("aa");
            Word2 two = new Word2("ab");
            Word2 three = new Word2("ba");
            Word2 four = new Word2("bb");

            Assert.True(one.CompareTo(one) == 0);
            Assert.True(one.CompareTo(two) < 0);
            Assert.True(one.CompareTo(three) < 0);
            Assert.True(one.CompareTo(four) < 0);

            Assert.True(two.CompareTo(one) > 0);
            Assert.True(two.CompareTo(two) == 0);
            Assert.True(two.CompareTo(three) < 0);
            Assert.True(two.CompareTo(four) < 0);

            Assert.True(three.CompareTo(one) > 0);
            Assert.True(three.CompareTo(two) > 0);
            Assert.True(three.CompareTo(three) == 0);
            Assert.True(three.CompareTo(four) < 0);

            Assert.True(four.CompareTo(one) > 0);
            Assert.True(four.CompareTo(two) > 0);
            Assert.True(four.CompareTo(three) > 0);
            Assert.True(four.CompareTo(four) == 0);
        }
    }
}
