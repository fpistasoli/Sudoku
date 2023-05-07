using Sudoku.Models.DataContracts;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Sudoku.Models.Impl
{

    public class Cell : MonoBehaviour, ICell, IPointerClickHandler
    {

        public static event Action selectedCell;

        [SerializeField] private GameObject cellText;

        private bool isSelected;
        private Image backgroundImage;
        private Color highlightedOffColor;
        private Color highlightedOnColor = Color.cyan;

        private void Awake()
        {
            backgroundImage = GetComponent<Image>();
            highlightedOffColor = backgroundImage.color;
            isSelected = false;
        }


        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public bool IsSelected => isSelected;

        public void Select(bool on)
        {
            isSelected = on;
            Highlight(on);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            selectedCell?.Invoke();
            Select(true);
        }

        private void Highlight(bool on)
        {
            if (on)
            {
                backgroundImage.color = highlightedOnColor;
            }
            else
            {
                backgroundImage.color = highlightedOffColor;
            }
        }

  
    }
}

