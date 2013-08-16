//-----------------------------------------------------------------------
// <copyright file="BlockWriter.cs" company="Brian Rogers">
// Copyright (c) Brian Rogers. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Words1
{
    using System.IO;
    using System.Text;

    public class BlockWriter
    {
        private readonly TextWriter writer;
        private readonly int columns;
        private readonly StringBuilder[] buffers;

        private int currentIndex;

        public BlockWriter(TextWriter writer, int lines, int columns)
        {
            this.writer = writer;
            this.columns = columns;
            this.buffers = new StringBuilder[lines];
            for (int i = 0; i < this.buffers.Length; ++i)
            {
                this.buffers[i] = new StringBuilder();
            }

            this.currentIndex = -1;
        }

        public void Write(string text)
        {
            StringBuilder buffer = this.NextBuffer();
            if ((buffer.Length + text.Length) > this.columns)
            {
                this.Flush();
            }

            buffer.Append(text);
        }

        public void Flush()
        {
            foreach (StringBuilder buffer in this.buffers)
            {
                this.writer.WriteLine(buffer.ToString());
                buffer.Clear();
            }

            this.writer.WriteLine();
        }

        private StringBuilder NextBuffer()
        {
            ++this.currentIndex;
            if (this.currentIndex == this.buffers.Length)
            {
                this.currentIndex = 0;
            }

            return this.buffers[this.currentIndex];
        }
    }
}
