using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosetPlamdromeProgram
{
    class Test
    {
        public static void Main(string[] args)
        {
            int programCheck = 0;
            Console.WriteLine("Enter 1:Closest Plandrome;\nEnter 2:Sudoku Problem;");
            int.TryParse(Console.ReadLine(), out programCheck);
            if (programCheck == 1)
            {
                int i = 1;
                int j = 0;
                string input;
                Console.WriteLine("Enter Execution Count:");
                int.TryParse(Console.ReadLine(), out j);
                do
                {
                    input = Console.ReadLine();
                    Console.WriteLine(new Palindrome().ClosestPalindrom(input));
                    i++;
                } while (i <= j);
                Console.ReadLine();
            }
            else if (programCheck == 2)
            {

                int[,] grid = new int[9, 9]
                    {{3, 0, 6, 5, 0, 8, 4, 0, 0},
                    {5, 2, 0, 0, 0, 0, 0, 0, 0},
                    {0, 8, 7, 0, 0, 0, 0, 3, 1},
                    {0, 0, 3, 0, 1, 0, 0, 8, 0},
                    {9, 0, 0, 8, 6, 3, 0, 0, 5},
                    {0, 5, 0, 0, 9, 0, 6, 0, 0},
                    {1, 3, 0, 0, 0, 0, 2, 5, 0},
                    {0, 0, 0, 0, 0, 0, 0, 7, 4},
                    {0, 0, 5, 2, 0, 6, 3, 0, 0}};

                Sudoku sudoku = new Sudoku();

                if (sudoku.SolveSudoku(ref grid) == true)
                {
                    sudoku.DisplayGrid(grid);
                    
                }
                else
                {
                    sudoku.DisplayGrid(grid);
                    Console.WriteLine("No solution exists");
                }
                
                Console.ReadLine();

            }
            else
            {
                Console.WriteLine("Invalid Number.");
            }
        }
    }
}
