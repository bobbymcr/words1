//-----------------------------------------------------------------------
// <copyright file="OutputWorker.cs" company="Brian Rogers">
// Copyright (c) Brian Rogers. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Words1
{
    using System;
    using System.Collections.Generic;

    public class OutputWorker<TInput, TOutput>
    {
        private readonly Func<TInput, TOutput> transform;
        private readonly SortedSet<TOutput> transformedItems;

        public OutputWorker(Func<TInput, TOutput> transform)
        {
            this.transform = transform;
            this.transformedItems = new SortedSet<TOutput>();
        }

        public int UniqueCount
        {
            get { return this.transformedItems.Count; }
        }

        public void Run(IEnumerable<TInput> inputSequence, Action<TInput> onUnique)
        {
            foreach (TInput input in inputSequence)
            {
                if (this.transformedItems.Add(this.transform(input)))
                {
                    onUnique(input);
                }
            }
        }
    }
}
