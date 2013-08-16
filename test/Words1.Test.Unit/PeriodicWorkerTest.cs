//-----------------------------------------------------------------------
// <copyright file="PeriodicWorkerTest.cs" company="Brian Rogers">
// Copyright (c) Brian Rogers. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Words1.Test.Unit
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Xunit;

    public class PeriodicWorkerTest
    {
        public PeriodicWorkerTest()
        {
        }

        [Fact]
        public void RunAsync_WaitsForIntervalAndExecutesActionUntilCanceled()
        {
            AsyncWaiterImpl waiter = new AsyncWaiterImpl();
            int actionCount = 0;
            PeriodicWorker worker = new PeriodicWorker(() => ++actionCount, waiter);

            using (CancellationTokenSource cts = new CancellationTokenSource())
            {
                Task task = worker.RunAsync(TimeSpan.FromSeconds(1.0d), cts.Token);

                Assert.Equal(0, actionCount);
                Assert.False(task.IsCompleted);
                Assert.Equal(1, waiter.Intervals.Count);
                Assert.Equal(TimeSpan.FromSeconds(1.0d), waiter.Intervals[0]);

                waiter.Complete();

                Assert.Equal(1, actionCount);
                Assert.False(task.IsCompleted);
                Assert.Equal(2, waiter.Intervals.Count);
                Assert.Equal(TimeSpan.FromSeconds(1.0d), waiter.Intervals[1]);

                cts.Cancel();
                waiter.Complete();

                Assert.Equal(2, actionCount);
                Assert.True(task.IsCompleted);
                Assert.False(task.IsFaulted);
                Assert.Equal(2, waiter.Intervals.Count);
            }
        }

        private sealed class AsyncWaiterImpl : IAsyncWaiter
        {
            private TaskCompletionSource<bool> tcs;

            public AsyncWaiterImpl()
            {
                this.Intervals = new List<TimeSpan>();
            }

            public IList<TimeSpan> Intervals { get; private set; }

            public void Complete()
            {
                this.tcs.SetResult(true);
            }

            public Task WaitAsync(TimeSpan interval, CancellationToken token)
            {
                token.ThrowIfCancellationRequested();
                this.Intervals.Add(interval);
                this.tcs = new TaskCompletionSource<bool>();
                return this.tcs.Task;
            }
        }
    }
}
