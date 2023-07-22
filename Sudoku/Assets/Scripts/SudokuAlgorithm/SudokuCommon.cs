using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sudoku
{
    public static class SudokuCommon
    {
        public static System.Random Random = new System.Random();

        public static bool IsValid(int num, int row, int col, int[,] sudokuArray)
        {
            int startRow = row / 3 * 3;
            int startCol = col / 3 * 3;

            for (int i = 0; i < 8; i++)
            {
                if (sudokuArray[row, i] == num)
                {
                    return false;
                }
            }

            for (int i = 0; i < 8; i++)
            {
                if (sudokuArray[i, col] == num)
                {
                    return false;
                }
            }

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (sudokuArray[startRow + i, startCol + j] == num)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
