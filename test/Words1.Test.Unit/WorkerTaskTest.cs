//-----------------------------------------------------------------------
// <copyright file="WorkerTaskTest.cs" company="Brian Rogers">
// Copyright (c) Brian Rogers. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Words1.Test.Unit
{
    using System;
    using System.Threading.Tasks;
    using Xunit;

    public class WorkerTaskTest
    {
        public WorkerTaskTest()
        {
        }

        [Fact]
        public void Complete_ThrowsIfNotCompletedSucceedsOtherwise()
        {
            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();
            WorkerTask workerTask = new WorkerTask(tcs.Task);

            Exception e = Record.Exception(() => workerTask.Complete());
            Assert.NotNull(e);
            Assert.IsType<InvalidOperationException>(e);

            tcs.SetResult(true);

            workerTask.Complete();
        }

        [Fact]
        public void Complete_ThrowsIfTaskFaulted()
        {
            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();
            WorkerTask workerTask = new WorkerTask(tcs.Task);
            InvalidTimeZoneException expectedException = new InvalidTimeZoneException("expected");

            tcs.SetException(expectedException);

            Exception e = Record.Exception(() => workerTask.Complete());
            Assert.NotNull(e);
            AggregateException ae = Assert.IsType<AggregateException>(e);
            Assert.Equal(1, ae.InnerExceptions.Count);
            Assert.Same(expectedException, ae.InnerExceptions[0]);
        }
    }
}
