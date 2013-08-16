//-----------------------------------------------------------------------
// <copyright file="TaskChainTest.cs" company="Brian Rogers">
// Copyright (c) Brian Rogers. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Words1.Test.Unit
{
    using System;
    using System.Threading.Tasks;
    using Xunit;

    public class TaskChainTest
    {
        public TaskChainTest()
        {
        }

        [Fact]
        public void RunAsync_RunsTasksInSequenceAndCompletesAfterAction()
        {
            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();
            bool done = false;
            TaskChain chain = new TaskChain(() => tcs.Task, () => done = true);

            Task task = chain.RunAsync();

            Assert.False(task.IsCompleted);
            Assert.False(done);

            tcs.SetResult(true);

            Assert.True(task.IsCompleted);
            Assert.False(task.IsFaulted);
            Assert.True(done);
        }

        [Fact]
        public void RunAsync_ExceptionInFirstTask_ThrowsExceptionSkipsAction()
        {
            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();
            bool done = false;
            InvalidTimeZoneException expectedException = new InvalidTimeZoneException("expected");
            TaskChain chain = new TaskChain(() => tcs.Task, () => done = true);

            Task task = chain.RunAsync();

            tcs.SetException(expectedException);

            Assert.True(task.IsCompleted);
            Assert.True(task.IsFaulted);
            AggregateException ae = Assert.IsType<AggregateException>(task.Exception).Flatten();
            Assert.Equal(1, ae.InnerExceptions.Count);
            Assert.Same(expectedException, ae.InnerExceptions[0]);
            Assert.False(done);
        }
    }
}
