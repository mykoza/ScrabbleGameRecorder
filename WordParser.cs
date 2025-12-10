using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace ScrabbleGameRecorder;

partial class WordParser(LetterRepository letterRepository)
{
    private LetterRepository _letterRepository = letterRepository;

    [GeneratedRegex(@"^[2,3]{0,3}(\p{L}[2,3]?)+$")]
    private static partial Regex InputRegex();

    [GeneratedRegex(@"^[2,3]{0,3}")]
    private static partial Regex WordMultiplierRegex();

    [GeneratedRegex(@"\p{L}[2,3]?")]
    private static partial Regex LetterWithMultiplierRegex();

    public bool TryParse(string input, [MaybeNullWhen(false)] out Word word)
    {
        try
        {
            word = Parse(input);
            return true;
        }
        catch
        {
            word = null;
            return false;
        }
    }

    public Word Parse(string input)
    {
        var inputMatch = InputRegex().Match(input);

        if (!inputMatch.Success)
        {
            throw new ArgumentException("Invalid word format");
        }

        var wordMultiplierMatch = WordMultiplierRegex().Match(input).Value;

        var wordMultipliers = new List<int>();
        if (wordMultiplierMatch.Length > 0)
        {
            wordMultipliers.AddRange(wordMultiplierMatch.Split().Select(int.Parse));
        }

        var letterMatches = LetterWithMultiplierRegex().Matches(input);

        var tiles = new List<Tile>();
        foreach (Match match in letterMatches)
        {
            var letterChar = match.Value[0].ToString();
            var letter = _letterRepository.Get(letterChar);
            var tile = new Tile(letter);

            if (match.Value.Length > 1)
            {
                tile.AddMultiplier(int.Parse(match.Value[1].ToString()));
            }

            tiles.Add(tile);
        }

        var word = new Word(tiles, wordMultipliers);
        return word;
    }
}