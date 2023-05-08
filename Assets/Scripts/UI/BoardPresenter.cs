using Sudoku.Managers;
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
        [SerializeField] private GameObject mainPanel;
        [SerializeField] private GameObject gameWinPanel;   

        private Color _correctColor;
        private Color _wrongColor;
        private Cell CurrentSelectedCell { get; set; }


        private void OnEnable()
        {
            Cell.selectedCell += OnDeselectAllCells;
            Number.selectedNumber += OnSelectNumber;
            board.levelComplete += OnGameWinUI;
        }

        private void OnDisable()
        {
            Cell.selectedCell -= OnDeselectAllCells;
            Number.selectedNumber -= OnSelectNumber;
            board.levelComplete -= OnGameWinUI;
        }

        private void Awake()
        {
            CurrentSelectedCell = null;
        }

        void Start()
        {
            _correctColor = Color.blue;
            _wrongColor = Color.red;
            ActivateGameWinPanel(false);
        }

        private void ActivateGameWinPanel(bool on)
        {
            gameWinPanel.SetActive(on);
            gameWinPanel.GetComponent<GameWin>().enabled = on; 
        }

        void Update()
        {
     

        }

        public void OnEraseSelectedCellNumber()
        {
            if (!TryGetCurrentSelectedCell(out Cell currentSelectedCell)) return;
            CurrentSelectedCell = currentSelectedCell;
            if (CurrentSelectedCell.IsCorrect()) return;
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

            if (CurrentSelectedCell.IsCorrect()) return;

            CurrentSelectedCell.GetCellNumberText().text = selectedNumber;
            bool isCorrect = CurrentSelectedCell.GetCorrectValue() == int.Parse(selectedNumber);

            if (!isCorrect)
            {
                GameManager.Instance.Mistakes++;
            }


            MarkCurrentCellAsCorrect(isCorrect);
            CurrentSelectedCell.SetCorrectCell(isCorrect);
            
        }

        private void MarkCurrentCellAsCorrect(bool isCorrect)
        {
            if (isCorrect)
            {
                CurrentSelectedCell.GetCellNumberText().color = _correctColor;
            }
            else
            {
                CurrentSelectedCell.GetCellNumberText().color = _wrongColor;
            }


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

        private void OnGameWinUI()
        {
            mainPanel.SetActive(false);
            ActivateGameWinPanel(true);
        }
    }
}




