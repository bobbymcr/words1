//-----------------------------------------------------------------------
// <copyright file="IAsyncWaiter.cs" company="Brian Rogers">
// Copyright (c) Brian Rogers. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Words1
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IAsyncWaiter
    {
        Task WaitAsync(TimeSpan interval, CancellationToken token);
    }
}
