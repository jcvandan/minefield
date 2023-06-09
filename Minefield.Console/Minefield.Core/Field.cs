﻿namespace Minefield.Core;

public interface IField
{
    bool IsHit(Position position);
    bool IsAtEnd(Position position);
}

public class Field : IField
{
    private readonly bool[,] _matrix;
    private readonly int _fieldSize;
    private readonly int _mines;

    public Field(int size, int mines)
    {
        _fieldSize = size;
        _mines = mines;
        _matrix = new bool[size, size];

        PlaceMines();
    }

    private void PlaceMines()
    {
        var random = new Random();
        do
        {
            var posX = random.Next(0, _fieldSize - 1);
            var posY = random.Next(0, _fieldSize - 1);
            _matrix[posX, posY] = true;
        } while (CountMines() < _mines);
    }

    public bool IsHit(Position position) => _matrix[position.X, position.Y];
    public bool IsAtEnd(Position position) => position.X == _fieldSize - 1;

    private int CountMines() => FlattenMatrix().Count(m => m);

    private IEnumerable<bool> FlattenMatrix()
    {
        for (var row = 0; row < _matrix.GetLength(0); row++)
        for (var col = 0; col < _matrix.GetLength(1); col++)
        {
            yield return _matrix[row, col];
        }
    }
}