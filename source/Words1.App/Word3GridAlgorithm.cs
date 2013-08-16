//-----------------------------------------------------------------------
// <copyright file="Word3GridAlgorithm.cs" company="Brian Rogers">
// Copyright (c) Brian Rogers. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Words1
{
    using System;

    internal sealed class Word3GridAlgorithm : GridAlgorithm<Word3, Word3Grid, CrunchedWord3Grid>
    {
        public Word3GridAlgorithm(Logger logger, BlockWriter writer)
            : base(logger, writer)
        {
        }

        protected override void LoadWord(string input, Action<Word3> onFound)
        {
            Word3Loader.Load(input, onFound);
        }

        protected override GridWorker<Word3, Word3Grid, CrunchedWord3Grid> CreateWorker(int workerCount, bool allowDuplicateWords)
        {
            return new Word3GridWorker(new Word3GridFinder(new Word3Trie(this.Table), allowDuplicateWords), new Word3GridCruncher(this.Table), this.Logger, workerCount);
        }

        protected override void OnFound(Word3Grid grid)
        {
            grid.WriteBlock(this.OnOutputText);
        }
    }
}
