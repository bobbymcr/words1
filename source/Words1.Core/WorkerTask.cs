//-----------------------------------------------------------------------
// <copyright file="WorkerTask.cs" company="Brian Rogers">
// Copyright (c) Brian Rogers. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Words1
{
    using System;
    using System.Threading.Tasks;

    public class WorkerTask
    {
        private readonly Task task;

        public WorkerTask(Task task)
        {
            this.task = task;
        }

        public virtual void Complete()
        {
            if (!this.task.IsCompleted)
            {
                throw new InvalidOperationException("Task should be completed.");
            }

            this.task.Wait();
        }
    }
}
