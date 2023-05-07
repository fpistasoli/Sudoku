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
        [SerializeField] private LayerMask mouseCellLayerMask;


        private void OnEnable()
        {
            Cell.selectedCell += OnSelectUniqueCell;
        }

        private void OnDisable()
        {
            Cell.selectedCell -= OnSelectUniqueCell;
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
     

        }
   
        private void OnSelectUniqueCell()
        {
            foreach(ICell cell in board.Cells)
            {
                cell.Select(false);
            }
        }
    }
}




