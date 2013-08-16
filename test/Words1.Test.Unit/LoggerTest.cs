//-----------------------------------------------------------------------
// <copyright file="LoggerTest.cs" company="Brian Rogers">
// Copyright (c) Brian Rogers. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Words1.Test.Unit
{
    using System;
    using System.IO;
    using System.Text;
    using Xunit;

    public class LoggerTest
    {
        public LoggerTest()
        {
        }

        [Fact]
        public void Log_WritesFormattedStringWithTimestamp()
        {
            StringBuilder sb = new StringBuilder();
            using (StringWriter writer = new StringWriter(sb))
            {
                Logger logger = new Logger(writer, () => new TimeSpan(0, 2, 3, 4, 5));
                logger.Log("Hello {0}{1}", 1, '!');
            }

            Assert.Equal("[02:03:04.005] Hello 1!\r\n", sb.ToString());
        }

        [Fact]
        public void Log_WritesStringWithTimestamp()
        {
            StringBuilder sb = new StringBuilder();
            using (StringWriter writer = new StringWriter(sb))
            {
                Logger logger = new Logger(writer, () => new TimeSpan(0, 0, 0, 11, 0));
                logger.Log("Hello!");
            }

            Assert.Equal("[00:00:11.000] Hello!\r\n", sb.ToString());
        }
    }
}
