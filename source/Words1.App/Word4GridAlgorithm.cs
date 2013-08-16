//-----------------------------------------------------------------------
// <copyright file="Word4GridAlgorithm.cs" company="Brian Rogers">
// Copyright (c) Brian Rogers. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Words1
{
    using System;

    internal sealed class Word4GridAlgorithm : GridAlgorithm<Word4, Word4Grid, CrunchedWord4Grid>
    {
        public Word4GridAlgorithm(Logger logger, BlockWriter writer)
            : base(logger, writer)
        {
        }

        protected override void LoadWord(string input, Action<Word4> onFound)
        {
            Word4Loader.Load(input, onFound);
        }

        protected override GridWorker<Word4, Word4Grid, CrunchedWord4Grid> CreateWorker(int workerCount, bool allowDuplicateWords)
        {
            return new Word4GridWorker(new Word4GridFinder(new Word4Trie(this.Table), allowDuplicateWords), new Word4GridCruncher(this.Table), this.Logger, workerCount);
        }

        protected override void OnFound(Word4Grid grid)
        {
            grid.WriteBlocks(this.OnOutputText);
        }
    }
}
