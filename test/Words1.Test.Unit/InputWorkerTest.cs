//-----------------------------------------------------------------------
// <copyright file="InputWorkerTest.cs" company="Brian Rogers">
// Copyright (c) Brian Rogers. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Words1.Test.Unit
{
    using System;
    using System.Collections.Generic;
    using Xunit;

    public class InputWorkerTest
    {
        public InputWorkerTest()
        {
        }

        [Fact]
        public void Run_RunsUntilSequenceEndsInvokingAlgorithmForEach()
        {
            List<int> inputs = new List<int>();
            Action<int, Action<string>> algorithm = delegate(int input, Action<string> onFound)
            {
                inputs.Add(input);
                onFound(input.ToString());
            };

            InputWorker<int, string> worker = new InputWorker<int, string>(algorithm);

            int onFoundCount = 0;
            worker.Run(new int[] { 1, 2 }, s => ++onFoundCount);

            Assert.Equal(2, onFoundCount);
            Assert.Equal(2, inputs.Count);
            Assert.Equal(new int[] { 1, 2 }, inputs.ToArray());
        }
    }
}
