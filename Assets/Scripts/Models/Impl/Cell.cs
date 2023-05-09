using Sudoku.Models.DataContracts;
using System;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Sudoku.Models.Impl
{
    public class Cell : MonoBehaviour, ICell, IPointerClickHandler
    {
        public static event Action selectedCell;
        public static event Action correctCell;

        [SerializeField] private GameObject cellText;

        private bool _isSelected;
        private bool _isCorrect;
        private int _correctValue;
        private Image _backgroundImage;
        private Color _highlightedOffColor;
        private Color _highlightedOnColor = Color.cyan;

        private void Awake()
        {
            _backgroundImage = GetComponent<Image>();
            _highlightedOffColor = _backgroundImage.color;
            _isSelected = false;
            _isCorrect = true;
        }

        public bool IsSelected => _isSelected;
        public Text GetCellNumberText() => cellText.GetComponent<Text>();
        public bool IsCorrect() => _isCorrect;
        public void SetCorrectValue(int correctValue) => _correctValue = correctValue;
        public int GetCorrectValue() => _correctValue;

        public void Select(bool on)
        {
            _isSelected = on;
            Highlight(on);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            selectedCell?.Invoke();
            Select(true);
        }

        public int GetCellNumber()
        {
            return IsValidCellNumber() ? int.Parse(GetCellNumberText().text) : 0;
        }

        public void SetCellNumber(int number)
        {
            cellText.GetComponent<Text>().text = number.ToString();
        }

        public bool IsValidCellNumber()
        {
            Text textComponent = cellText.GetComponent<Text>();

            return textComponent.text != String.Empty && 
                Enumerable.Range(1, 9).Contains(int.Parse(textComponent.text));
        }

        public void HideCellNumberIfZero()
        {
            if (int.Parse(GetCellNumberText().text) == 0)
            {
                cellText.GetComponent<Text>().text = String.Empty;
            }
        }

        public void SetCorrectCell(bool isCorrect)
        {
            _isCorrect = isCorrect;
            if (isCorrect)
            {
                correctCell?.Invoke();
            }
        }

        private void Highlight(bool on)
        {
            if (on)
            {
                _backgroundImage.color = _highlightedOnColor;
            }
            else
            {
                _backgroundImage.color = _highlightedOffColor;
            }
        }
    }
}

