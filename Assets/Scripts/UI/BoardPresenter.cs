using Sudoku.Models.DataContracts;
using Sudoku.Models.Impl;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace Sudoku.UI
{
    public class BoardPresenter : MonoBehaviour
    {

        [SerializeField] private Button[] numberButtons;
        [SerializeField] private Button eraseButton;
        [SerializeField] private Board board;

        private Cell CurrentSelectedCell { get; set; }


        private void OnEnable()
        {
            Cell.selectedCell += OnDeselectAllCells;
            Number.selectedNumber += OnSelectNumber;
        }


        private void OnDisable()
        {
            Cell.selectedCell -= OnDeselectAllCells;
            Number.selectedNumber -= OnSelectNumber;
        }

        private void Awake()
        {
            CurrentSelectedCell = null;
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
     

        }

        public void OnEraseSelectedCellNumber()
        {
            if (!TryGetCurrentSelectedCell(out Cell currentSelectedCell)) return;

            CurrentSelectedCell = currentSelectedCell;

            CurrentSelectedCell.GetCellNumberText().text = String.Empty;
        }

        private void OnDeselectAllCells()
        {
            foreach(ICell cell in board.Cells)
            {
                cell.Select(false);
            }
        }

        private void OnSelectNumber(string selectedNumber)
        {
            if (!TryGetCurrentSelectedCell(out Cell currentSelectedCell)) return;

            CurrentSelectedCell = currentSelectedCell;

            CurrentSelectedCell.GetCellNumberText().text = selectedNumber;
        }

        private bool TryGetCurrentSelectedCell(out Cell currentSelectedCell)
        {
            foreach(Cell cell in board.Cells)
            {
                if(cell.IsSelected)
                {
                    currentSelectedCell = cell;
                    return true;
                }
            }

            currentSelectedCell = null;
            return false;
        }
    }
}




