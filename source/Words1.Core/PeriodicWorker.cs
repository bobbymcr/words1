//-----------------------------------------------------------------------
// <copyright file="PeriodicWorker.cs" company="Brian Rogers">
// Copyright (c) Brian Rogers. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Words1
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public class PeriodicWorker
    {
        private static readonly IAsyncWaiter DefaultWaiter = new DefaultAsyncWaiter();

        private readonly Action action;
        private readonly IAsyncWaiter waiter;

        public PeriodicWorker(Action action)
            : this(action, DefaultWaiter)
        {
        }

        public PeriodicWorker(Action action, IAsyncWaiter waiter)
        {
            this.action = action;
            this.waiter = waiter;
        }

        public async Task RunAsync(TimeSpan statusInterval, CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                await this.waiter.WaitAsync(statusInterval, token);
                this.action();
            }
        }

        private sealed class DefaultAsyncWaiter : IAsyncWaiter
        {
            public DefaultAsyncWaiter()
            {
            }

            public Task WaitAsync(TimeSpan interval, CancellationToken token)
            {
                return Task.Delay(interval, token);
            }
        }
    }
}
