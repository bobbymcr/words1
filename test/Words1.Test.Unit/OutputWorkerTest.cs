//-----------------------------------------------------------------------
// <copyright file="OutputWorkerTest.cs" company="Brian Rogers">
// Copyright (c) Brian Rogers. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Words1.Test.Unit
{
    using System;
    using System.Collections.Generic;
    using Xunit;

    public class OutputWorkerTest
    {
        public OutputWorkerTest()
        {
        }

        [Fact]
        public void Run_RunsUntilSequenceEndsAndNotifiesOnUniqueFound()
        {
            OutputWorker<char, string> worker = new OutputWorker<char, string>(c => c.ToString());
            char[] inputs = new char[] { 'a', 'b', 'b', 'a', 'c' };

            List<char> items = new List<char>();
            worker.Run(inputs, c => items.Add(c));

            Assert.Equal(3, items.Count);
            Assert.Equal('a', items[0]);
            Assert.Equal('b', items[1]);
            Assert.Equal('c', items[2]);
            Assert.Equal(3, worker.UniqueCount);
        }
    }
}
