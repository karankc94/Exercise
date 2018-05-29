using System;

namespace ClosetPlamdromeProgram
{
    class Test
    {
        public static void Main(string[] args)
        {
            int programCheck = 0;
            int i = 1;
            int j = 0;
            string input=string.Empty;
            Console.WriteLine("Enter 1:Closest Plandrome;\nEnter 2:Sudoku Problem;");
            int.TryParse(Console.ReadLine(), out programCheck);
            Console.WriteLine("Enter Execution Count:");
            if (programCheck == 1)
            {

                j = Convert.ToInt32(Console.ReadLine());
                do
                {
                    input = Convert.ToString(Console.ReadLine());
                    Console.WriteLine(new Palindrome().ClosestPalindrom(input));
                    i++;
                } while (i <= j);
            }
            else if (programCheck == 2)
            {
                j = Convert.ToInt32(Console.ReadLine());
                do
                {
                    Sudoku sudoku = new Sudoku();
                    // input = Convert.ToString(Console.ReadLine());
                    input = "3 0 6 5 0  8 4 0 0 5 2 0 0 0 0 0 0 0 0 8 7 0 0 0 0 3 1 0 0 3 0 1 0 0 8 0 9 0 0 8 6 3 0 0 5 0 5 0 0 9 0 6 0 0 1 3 0 0 0 0 2 5 0 0 0 0 0 0 0 0 7 4 0 0 5 2 0 6 3 0 0";
                    string abc= input.Replace("  ", " ");
       
                    string[] inputarray= abc.Split(' ');
                   
                    int[,] grid = new int[9, 9];
                    //{
                    //    { 3, 0, 6, 5, 0, 8, 4, 0, 0},
                    //{ 5, 2, 0, 0, 0, 0, 0, 0, 0},
                    //{ 0, 8, 7, 0, 0, 0, 0, 3, 1},
                    //{ 0, 0, 3, 0, 1, 0, 0, 8, 0},
                    //{ 9, 0, 0, 8, 6, 3, 0, 0, 5},
                    //{ 0, 5, 0, 0, 9, 0, 6, 0, 0},
                    //{ 1, 3, 0, 0, 0, 0, 2, 5, 0},
                    //{ 0, 0, 0, 0, 0, 0, 0, 7, 4},
                    //{ 0, 0, 5, 2, 0, 6, 3, 0, 0}
                    //};

                     sudoku.SetValueInGrid(ref grid, inputarray);



                    if (sudoku.SolveSudoku(ref grid) == true)
                    { 
                        sudoku.DisplayGrid(grid);
                        Console.WriteLine();
                    }
                    

                    ++i;

                } while (i <= j);

            }
            else
            {
                Console.WriteLine("Invalid Number.");
            }
            Console.ReadLine();
        }
    }
}
