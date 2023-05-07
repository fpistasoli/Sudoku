using Sudoku.Models.DataContracts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

namespace Sudoku.Models.Impl
{
    public class Board : MonoBehaviour, IBoard
    {

        [SerializeField] private Cell[] cells;
        private Cell[,] _grid;
        

        // Start is called before the first frame update
        void Start()
        {
            InitializeGrid();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public ICell[] Cells => cells;

        private void InitializeGrid()
        {
            GridSetup();
            GridGenerator();
            OnlyShowClues();
        }

        public bool IsValidCell(int row, int col, int number)
        {
            return IsValidRow(row, number) && IsValidColumn(col, number) && IsValidBox(row, col, number);
        }

        private void GridSetup()
        {
            _grid = new Cell[9, 9];

            var cellIndex = 0;

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    _grid[i, j] = cells[cellIndex];
                    cellIndex++;
                }
            }
        }

        private bool IsValidRow(int row, int number)
        {
            for(int j=0; j<9; j++)
            {
                if(_grid[row,j].GetCellNumber() == number)
                {
                    return false;
                }
            }

            return true;  
        }

        private bool IsValidColumn(int col, int number)
        {
            for (int i = 0; i < 9; i++)
            {
                if (_grid[i, col].GetCellNumber() == number)
                {
                    return false;
                }
            }

            return true;
        }

        private bool IsValidBox(int row, int col, int number)
        {
            int boxRow = (row / 3) * 3;
            int boxCol = (col / 3) * 3;

            for (int i = boxRow; i < boxRow + 3; i++)
            {
                for (int j = boxCol; j < boxCol + 3; j++)
                {
                    if (_grid[i, j].GetCellNumber() == number)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private void GridGenerator()
        {
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    _grid[row, col].SetCellNumber(0);
                }
            }

            FillCells(0, 0);
        }

        private bool FillCells(int row, int col)
        {
            if (row == 9)
            {
                return true;
            }

            int nextRow = col == 8 ? row + 1 : row;
            int nextCol = col == 8 ? 0 : col + 1;

            List<int> potentialValues = new List<int>();
            for (int num = 1; num <= 9; num++)
            {
                if (IsValidCell(row, col, num))
                {
                    potentialValues.Add(num);
                }
            }

            Random rand = new Random();
            potentialValues.Sort((x, y) => rand.Next(2) == 0 ? -1 : 1);

            foreach (int num in potentialValues)
            {
                Cell currentCell = _grid[row, col];
                currentCell.SetCellNumber(num);
                currentCell.SetCorrectValue(num);

                if (FillCells(nextRow, nextCol))
                {
                    return true;
                }

                currentCell.SetCellNumber(0);
            }

            return false;
        }
        
        private void OnlyShowClues()
        {
            Random rand = new Random();
            int removedNumbersCount = rand.Next(50, 60);

            for (int i = 0; i < removedNumbersCount; i++)
            {
                int row = rand.Next(0, 9);
                int col = rand.Next(0, 9);

                Cell cellToRemove = _grid[row, col];

                if (cellToRemove.GetCellNumber() != 0)
                {
                    cellToRemove.SetCellNumber(0);
                    cellToRemove.SetCorrectCell(false);
                }
                else
                {
                    i--;
                }
            }

            foreach(Cell cell in _grid)
            {
                if(cell.GetCellNumber() == 0)
                {
                    cell.HideCellNumberIfZero();
                }
            }
        }
    }
}



