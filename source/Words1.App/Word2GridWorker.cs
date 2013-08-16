//-----------------------------------------------------------------------
// <copyright file="Word2GridWorker.cs" company="Brian Rogers">
// Copyright (c) Brian Rogers. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Words1
{
    using System;

    internal sealed class Word2GridWorker : GridWorker<Word2, Word2Grid, CrunchedWord2Grid>
    {
        private readonly Word2GridFinder finder;
        private readonly Word2GridCruncher cruncher;

        public Word2GridWorker(Word2GridFinder finder, Word2GridCruncher cruncher, Logger logger, int workerCount)
            : base(logger, workerCount)
        {
            this.finder = finder;
            this.cruncher = cruncher;
        }

        protected override void Find(Word2 input, Action<Word2Grid> onFound)
        {
            this.finder.Find(input, onFound);
        }

        protected override CrunchedWord2Grid Crunch(Word2Grid input)
        {
            return this.cruncher.Crunch(input);
        }
    }
}
