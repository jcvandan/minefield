namespace Minefield.Core;

public interface IPlayer
{
    void Hit();
    bool IsDead();
}

public class PlayerModel : IPlayer
{
    private int _lives;

    public PlayerModel(int lives)
    {
        if (_lives <= 0) throw new ArgumentOutOfRangeException();
        
        _lives = lives;
    }

    public void Hit() => _lives--;
    public bool IsDead() => _lives <= 0;
}