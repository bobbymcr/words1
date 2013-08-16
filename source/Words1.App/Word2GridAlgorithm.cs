//-----------------------------------------------------------------------
// <copyright file="Word2GridAlgorithm.cs" company="Brian Rogers">
// Copyright (c) Brian Rogers. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Words1
{
    using System;

    internal sealed class Word2GridAlgorithm : GridAlgorithm<Word2, Word2Grid, CrunchedWord2Grid>
    {
        public Word2GridAlgorithm(Logger logger, BlockWriter writer)
            : base(logger, writer)
        {
        }

        protected override void LoadWord(string input, Action<Word2> onFound)
        {
            Word2Loader.Load(input, onFound);
        }

        protected override GridWorker<Word2, Word2Grid, CrunchedWord2Grid> CreateWorker(int workerCount, bool allowDuplicateWords)
        {
            return new Word2GridWorker(new Word2GridFinder(new Word2Trie(this.Table), allowDuplicateWords), new Word2GridCruncher(this.Table), this.Logger, workerCount);
        }

        protected override void OnFound(Word2Grid grid)
        {
            grid.WriteBlock(this.OnOutputText);
        }
    }
}
