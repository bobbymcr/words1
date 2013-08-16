//-----------------------------------------------------------------------
// <copyright file="Word3Test.cs" company="Brian Rogers">
// Copyright (c) Brian Rogers. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Words1.Test.Unit
{
    using System;
    using Xunit;

    public class Word3Test
    {
        public Word3Test()
        {
        }

        [Fact]
        public void Construct_FromString_SetsPropertyValues()
        {
            Word3 c = new Word3("abc");
            
            Assert.Equal('a', c.L1);
            Assert.Equal('b', c.L2);
            Assert.Equal('c', c.L3);
        }

        [Fact]
        public void Construct_FromChars_SetsPropertyValues()
        {
            Word3 c = new Word3('a', 'b', 'c');

            Assert.Equal('a', c.L1);
            Assert.Equal('b', c.L2);
            Assert.Equal('c', c.L3);
        }

        [Fact]
        public void Construct_WordTooLong_ThrowsArgument()
        {
            Exception e = Record.Exception(() => new Word3("long"));
            Assert.NotNull(e);
            ArgumentException ae = Assert.IsType<ArgumentException>(e);
            Assert.Equal("word", ae.ParamName);
        }

        [Fact]
        public void Construct_WordTooShort_ThrowsArgument()
        {
            Exception e = Record.Exception(() => new Word3("a"));
            Assert.NotNull(e);
            ArgumentException ae = Assert.IsType<ArgumentException>(e);
            Assert.Equal("word", ae.ParamName);
        }

        [Fact]
        public void Construct_NullWord_ThrowsArgumentNull()
        {
            string word = null;
            Exception e = Record.Exception(() => new Word3(word));
            Assert.NotNull(e);
            ArgumentNullException ane = Assert.IsType<ArgumentNullException>(e);
            Assert.Equal("word", ane.ParamName);
        }

        [Fact]
        public void ToString_ReturnsWord()
        {
            Word3 word = new Word3("abc");

            Assert.Equal("abc", word.ToString());
        }

        [Fact]
        public void GetHashCode_UniqueUnlessValuesAreEqual()
        {
            Word3 one = new Word3("one");
            Word3 oneA = new Word3("one");
            Word3 two = new Word3("two");
            Word3 twoA = new Word3("two");

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
            Word3 one = new Word3("one");
            Word3 oneA = new Word3("one");
            Word3 two = new Word3("two");
            Word3 twoA = new Word3("two");
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
            Word3 one = new Word3("aaa");
            Word3 two = new Word3("aab");
            Word3 three = new Word3("baa");
            Word3 four = new Word3("bba");

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
