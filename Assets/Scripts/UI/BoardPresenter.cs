using Sudoku.Models.DataContracts;
using Sudoku.Models.Impl;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
            //event handlers
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            TrySelectCell();
        }
        private void OnDisable()
        {
            //event handlers
        }


        public void TrySelectCell()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, mouseCellLayerMask);
            if (raycastHit.transform.TryGetComponent<Cell>(out Cell cell))
            {
                SelectCellAndDeselectOthers(cell);
            }
        }

        private void SelectCellAndDeselectOthers(Cell selectedCell)
        {
            foreach(ICell cell in board.Cells)
            {
                cell.Select(false);
            }

            selectedCell.Select(true);
        }
    }
}




