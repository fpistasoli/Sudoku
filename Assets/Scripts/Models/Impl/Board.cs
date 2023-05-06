using Sudoku.Models.DataContracts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sudoku.Models.Impl
{
    public class Board : MonoBehaviour, IBoard
    {

        [SerializeField] private Cell[] cells;
        private Cell[,] grid;

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
            grid = new Cell[9, 9];

            var cellIndex = 0;

            for(int i=0; i<9; i++)
            {
                for(int j=0; j<9; j++)
                {
                    grid[i, j] = cells[cellIndex];
                    cellIndex++;
                }   
            }
        }
    }
}



