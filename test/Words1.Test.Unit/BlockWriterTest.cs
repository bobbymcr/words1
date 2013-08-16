//-----------------------------------------------------------------------
// <copyright file="BlockWriterTest.cs" company="Brian Rogers">
// Copyright (c) Brian Rogers. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Words1.Test.Unit
{
    using System.IO;
    using System.Text;
    using Xunit;

    public class BlockWriterTest
    {
        public BlockWriterTest()
        {
        }

        [Fact]
        public void WriteAndFlush_WritesInOrderToEachLineUntilMaxLengthExceeded()
        {
            StringBuilder sb = new StringBuilder();
            using (StringWriter writer = new StringWriter(sb))
            {
                BlockWriter blockWriter = new BlockWriter(writer, 2, 13);
                blockWriter.Write("a234567 ");
                blockWriter.Write("b234567 ");
                blockWriter.Write("c012 ");
                blockWriter.Write("d012 ");
                blockWriter.Write("e5 ");
                blockWriter.Write("f5 ");

                Assert.Equal("a234567 c012 \r\nb234567 d012 \r\n\r\n", sb.ToString());

                blockWriter.Flush();

                Assert.Equal("a234567 c012 \r\nb234567 d012 \r\n\r\ne5 \r\nf5 \r\n\r\n", sb.ToString());
            }
        }
    }
}
