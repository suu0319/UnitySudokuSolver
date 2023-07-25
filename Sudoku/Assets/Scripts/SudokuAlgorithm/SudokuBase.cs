<<<<<<< HEAD:Sudoku/Assets/Scripts/SudokuAlgorithm/SudokuBase.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sudoku
{
    public class SudokuBase : MonoBehaviour
    {
        protected bool IsValid(int num, int row, int col, int[,] sudokuArray)
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
=======
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sudoku
{
    public static class SudokuCommon
    {
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
>>>>>>> 6f66ef11b4ee700f210b383caff7a7f1f9bf587c:Sudoku/Assets/Scripts/SudokuAlgorithm/SudokuCommon.cs
