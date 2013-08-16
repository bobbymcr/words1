//-----------------------------------------------------------------------
// <copyright file="Word3GridWorker.cs" company="Brian Rogers">
// Copyright (c) Brian Rogers. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Words1
{
    using System;

    internal sealed class Word3GridWorker : GridWorker<Word3, Word3Grid, CrunchedWord3Grid>
    {
        private readonly Word3GridFinder finder;
        private readonly Word3GridCruncher cruncher;

        public Word3GridWorker(Word3GridFinder finder, Word3GridCruncher cruncher, Logger logger, int workerCount)
            : base(logger, workerCount)
        {
            this.finder = finder;
            this.cruncher = cruncher;
        }

        protected override void Find(Word3 input, Action<Word3Grid> onFound)
        {
            this.finder.Find(input, onFound);
        }

        protected override CrunchedWord3Grid Crunch(Word3Grid input)
        {
            return this.cruncher.Crunch(input);
        }
    }
}
