//-----------------------------------------------------------------------
// <copyright file="Word2GridFinder.cs" company="Brian Rogers">
// Copyright (c) Brian Rogers. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Words1
{
    using System;

    public class Word2GridFinder
    {
        private readonly Word2Trie trie;
        private readonly bool allowDuplicateWords;

        public Word2GridFinder(Word2Trie trie, bool allowDuplicateWords)
        {
            this.trie = trie;
            this.allowDuplicateWords = allowDuplicateWords;
        }

        public void Find(Word2 input, Action<Word2Grid> onFound)
        {
            Word2Grid grid = new Word2Grid(input, new Word2());
            this.trie.Match1(grid.A00, w => this.DoColumn1(w, grid, onFound));
        }

        private void DoColumn1(Word2 column1, Word2Grid grid, Action<Word2Grid> onFound)
        {
            if (this.allowDuplicateWords || !grid.Row1.Equals(column1))
            {
                grid = new Word2Grid(grid.Row1, new Word2(column1.L2, '\0'));
                this.trie.Match1(grid.A10, w => this.DoRow2(w, grid, onFound));
            }
        }

        private void DoRow2(Word2 row2, Word2Grid grid, Action<Word2Grid> onFound)
        {
            grid = new Word2Grid(grid.Row1, row2);
            if (this.allowDuplicateWords || (!grid.Row1.Equals(row2) && !grid.Column1.Equals(row2) && !grid.Column2.Equals(grid.Row1)))
            {
                if (this.trie.Contains(grid.Column2))
                {
                    onFound(grid);
                }
            }
        }
    }
}
