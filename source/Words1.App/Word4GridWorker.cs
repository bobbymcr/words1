//-----------------------------------------------------------------------
// <copyright file="Word4GridWorker.cs" company="Brian Rogers">
// Copyright (c) Brian Rogers. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Words1
{
    using System;

    internal sealed class Word4GridWorker : GridWorker<Word4, Word4Grid, CrunchedWord4Grid>
    {
        private readonly Word4GridFinder finder;
        private readonly Word4GridCruncher cruncher;

        public Word4GridWorker(Word4GridFinder finder, Word4GridCruncher cruncher, Logger logger, int workerCount)
            : base(logger, workerCount)
        {
            this.finder = finder;
            this.cruncher = cruncher;
        }

        protected override void Find(Word4 input, Action<Word4Grid> onFound)
        {
            this.finder.Find(input, onFound);
        }

        protected override CrunchedWord4Grid Crunch(Word4Grid input)
        {
            return this.cruncher.Crunch(input);
        }
    }
}
