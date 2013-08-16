//-----------------------------------------------------------------------
// <copyright file="InputData.cs" company="Brian Rogers">
// Copyright (c) Brian Rogers. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Words1
{
    using System;
    using System.Collections;
    using System.Collections.Concurrent;
    using System.Collections.Generic;

    public sealed class InputData<T> : IEnumerable<T>, IDisposable
    {
        private readonly BlockingCollection<T> queue;

        public InputData(IEnumerable<T> items)
        {
            this.queue = new BlockingCollection<T>();
            foreach (T item in items)
            {
                this.queue.Add(item);
            }

            this.queue.CompleteAdding();
        }

        public int Count
        {
            get { return this.queue.Count; }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this.queue.GetConsumingEnumerable().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.queue.Dispose();
            }
        }
    }
}
