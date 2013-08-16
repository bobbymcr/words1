//-----------------------------------------------------------------------
// <copyright file="BackgroundTaskGroupTest.cs" company="Brian Rogers">
// Copyright (c) Brian Rogers. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Words1.Test.Unit
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Xunit;

    public class BackgroundTaskGroupTest
    {
        public BackgroundTaskGroupTest()
        {
        }

        [Fact]
        public void RunAsync_LaunchesSpecifiedNumberOfTasksAndEndsWhenAllComplete()
        {
            List<TaskCompletionSource<bool>> tcsItems = new List<TaskCompletionSource<bool>>();
            Func<Task> createTask = delegate
            {
                TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();
                tcsItems.Add(tcs);
                return tcs.Task;
            };

            BackgroundTaskGroup group = new BackgroundTaskGroup(3, createTask);

            Task task = group.RunAsync();

            Assert.Equal(3, tcsItems.Count);
            foreach (TaskCompletionSource<bool> tcs in tcsItems)
            {
                Assert.False(task.IsCompleted);
                tcs.SetResult(true);
            }

            Assert.True(task.IsCompleted);
            task.Wait();
        }
    }
}
