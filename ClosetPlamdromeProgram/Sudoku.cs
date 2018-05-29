﻿using System;


namespace ClosetPlamdromeProgram
{
    class Sudoku
    {
        public const int UNASSIGNED = 0;


        /*
* Function: SolveSudoku
* ---------------------
* Takes a partially filled-in grid and attempts to assign values to all
* unassigned locations in such a way to meet the requirements for Sudoku
* solution (non-duplication across rows, columns, and boxes). The function
* operates via recursive backtracking: it finds an unassigned location with
* the grid and then considers all digits from 1 to 9 in a loop. If a digit
* is found that has no existing conflicts, tentatively assign it and recur
* to attempt to fill in rest of grid. If this was successful, the puzzle is
* solved. If not, unmake that decision and try again. If all digits have
* been examined and none worked out, return false to backtrack to previous
* decision point.
*/
      internal  bool SolveSudoku(ref int[,] grid)
        {
            int row = 0, col = 0;
            if (!FindUnassignedLocation(ref grid, ref row, ref col)) return true; // success!
            for (int num = 1; num <= 9; num++)
            { // consider digits 1 to 9
                if (NoConflicts(ref grid, row, col, num))
                { // if looks promising,
                    grid[row, col] = num; // make tentative assignment
                    if (SolveSudoku(ref grid)) return true; // recur, if success, yay!
                    grid[row, col] = UNASSIGNED; // failure, unmake & try again
                }
            }
            return false; // this triggers backtracking
        }
        /*
         * Function: FindUnassignedLocation
         * --------------------------------
         * Searches the grid to find an entry that is still unassigned. If found,
         * the reference parameters row, col will be set the location that is
         * unassigned, and true is returned. If no unassigned entries remain, false
         * is returned.
         */
        bool FindUnassignedLocation(ref int[,] grid, ref int row, ref int col)
        {
            for (row = 0; row < grid.GetLength(0); row++)
                for (col = 0; col < grid.GetLength(1); col++)
                    if (grid[row, col] == UNASSIGNED) return true;
            return false;
        }
        /*
         * Function: NoConflicts
         * ---------------------
         * Returns a boolean which indicates whether it will be legal to assign
         * num to the given row,col location. As assignment is legal if it that
         * number is not already used in the row, col, or box.
         */
        bool NoConflicts(ref int[,] grid, int row, int col, int num)
        {
            return !UsedInRow(ref grid, row, num) && !UsedInCol(ref grid, col, num)
            && !UsedInBox(ref grid, row - row % 3, col - col % 3, num);
        }
        /*
         * Function: UsedInRow
         * -------------------
         * Returns a boolean which indicates whether any assigned entry
         * in the specified row matches the given number.
         */
        bool UsedInRow(ref int[,] grid, int row, int num)
        {
            for (int col = 0; col < grid.GetLength(1); col++)
                if (grid[row, col] == num) return true;
            return false;
        }
        /*
         * Function: UsedInCol
         * -------------------
         * Returns a boolean which indicates whether any assigned entry
         * in the specified column matches the given number.
         */
        bool UsedInCol(ref int[,] grid, int col, int num)
        {
            for (int row = 0; row < grid.GetLength(0); row++)
                if (grid[row, col] == num) return true;
            return false;
        }
        /*
         * Function: UsedInBox
         * -------------------
         * Returns a boolean which indicates whether any assigned entry
         * within the specified 3x3 box matches the given number.
         */
        bool UsedInBox(ref int[,] grid, int boxStartRow, int boxStartCol, int num)
        {
            for (int row = 0; row < 3; row++)
                for (int col = 0; col < 3; col++)
                    if (grid[row + boxStartRow, col + boxStartCol] == num)
                        return true;
            return false;
        }
     

        public void DisplayGrid( int[,] grid)
        {
            for(int i = 0; i < grid.GetLength(0); i++)
            {
                for(int j = 0; j < grid.GetLength(1); j++)
                {
                    Console.Write(grid[i, j] + " ");
                }
                Console.WriteLine("");
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    Console.Write("---");
                }
                Console.WriteLine("");
            }

        }
    }

}
