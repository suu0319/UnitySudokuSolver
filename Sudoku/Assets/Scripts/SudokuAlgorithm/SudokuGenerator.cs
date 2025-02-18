using System.Collections.Generic;
using UnityEngine;

namespace Sudoku
{
    public class SudokuGenerator : SudokuBase
    {
        private List<int> _validRowList = new List<int>();
        private List<int> _validColList = new List<int>();
        private List<int[,]> _solutionList = new List<int[,]>();
        private int[,] _sudokuArray = new int[9, 9];
        [SerializeField]
        private UISudokuManager _uISudokuManager;

        private bool CanGenerateNumInSudoku(int row, int col)
        {
            if (row == 9)
            {
                CanRandomResetSudoku(0, int.Parse(_uISudokuManager.SudokuEmptyCountInput.text), _sudokuArray);
                _uISudokuManager.ShowSudoku(_sudokuArray);
                return true;
            }

            if (col == 9)
            {
                return CanGenerateNumInSudoku(row + 1, 0);
            }

            if (_sudokuArray[row, col] != 0)
            {
                return CanGenerateNumInSudoku(row, col + 1);
            }

            List<int> randomNumList = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            while (randomNumList.Count > 0)
            {
                int randomNum = randomNumList[Random.Range(0, randomNumList.Count)];
                randomNumList.Remove(randomNum);

                if (IsValid(randomNum, row, col, _sudokuArray))
                {
                    _sudokuArray[row, col] = randomNum;

                    if (CanGenerateNumInSudoku(row, col + 1))
                    {
                        return true;
                    }

                    _sudokuArray[row, col] = 0;
                }
            }

            return false;
        }

        private void FindSudokuSolutions(int validIndex, int[,] sudokuArray)
        {
            if (validIndex == _validRowList.Count)
            {
                int[,] solution = new int[9, 9];
                System.Array.Copy(sudokuArray, solution, 81);
                _solutionList.Add(solution);

                if (_solutionList.Count > 1)
                {
                    return;
                }

                return;
            }

            int row = _validRowList[validIndex];
            int col = _validColList[validIndex];
            List<int> randomNumList = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            while (randomNumList.Count > 0)
            {
                int randomNum = randomNumList[Random.Range(0, randomNumList.Count)];
                randomNumList.Remove(randomNum);

                if (IsValid(randomNum, row, col, sudokuArray))
                {
                    sudokuArray[row, col] = randomNum;

                    FindSudokuSolutions(validIndex + 1, sudokuArray);

                    sudokuArray[row, col] = 0;
                }
            }
        }

        private bool CanRandomResetSudoku(int emptyCount, int targetCount, int[,] sudokuArray)
        {
            if (emptyCount == targetCount)
            {
                return true;
            }

            for (int i = emptyCount; i < targetCount; i++)
            {
                int randomRow = Random.Range(0, 9);
                int randomCol = Random.Range(0, 9);
                int cacheNum;

                while (sudokuArray[randomRow, randomCol] == 0)
                {
                    randomRow = Random.Range(0, 9);
                    randomCol = Random.Range(0, 9);
                }

                cacheNum = sudokuArray[randomRow, randomCol];
                sudokuArray[randomRow, randomCol] = 0;
                _solutionList.Clear();
                FindSudokuSolutions(0, sudokuArray);

                if (_solutionList.Count == 1)
                {
                    if (CanRandomResetSudoku(emptyCount + 1, targetCount, sudokuArray))
                    {
                        return true;
                    }
                }

                sudokuArray[randomRow, randomCol] = cacheNum;
            }

            return false;
        }

        public void InitializeSudoku()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    _sudokuArray[i, j] = 0;
                }
            }

            CanGenerateNumInSudoku(0, 0);
        }
    }
}
