//-----------------------------------------------------------------------
// <copyright file="InputDataTest.cs" company="Brian Rogers">
// Copyright (c) Brian Rogers. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Words1.Test.Unit
{
    using System;
    using System.Collections.Generic;
    using Xunit;

    public class InputDataTest
    {
        public InputDataTest()
        {
        }

        [Fact]
        public void Construct_AddsWordsToTableAndAllowsConsumptionViaEnumerable()
        {
            List<string> items = new List<string>();
            using (InputData<string> data = new InputData<string>(new string[] { "a", "b" }))
            {
                Assert.Equal(2, data.Count);

                foreach (string item in data)
                {
                    items.Add(item);
                }

                Assert.Equal(0, data.Count);
                Assert.Equal(2, items.Count);
                Assert.Equal("a", items[0]);
                Assert.Equal("b", items[1]);

                foreach (string item in data)
                {
                    Assert.True(false, "Should be empty.");
                }

                Assert.Equal(0, data.Count);
            }
        }
    }
}
