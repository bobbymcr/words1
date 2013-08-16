//-----------------------------------------------------------------------
// <copyright file="Word3GridFinder.cs" company="Brian Rogers">
// Copyright (c) Brian Rogers. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Words1
{
    using System;

    public class Word3GridFinder
    {
        private readonly Word3Trie trie;
        private readonly bool allowDuplicateWords;

        public Word3GridFinder(Word3Trie trie, bool allowDuplicateWords)
        {
            this.trie = trie;
            this.allowDuplicateWords = allowDuplicateWords;
        }

        public void Find(Word3 input, Action<Word3Grid> onFound)
        {
            Word3Grid grid = new Word3Grid(input, new Word3(), new Word3());
            this.trie.Match1(grid.A00, w => this.DoColumn1(w, grid, onFound));
        }

        private void DoColumn1(Word3 column1, Word3Grid grid, Action<Word3Grid> onFound)
        {
            if (this.allowDuplicateWords || !grid.Row1.Equals(column1))
            {
                grid = new Word3Grid(grid.Row1, new Word3(column1.L2, '\0', '\0'), new Word3(column1.L3, '\0', '\0'));
                this.trie.Match1(grid.A10, w => this.DoRow2(w, grid, onFound));
            }
        }

        private void DoRow2(Word3 row2, Word3Grid grid, Action<Word3Grid> onFound)
        {
            if (this.allowDuplicateWords || (!grid.Row1.Equals(row2) && !grid.Column1.Equals(row2)))
            {
                grid = new Word3Grid(grid.Row1, row2, new Word3(grid.A20, '\0', '\0'));
                this.trie.Match2(grid.A01, grid.A11, w => this.DoColumn2(w, grid, onFound));
            }
        }

        private void DoColumn2(Word3 column2, Word3Grid grid, Action<Word3Grid> onFound)
        {
            if (this.allowDuplicateWords || (!grid.Row1.Equals(column2) && !grid.Column1.Equals(column2) && !grid.Row2.Equals(column2)))
            {
                grid = new Word3Grid(grid.Row1, grid.Row2, new Word3(grid.A20, column2.L3, '\0'));
                this.trie.Match2(grid.A20, grid.A21, w => this.DoRow3(w, grid, onFound));
            }
        }

        private void DoRow3(Word3 row3, Word3Grid grid, Action<Word3Grid> onFound)
        {
            grid = new Word3Grid(grid.Row1, grid.Row2, row3);
            if (this.allowDuplicateWords || (!grid.Row1.Equals(row3) && !grid.Column1.Equals(row3) && !grid.Row2.Equals(row3) && !grid.Column2.Equals(row3) && !grid.Column3.Equals(row3)))
            {
                if (this.trie.Contains(grid.Column3))
                {
                    onFound(grid);
                }
            }
        }
    }
}
