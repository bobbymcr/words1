//-----------------------------------------------------------------------
// <copyright file="Word4GridFinder.cs" company="Brian Rogers">
// Copyright (c) Brian Rogers. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Words1
{
    using System;

    public class Word4GridFinder
    {
        private readonly Word4Trie trie;
        private readonly bool allowDuplicateWords;

        public Word4GridFinder(Word4Trie trie, bool allowDuplicateWords)
        {
            this.trie = trie;
            this.allowDuplicateWords = allowDuplicateWords;
        }

        public void Find(Word4 input, Action<Word4Grid> onFound)
        {
            Word4Grid grid = new Word4Grid(input, new Word4(), new Word4(), new Word4());
            this.trie.Match1(grid.A00, w => this.DoColumn1(w, grid, onFound));
        }

        private void DoColumn1(Word4 column1, Word4Grid grid, Action<Word4Grid> onFound)
        {
            if (this.allowDuplicateWords || !grid.Row1.Equals(column1))
            {
                grid = new Word4Grid(grid.Row1, new Word4(column1.L2, '\0', '\0', '\0'), new Word4(column1.L3, '\0', '\0', '\0'), new Word4(column1.L4, '\0', '\0', '\0'));
                this.trie.Match1(grid.A10, w => this.DoRow2(w, grid, onFound));
            }
        }

        private void DoRow2(Word4 row2, Word4Grid grid, Action<Word4Grid> onFound)
        {
            if (this.allowDuplicateWords || (!grid.Row1.Equals(row2) && !grid.Column1.Equals(row2)))
            {
                grid = new Word4Grid(grid.Row1, row2, new Word4(grid.A20, '\0', '\0', '\0'), new Word4(grid.A30, '\0', '\0', '\0'));
                this.trie.Match2(grid.A01, grid.A11, w => this.DoColumn2(w, grid, onFound));
            }
        }

        private void DoColumn2(Word4 column2, Word4Grid grid, Action<Word4Grid> onFound)
        {
            if (this.allowDuplicateWords || (!grid.Row1.Equals(column2) && !grid.Column1.Equals(column2) && !grid.Row2.Equals(column2)))
            {
                grid = new Word4Grid(grid.Row1, grid.Row2, new Word4(grid.A20, column2.L3, '\0', '\0'), new Word4(grid.A30, column2.L4, '\0', '\0'));
                this.trie.Match2(grid.A20, grid.A21, w => this.DoRow3(w, grid, onFound));
            }
        }

        private void DoRow3(Word4 row3, Word4Grid grid, Action<Word4Grid> onFound)
        {
            if (this.allowDuplicateWords || (!grid.Row1.Equals(row3) && !grid.Column1.Equals(row3) && !grid.Row2.Equals(row3) && !grid.Column2.Equals(row3)))
            {
                grid = new Word4Grid(grid.Row1, grid.Row2, row3, new Word4(grid.A30, grid.A31, '\0', '\0'));
                this.trie.Match3(grid.A02, grid.A12, grid.A22, w => this.DoColumn3(w, grid, onFound));
            }
        }

        private void DoColumn3(Word4 column3, Word4Grid grid, Action<Word4Grid> onFound)
        {
            if (this.allowDuplicateWords || (!grid.Row1.Equals(column3) && !grid.Column1.Equals(column3) && !grid.Row2.Equals(column3) && !grid.Column2.Equals(column3) && !grid.Row3.Equals(column3)))
            {
                grid = new Word4Grid(grid.Row1, grid.Row2, grid.Row3, new Word4(grid.A30, grid.A31, column3.L4, '\0'));
                this.trie.Match3(grid.A30, grid.A31, grid.A32, w => this.DoRow4(w, grid, onFound));
            }
        }

        private void DoRow4(Word4 row4, Word4Grid grid, Action<Word4Grid> onFound)
        {
            grid = new Word4Grid(grid.Row1, grid.Row2, grid.Row3, row4);
            if (this.allowDuplicateWords || (!grid.Row1.Equals(row4) && !grid.Column1.Equals(row4) && !grid.Row2.Equals(row4) && !grid.Column2.Equals(row4) && !grid.Row3.Equals(row4) && !grid.Column3.Equals(row4) && !grid.Column4.Equals(row4)))
            {
                if (this.trie.Contains(grid.Column4))
                {
                    onFound(grid);
                }
            }
        }
    }
}
