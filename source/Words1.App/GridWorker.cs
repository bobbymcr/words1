//-----------------------------------------------------------------------
// <copyright file="GridWorker.cs" company="Brian Rogers">
// Copyright (c) Brian Rogers. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Words1
{
    using System;
    using System.Collections.Concurrent;
    using System.Threading;
    using System.Threading.Tasks;

    internal abstract class GridWorker<TWord, TGrid, TCrunchedGrid>
    {
        private readonly Logger logger;
        private readonly int workerCount;

        protected GridWorker(Logger logger, int workerCount)
        {
            this.logger = logger;
            this.workerCount = workerCount;
        }

        public void Run(InputData<TWord> inputData, Action<TGrid> onFound)
        {
            using (BlockingCollection<TGrid> outputQueue = new BlockingCollection<TGrid>())
            {
                InputWorker<TWord, TGrid> worker = new InputWorker<TWord, TGrid>(this.Find);
                Action inputAction = () => worker.Run(inputData, g => outputQueue.Add(g));
                BackgroundTaskGroup inputWorkers = new BackgroundTaskGroup(this.workerCount, () => Task.Factory.StartNew(inputAction, TaskCreationOptions.LongRunning));
                TaskChain inputTaskChain = new TaskChain(() => inputWorkers.RunAsync(), () => outputQueue.CompleteAdding());                
                WorkerTask inputWorkersTask = new WorkerTask(inputTaskChain.RunAsync());

                OutputWorker<TGrid, TCrunchedGrid> outputWorker = new OutputWorker<TGrid, TCrunchedGrid>(this.Crunch);

                Action statusAction = () => this.logger.Log("{0} words left, {1} unique grids found, output queue length={2}.", inputData.Count, outputWorker.UniqueCount, outputQueue.Count);
                PeriodicWorker statusWorker = new PeriodicWorker(statusAction);
                using (CancellationTokenSource cts = new CancellationTokenSource())
                {
                    WorkerTask statusWorkerTask = new CancellableWorkerTask(statusWorker.RunAsync(TimeSpan.FromSeconds(1.0d), cts.Token));
                    outputWorker.Run(outputQueue.GetConsumingEnumerable(), g => onFound(g));
                    cts.Cancel();
                    inputWorkersTask.Complete();
                    statusWorkerTask.Complete();
                }

                this.logger.Log("Output worker has completed; found {0} unique grids.", outputWorker.UniqueCount);
            }
        }

        protected abstract void Find(TWord input, Action<TGrid> onFound);

        protected abstract TCrunchedGrid Crunch(TGrid input); 
    }
}
