//-----------------------------------------------------------------------
// <copyright file="IGridAlgorithm.cs" company="Brian Rogers">
// Copyright (c) Brian Rogers. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Words1
{
    internal interface IGridAlgorithm
    {
        void Load(string fileName);

        void Run(int workerCount, bool allowDuplicateWords);
    }
}
