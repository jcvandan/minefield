namespace Minefield.Core;

public class PlayerModel
{
    private int _lives;

    public PlayerModel(int lives) => _lives = lives;

    public void Hit() => _lives--;

    public bool IsDead() => _lives <= 0;
}