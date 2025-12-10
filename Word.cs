using System.Text.RegularExpressions;

namespace ScrabbleGameRecorder;

record Word
{
    private List<Tile> _tiles = [];
    private List<int> _multipliers = [];

    public Word(List<Tile> tiles)
    {
        _tiles = tiles;
    }

    public Word(List<Tile> tiles, List<int> multipliers)
    {
        _tiles = tiles;
        _multipliers = multipliers;
    }

    public void AddMultiplier(int multiplier)
    {
        _multipliers.Add(multiplier);
    }

    public int Score()
    {
        int baseScore = _tiles.Sum(t => t.Score());
        int totalMultiplier = _multipliers.Aggregate(1, (acc, val) => acc * val);
        return baseScore * totalMultiplier;
    }

    public override string ToString()
    {
        return $"{string.Join("", _tiles.Select(t => t.ToString()))}, total score: {Score()}";
    }
}