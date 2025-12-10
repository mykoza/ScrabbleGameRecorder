namespace ScrabbleGameRecorder;

record Letter(string Character, int Value)
{
    public static Letter Parse(string input)
    {
        var parts = input.Split(' ');
        return new Letter(parts[0], int.Parse(parts[3]));
    }
}

class LetterRepository
{
    private static readonly Dictionary<string, Letter> _letters = new()
    {
        {"A",  new Letter("A", 1) },
        {"Ą",  new Letter("Ą", 5) },
        {"B",  new Letter("B", 3) },
        {"C",  new Letter("C", 2) },
        {"Ć",  new Letter("Ć", 6) },
        {"D",  new Letter("D", 2) },
        {"E",  new Letter("E", 1) },
        {"Ę",  new Letter("Ę", 5) },
        {"F",  new Letter("F", 5) },
        {"G",  new Letter("G", 3) },
        {"H",  new Letter("H", 3) },
        {"I",  new Letter("I", 1) },
        {"J",  new Letter("J", 3) },
        {"K",  new Letter("K", 2) },
        {"L",  new Letter("L", 2) },
        {"Ł",  new Letter("Ł", 3) },
        {"M",  new Letter("M", 2) },
        {"N",  new Letter("N", 1) },
        {"Ń",  new Letter("Ń", 7) },
        {"O",  new Letter("O", 1) },
        {"Ó",  new Letter("Ó", 5) },
        {"P",  new Letter("P", 2) },
        {"R",  new Letter("R", 1) },
        {"S",  new Letter("S", 1) },
        {"Ś",  new Letter("Ś", 5) },
        {"T",  new Letter("T", 2) },
        {"U",  new Letter("U", 3) },
        {"W",  new Letter("W", 1) },
        {"Y",  new Letter("Y", 2) },
        {"Z",  new Letter("Z", 1) },
        {"Ź",  new Letter("Ź", 9) },
        {"Ż",  new Letter("Ż", 5) },
        {"_",  new Letter("_", 0) }
    };

    public Letter Get(string character)
    {
        return _letters[character];
    }
}
