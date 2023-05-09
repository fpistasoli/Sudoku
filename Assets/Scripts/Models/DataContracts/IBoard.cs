namespace Sudoku.Models.DataContracts
{
    public interface IBoard
    {
        ICell[] Cells { get; }
        bool IsValidCell(int row, int col, int number);
    }
}




