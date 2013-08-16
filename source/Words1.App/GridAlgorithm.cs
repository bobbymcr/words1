//-----------------------------------------------------------------------
// <copyright file="GridAlgorithm.cs" company="Brian Rogers">
// Copyright (c) Brian Rogers. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Words1
{
    using System;
    using System.IO;

    internal abstract class GridAlgorithm<TWord, TGrid, TCrunchedGrid> : IGridAlgorithm
    {
        private readonly Logger logger;
        private readonly BlockWriter blockWriter;
        private SortedTable<TWord> table;

        protected GridAlgorithm(Logger logger, BlockWriter blockWriter)
        {
            this.logger = logger;
            this.blockWriter = blockWriter;
        }

        protected SortedTable<TWord> Table
        {
            get { return this.table; }
        }

        protected Logger Logger
        {
            get { return this.logger; }
        }

        public void Load(string fileName)
        {
            this.table = new SortedTable<TWord>();
            LoadFromFile(fileName, s => this.LoadWord(s, w => this.table.Add(w)));
            this.logger.Log("Loaded {0} words.", this.table.Count);
        }

        public void Run(int workerCount, bool allowDuplicateWords)
        {
            using (InputData<TWord> inputData = new InputData<TWord>(this.table))
            {
                GridWorker<TWord, TGrid, TCrunchedGrid> worker = this.CreateWorker(workerCount, allowDuplicateWords);
                worker.Run(inputData, this.OnFound);
            }
        }

        protected abstract void LoadWord(string input, Action<TWord> onFound);

        protected abstract GridWorker<TWord, TGrid, TCrunchedGrid> CreateWorker(int workerCount, bool allowDuplicateWords);

        protected abstract void OnFound(TGrid grid);

        protected void OnOutputText(string text)
        {
            this.blockWriter.Write(text + " ");
        }

        private static void LoadFromFile(string fileName, Action<string> load)
        {
            using (StreamReader reader = new StreamReader(fileName))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    load(line);
                }
            }
        }
    }
}
