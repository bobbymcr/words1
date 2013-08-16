//-----------------------------------------------------------------------
// <copyright file="TaskChain.cs" company="Brian Rogers">
// Copyright (c) Brian Rogers. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Words1
{
    using System;
    using System.Threading.Tasks;

    public class TaskChain
    {
        private readonly Func<Task> createTask;
        private readonly Action afterTask;

        public TaskChain(Func<Task> createTask, Action afterTask)
        {
            this.createTask = createTask;
            this.afterTask = afterTask;
        }

        public Task RunAsync()
        {
            return this.createTask().ContinueWith(t => this.AfterTaskInner(t), TaskContinuationOptions.ExecuteSynchronously);
        }

        private void AfterTaskInner(Task task)
        {
            task.Wait();
            this.afterTask();
        }
    }
}
