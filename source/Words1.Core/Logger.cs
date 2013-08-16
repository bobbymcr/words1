//-----------------------------------------------------------------------
// <copyright file="Logger.cs" company="Brian Rogers">
// Copyright (c) Brian Rogers. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Words1
{
    using System;
    using System.Globalization;
    using System.IO;

    public sealed class Logger
    {
        private readonly TextWriter writer;
        private readonly Func<TimeSpan> getTime;

        public Logger(TextWriter writer, Func<TimeSpan> getTime)
        {
            this.writer = writer;
            this.getTime = getTime;
        }

        public void Log(string format, params object[] args)
        {
            TimeSpan time = this.getTime();
            string message = format;
            if (args.Length > 0)
            {
                message = string.Format(CultureInfo.InvariantCulture, format, args);
            }

            this.writer.WriteLine(string.Format(CultureInfo.InvariantCulture, @"[{0:hh\:mm\:ss\.fff}] {1}", time, message));
        }
    }
}
