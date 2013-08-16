//-----------------------------------------------------------------------
// <copyright file="Word4Test.cs" company="Brian Rogers">
// Copyright (c) Brian Rogers. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Words1.Test.Unit
{
    using System;
    using Xunit;

    public class Word4Test
    {
        public Word4Test()
        {
        }

        [Fact]
        public void Construct_FromString_SetsPropertyValues()
        {
            Word4 c = new Word4("abcd");
            
            Assert.Equal('a', c.L1);
            Assert.Equal('b', c.L2);
            Assert.Equal('c', c.L3);
            Assert.Equal('d', c.L4);
        }

        [Fact]
        public void Construct_FromChars_SetsPropertyValues()
        {
            Word4 c = new Word4('a', 'b', 'c', 'd');

            Assert.Equal('a', c.L1);
            Assert.Equal('b', c.L2);
            Assert.Equal('c', c.L3);
            Assert.Equal('d', c.L4);
        }

        [Fact]
        public void Construct_WordTooLong_ThrowsArgument()
        {
            Exception e = Record.Exception(() => new Word4("longer"));
            Assert.NotNull(e);
            ArgumentException ae = Assert.IsType<ArgumentException>(e);
            Assert.Equal("word", ae.ParamName);
        }

        [Fact]
        public void Construct_WordTooShort_ThrowsArgument()
        {
            Exception e = Record.Exception(() => new Word4("a"));
            Assert.NotNull(e);
            ArgumentException ae = Assert.IsType<ArgumentException>(e);
            Assert.Equal("word", ae.ParamName);
        }

        [Fact]
        public void Construct_NullWord_ThrowsArgumentNull()
        {
            string word = null;
            Exception e = Record.Exception(() => new Word4(word));
            Assert.NotNull(e);
            ArgumentNullException ane = Assert.IsType<ArgumentNullException>(e);
            Assert.Equal("word", ane.ParamName);
        }

        [Fact]
        public void ToString_ReturnsWord()
        {
            Word4 word = new Word4("abcd");

            Assert.Equal("abcd", word.ToString());
        }

        [Fact]
        public void GetHashCode_UniqueUnlessValuesAreEqual()
        {
            Word4 one = new Word4("onea");
            Word4 oneA = new Word4("onea");
            Word4 two = new Word4("twoa");
            Word4 twoA = new Word4("twoa");

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
            Word4 one = new Word4("onea");
            Word4 oneA = new Word4("onea");
            Word4 two = new Word4("twoa");
            Word4 twoA = new Word4("twoa");
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
            Word4 one = new Word4("aaaa");
            Word4 two = new Word4("aaab");
            Word4 three = new Word4("baaa");
            Word4 four = new Word4("bbaa");
            Word4 five = new Word4("bbba");

            Assert.True(one.CompareTo(one) == 0);
            Assert.True(one.CompareTo(two) < 0);
            Assert.True(one.CompareTo(three) < 0);
            Assert.True(one.CompareTo(four) < 0);
            Assert.True(one.CompareTo(five) < 0);
            
            Assert.True(two.CompareTo(one) > 0);
            Assert.True(two.CompareTo(two) == 0);
            Assert.True(two.CompareTo(three) < 0);
            Assert.True(two.CompareTo(four) < 0);
            Assert.True(two.CompareTo(five) < 0);
            
            Assert.True(three.CompareTo(one) > 0);
            Assert.True(three.CompareTo(two) > 0);
            Assert.True(three.CompareTo(three) == 0);
            Assert.True(three.CompareTo(four) < 0);
            Assert.True(three.CompareTo(five) < 0);
            
            Assert.True(four.CompareTo(one) > 0);
            Assert.True(four.CompareTo(two) > 0);
            Assert.True(four.CompareTo(three) > 0);
            Assert.True(four.CompareTo(four) == 0);
            Assert.True(four.CompareTo(five) < 0);

            Assert.True(five.CompareTo(one) > 0);
            Assert.True(five.CompareTo(two) > 0);
            Assert.True(five.CompareTo(three) > 0);
            Assert.True(five.CompareTo(four) > 0);
            Assert.True(five.CompareTo(five) == 0);
        }
    }
}
