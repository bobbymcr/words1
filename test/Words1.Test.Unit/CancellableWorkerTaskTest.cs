//-----------------------------------------------------------------------
// <copyright file="CancellableWorkerTaskTest.cs" company="Brian Rogers">
// Copyright (c) Brian Rogers. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Words1.Test.Unit
{
    using System;
    using System.Threading.Tasks;
    using Xunit;

    public class CancellableWorkerTaskTest
    {
        public CancellableWorkerTaskTest()
        {
        }

        [Fact]
        public void Complete_SucceedsIfTaskThrowsOperationCanceled()
        {
            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();
            WorkerTask workerTask = new CancellableWorkerTask(tcs.Task);

            tcs.SetException(new OperationCanceledException());

            workerTask.Complete();
        }
    }
}
