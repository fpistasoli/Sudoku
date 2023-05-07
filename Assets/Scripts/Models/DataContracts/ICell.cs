using UnityEngine.UI;

namespace Sudoku.Models.DataContracts
{
    public interface ICell
    {
        bool IsSelected { get; }
        void Select(bool on);
        Text GetCellNumberText();
        void HideCellNumberIfZero();
        int GetCellNumber();
        void SetCellNumber(int number);
        bool IsValidCellNumber();
        bool IsCorrect();
        void SetCorrectCell(bool isCorrect);
        void SetCorrectValue(int correctValue);
        int GetCorrectValue();
    }
}
