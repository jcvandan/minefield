namespace Minefield.Core;

public interface IField
{
}

public class FieldModel : IField
{
    private readonly bool[,] _matrix;
    private readonly int _fieldSize;
    private readonly int _mines;

    public FieldModel(int size, int mines)
    {
        _fieldSize = size;
        _mines = mines;
        _matrix = new bool[size, size];

        GenerateField();
    }

    private void GenerateField()
    {
        var random = new Random((int) DateTime.UtcNow.Ticks);
        do
        {
            var posX = random.Next(1, _fieldSize);
            var posY = random.Next(1, _fieldSize);
            _matrix[posX, posY] = true;
        } while (CountMines() < _mines);
    }

    public int CountMines() => FlattenMatrix().Count(m => m);

    private IEnumerable<bool> FlattenMatrix()
    {
        for (var row = 0; row < _matrix.GetLength(0); row++)
        {
            for (var col = 0; col < _matrix.GetLength(1); col++)
            {
                yield return _matrix[row, col];
            }
        }
    }
}