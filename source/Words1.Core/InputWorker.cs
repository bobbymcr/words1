//-----------------------------------------------------------------------
// <copyright file="InputWorker.cs" company="Brian Rogers">
// Copyright (c) Brian Rogers. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Words1
{
    using System;
    using System.Collections.Generic;

    public class InputWorker<TInput, TOutput>
    {
        private readonly Action<TInput, Action<TOutput>> algorithm;

        public InputWorker(Action<TInput, Action<TOutput>> algorithm)
        {
            this.algorithm = algorithm;
        }

        public void Run(IEnumerable<TInput> inputSequence, Action<TOutput> onFound)
        {
            foreach (TInput input in inputSequence)
            {
                this.algorithm(input, onFound);
            }
        }
    }
}
