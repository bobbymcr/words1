//-----------------------------------------------------------------------
// <copyright file="CancellableWorkerTask.cs" company="Brian Rogers">
// Copyright (c) Brian Rogers. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Words1
{
    using System;
    using System.Threading.Tasks;

    public class CancellableWorkerTask : WorkerTask
    {
        public CancellableWorkerTask(Task task)
            : base(task)
        {
        }

        public override void Complete()
        {
            try
            {
                base.Complete();
            }
            catch (AggregateException ae)
            {                    
                ae.Handle(e => e is OperationCanceledException);
            }
        }
    }
}
