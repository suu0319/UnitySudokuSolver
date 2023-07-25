<<<<<<< HEAD
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Sudoku
{
    public class SudokuSolver : SudokuBase
    {
        private List<int> _validRowList = new List<int>();
        private List<int> _validColList = new List<int>();
        private int[,] _sudokuArray = new int[9, 9];
        [SerializeField]
        private UISudokuManager _uISudokuManager;

        private void FindSudokuSolutions(int validIndex, int[,] sudokuArray)
        {
            if (validIndex == _validRowList.Count)
            {
                _uISudokuManager.ShowSudoku(sudokuArray);
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

        public void SolveSudoku()
        {
            _validRowList.Clear();
            _validColList.Clear();

            for (int i = 0; i < _uISudokuManager.SudokuBtnList.Count; i++)
            {
                int num = int.Parse(_uISudokuManager.SudokuBtnList[i].GetComponentInChildren<Text>().text);
                _sudokuArray[i / 9, i % 9] = num;
            }

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (_sudokuArray[i, j] == 0)
                    {
                        _validRowList.Add(i);
                        _validColList.Add(j);
                    }
                }
            }

            FindSudokuSolutions(0, _sudokuArray);
        }
    }
}
=======
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Sudoku
{
    public class SudokuSolver : MonoBehaviour
    {
        private List<int> _validRowList = new List<int>();
        private List<int> _validColList = new List<int>();
        private int[,] _sudokuArray = new int[9, 9];
        [SerializeField]
        private UISudokuManager _uISudokuManager;

        private void FindSudokuSolutions(int validIndex, int[,] sudokuArray)
        {
            if (validIndex == _validRowList.Count)
            {
                _uISudokuManager.ShowSudoku(sudokuArray);
                return;
            }

            int row = _validRowList[validIndex];
            int col = _validColList[validIndex];
            List<int> randomNumList = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            while (randomNumList.Count > 0)
            {
                int randomNum = randomNumList[Random.Range(0, randomNumList.Count)];
                randomNumList.Remove(randomNum);

                if (SudokuCommon.IsValid(randomNum, row, col, sudokuArray))
                {
                    sudokuArray[row, col] = randomNum;

                    FindSudokuSolutions(validIndex + 1, sudokuArray);

                    sudokuArray[row, col] = 0;
                }
            }
        }

        public void SolveSudoku()
        {
            _validRowList.Clear();
            _validColList.Clear();

            for (int i = 0; i < _uISudokuManager.SudokuBtnList.Count; i++)
            {
                int num = int.Parse(_uISudokuManager.SudokuBtnList[i].GetComponentInChildren<Text>().text);
                _sudokuArray[i / 9, i % 9] = num;
            }

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (_sudokuArray[i, j] == 0)
                    {
                        _validRowList.Add(i);
                        _validColList.Add(j);
                    }
                }
            }

            FindSudokuSolutions(0, _sudokuArray);
        }
    }
}
>>>>>>> 6f66ef11b4ee700f210b383caff7a7f1f9bf587c
