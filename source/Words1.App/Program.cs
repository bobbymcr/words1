//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="Brian Rogers">
// Copyright (c) Brian Rogers. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Words1
{
    using System;
    using System.Diagnostics;
    using System.IO;

    internal sealed class Program
    {
        private static void Main(string[] args)
        {
            bool allowDuplicateWords = false;
            int workerCount = Environment.ProcessorCount - 1;
            string inputFileName = "words4.txt";
            string outputFileName = "results.txt";
            int gridSize = 4;
            int outputColumnLength = 120;

            using (StreamWriter outputWriter = new StreamWriter(outputFileName))
            {
                IGridAlgorithm algorithm = CreateAlgorithm(gridSize, outputColumnLength, outputWriter);
                algorithm.Load(inputFileName);
                algorithm.Run(workerCount, allowDuplicateWords);
            }
        }

        private static IGridAlgorithm CreateAlgorithm(int gridSize, int outputColumnLength, TextWriter outputWriter)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            Logger logger = new Logger(Console.Out, () => stopwatch.Elapsed);
            BlockWriter writer = new BlockWriter(outputWriter, gridSize, outputColumnLength);

            switch (gridSize)
            {
                case 3:
                    return new Word3GridAlgorithm(logger, writer);
                case 4:
                    return new Word4GridAlgorithm(logger, writer);
                default:
                    throw new InvalidOperationException("Invalid size.");
            }
        }
    }
}
