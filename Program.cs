using ScrabbleGameRecorder;

var wordParser = new WordParser(new LetterRepository());

// var testWordsWithScores = new Dictionary<string, int>
// {
//     {"2DZIEŃ", 24},
//     {"DOBR2Y", 10},
//     {"3ŻÓŁWIE2", 51},
// };

// foreach (var testWord in testWordsWithScores)
// {
//     if (wordParser.TryParse(testWord.Key, out var word))
//     {
//         Console.WriteLine($"Parsed word: {word}, expected score: {testWord.Value}");
//     }
// }

while (true)
{
    Console.Write("Enter a word to parse (or press enter to quit): ");
    var input = Console.ReadLine();
    if (string.IsNullOrEmpty(input))
    {
        break;
    }

    if (wordParser.TryParse(input, out var word))
    {
        Console.WriteLine($"Parsed word: {word}");
    }
    else
    {
        Console.WriteLine("Invalid word format. Please try again.");
    }
}