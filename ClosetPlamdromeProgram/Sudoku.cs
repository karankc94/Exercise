using System;


namespace ClosetPlamdromeProgram
{
    class Sudoku
    {

        const int UNASSIGNED = 0;

        internal bool SolveSudoku(ref int[,] grid)
        {
            int row = 0, col = 0;
            if (!FindUnassignedLocation(ref grid, ref row, ref col)) return true; // success!
            for (int num = 1; num <= 9; num++)
            { // consider digits 1 to 9
                if (NoConflicts(grid, row, col, num))
                {
                    grid[row, col] = num;
                    if (SolveSudoku(ref grid)) return true;
                    grid[row, col] = UNASSIGNED;
                }
            }
            return false; //backtracking
        }

        bool FindUnassignedLocation(ref int[,] grid, ref int row, ref int col)
        {
            for (row = 0; row < grid.GetLength(0); row++)
                for (col = 0; col < grid.GetLength(1); col++)
                    if (grid[row, col] == UNASSIGNED) return true;
            return false;
        }

        bool NoConflicts(int[,] grid, int row, int col, int num)
        {
            return !UsedInRow(grid, row, num) && !UsedInCol(grid, col, num)
            && !UsedInBox(grid, row - row % 3, col - col % 3, num);
        }

        bool UsedInRow(int[,] grid, int row, int num)
        {
            for (int col = 0; col < grid.GetLength(1); col++)
                if (grid[row, col] == num) return true;
            return false;
        }

        bool UsedInCol(int[,] grid, int col, int num)
        {
            for (int row = 0; row < grid.GetLength(0); row++)
                if (grid[row, col] == num) return true;
            return false;
        }

        bool UsedInBox(int[,] grid, int boxStartRow, int boxStartCol, int num)
        {
            for (int row = 0; row < 3; row++)
                for (int col = 0; col < 3; col++)
                    if (grid[row + boxStartRow, col + boxStartCol] == num)
                        return true;
            return false;
        }


        public void DisplayGrid(int[,] grid)
        {
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    Console.Write(grid[i, j] + " ");
                }
                Console.WriteLine("");
            }

        }
    }

}
