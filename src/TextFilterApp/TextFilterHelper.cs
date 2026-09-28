namespace TextFilterApp;

public class TextFilterHelper
{
    private static readonly char[] separators = { ' ', '\n', '\r', '\t', ',', '.', '!', '?', ';', ':', '\'', '(', ')' };
    private static readonly char[] vowels = {'a','e','i','o','u'};
    private static readonly char[] letters = {'t'};
    public static string ApplyFilters(string input)
    {
        var result = CleanUpContent(input);
        result = FilterVowelInMiddle(result);
        result = FilterMoreThanThreeFilterLetters(result);
        result = FilterLetters(result);
        return string.Join(" ", result.ToList());
    }

    public static IEnumerable<string> CleanUpContent(string input)
    {
        return input.Split(separators, StringSplitOptions.RemoveEmptyEntries);
    }

    public static IEnumerable<string> FilterVowelInMiddle(IEnumerable<string> words)
    {
        var result = new List<string>();
        foreach (var word in words)
        {
            var mid = word.Length / 2;
            var midChar = word.Length % 2 == 0
                        ? word.Substring(mid-1, 2)
                        : word[mid].ToString();
            if(midChar.Any(a => vowels.Contains(char.ToLower(a))))
            {
                result.Add(word);
            }
        }
        return result;
    }

    public static IEnumerable<string> FilterMoreThanThree(IEnumerable<string> words)
    {
        var result = words.Where(w => w.Length >= 3);
        return result;
    }

    public static IEnumerable<string> FilterLetters(IEnumerable<string> words)
    {
        var result = words.Where(w => !w.Any(a => letters.Contains(char.ToLower(a))));
        return result;
    }
}
