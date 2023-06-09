﻿namespace Minefield.Core;

/// <summary>
/// A 2d vector, 0 based
/// </summary>
public record Position(int X, int Y)
{
    public string AsChessNotation()
    {
        var col = (char)(65 + X);
        var row = (Y + 1).ToString();

        return $"{col}{row}";
    }
}