
namespace ScrabbleGameRecorder;

class Tile
{
    private Letter _letter;
    private List<int> _multipliers = [];

    public Tile(Letter letter)
    {
        _letter = letter;
    }

    public Tile(Letter letter, List<int> multipliers)
    {
        _letter = letter;
        _multipliers = multipliers;
    }

    public void AddMultiplier(int multiplier)
    {
        _multipliers.Add(multiplier);
    }

    public int Score()
    {
        int score = _letter.Value;
        foreach (var multiplier in _multipliers)
        {
            score *= multiplier;
        }
        return score;
    }

    public override string ToString()
    {
        return _letter.Character;
    }
}
