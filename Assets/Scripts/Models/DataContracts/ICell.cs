using UnityEngine.UI;

namespace Sudoku.Models.DataContracts
{
    public interface ICell
    {
        bool IsSelected { get; }
        void Select(bool on);
        Text GetCellNumberText();
    }
}
