using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Sudoku
{
    public class UISudokuManager : MonoBehaviour
    {
        [SerializeField]
        private SudokuGenerator _sudokuGenerator;
        [SerializeField]
        private SudokuSolver _sudokuSolver;
        [SerializeField]
        private GameObject _uISudoku;
        [SerializeField]
        private GameObject _uIInputSudoku;
        [SerializeField]
        private Button _uISudokuEmptyReduceBtn;
        [SerializeField]
        private Button _uISudokuEmptyAddBtn;
        [SerializeField]
        private Button _uIGenerateSudokuBtn;
        [SerializeField]
        private Button _uIResetSudokuBtn;
        [SerializeField]
        private Button _uISloveSudokuBtn;
        [SerializeField]
        private Button _uISelectedSudokuBtn;
        [SerializeField]
        private Button _uILastSelectedSudokuBtn;
        [NonSerialized]
        private List<Button> _inputSudokuBtnList = new List<Button>();
        [NonSerialized]
        public List<Button> SudokuBtnList = new List<Button>();
        public Text SudokuEmptyCountInput;

        // Start is called before the first frame update
        void Start()
        {
            for (int i = 0; i < 10; i++)
            {
                int temp = i;
                _inputSudokuBtnList.Add(_uIInputSudoku.transform.GetChild(i).gameObject.GetComponent<Button>());
                _inputSudokuBtnList[i].onClick.AddListener(() => { InputSudokuBtn(temp); });
            }

            for (int i = 0; i < 81; i++)
            {
                int temp = i;
                SudokuBtnList.Add(_uISudoku.transform.GetChild(i).gameObject.GetComponent<Button>());
                SudokuBtnList[i].onClick.AddListener(() => { SelectedSudokuBtn(temp); });
            }

            _uISudokuEmptyReduceBtn.onClick.AddListener(() => { CalEmptyCount(-1); });
            _uISudokuEmptyAddBtn.onClick.AddListener(() => { CalEmptyCount(1); });
            _uIGenerateSudokuBtn.onClick.AddListener(_sudokuGenerator.InitializeSudoku);
            _uIResetSudokuBtn.onClick.AddListener(ResetSudoku);
            _uISloveSudokuBtn.onClick.AddListener(_sudokuSolver.SolveSudoku);
        }

        private void CalEmptyCount(int num)
        {
            int emptyCount = int.Parse(SudokuEmptyCountInput.text);

            emptyCount += num;

            if (emptyCount > 30)
            {
                emptyCount = 30;
            }
            else if (emptyCount < 0)
            {
                emptyCount = 0;
            }

            SudokuEmptyCountInput.text = emptyCount.ToString();
        }

        private void ResetSudoku()
        {
            for (int i = 0; i < 81; i++)
            {
                SudokuBtnList[i].GetComponentInChildren<Text>().text = "0";
            }
        }

        private void SelectedSudokuBtn(int sudokuIndex)
        {
            if (_uILastSelectedSudokuBtn != null)
            {
                var colorsLast = _uILastSelectedSudokuBtn.colors;
                colorsLast.normalColor = Color.white;
                _uILastSelectedSudokuBtn.colors = colorsLast;
                _uILastSelectedSudokuBtn = null;
            }

            _uILastSelectedSudokuBtn = SudokuBtnList[sudokuIndex];
            _uISelectedSudokuBtn = SudokuBtnList[sudokuIndex];

            var colors =_uISelectedSudokuBtn.colors;
            colors.selectedColor = Color.gray;
            _uISelectedSudokuBtn.colors = colors;
        }

        private void InputSudokuBtn(int inputSudokuNum)
        {
            _uISelectedSudokuBtn.GetComponentInChildren<Text>().text = inputSudokuNum.ToString();
        }

        public void ShowSudoku(int[,] sudokuArray)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    SudokuBtnList[i * 9 + j].gameObject.GetComponentInChildren<Text>().text = sudokuArray[i, j].ToString();
                }
            }
        }
    }
}

