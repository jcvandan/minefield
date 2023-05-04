namespace Minefield.Core;

public record Position(int X, int Y)
{
    public string AsChessNotation()
    {
        var col = (char)(65 + X);
        var row = (Y + 1).ToString();

        return $"{col}{row}";
    }
}