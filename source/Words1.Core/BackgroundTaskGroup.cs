//-----------------------------------------------------------------------
// <copyright file="BackgroundTaskGroup.cs" company="Brian Rogers">
// Copyright (c) Brian Rogers. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Words1
{
    using System;
    using System.Threading.Tasks;

    public class BackgroundTaskGroup
    {
        private readonly int count;
        private readonly Func<Task> createTask;

        public BackgroundTaskGroup(int count, Func<Task> createTask)
        {
            this.count = count;
            this.createTask = createTask;
        }

        public Task RunAsync()
        {
            Task[] tasks = new Task[this.count];
            for (int i = 0; i < this.count; ++i)
            {
                tasks[i] = this.createTask();
            }

            return Task.WhenAll(tasks);
        }
    }
}
