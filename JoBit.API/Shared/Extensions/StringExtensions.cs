namespace JoBit.API.Shared.Extensions;

public static class StringExtensions
{
    public static string ToSnakeCase(this string text)
    {
        static IEnumerable<char> Convert(CharEnumerator letter)
        {   
            if(!letter.MoveNext()) yield break;
            yield return char.ToLower(letter.Current);

            while (letter.MoveNext())
            {
                if (char.IsUpper(letter.Current))
                {
                    yield return '_';
                    yield return char.ToLower(letter.Current);
                }
                else
                    yield return letter.Current;
            }
        }

        return new string(Convert(text.GetEnumerator()).ToArray());
    }

    public static string ToSnakeCaseMethodOne(string text)
    {
        List<char> snakeCase = new List<char>();
  
        foreach(char character in text) {
            if(char.IsUpper(character)) {
                snakeCase.Add('_');
                snakeCase.Add(char.ToLower(character));
            }
            else
                snakeCase.Add(character);
        }
        snakeCase.RemoveAt(0);
        string snakeCaseText = new string(snakeCase.ToArray());
        return snakeCaseText;
    }

    public static string ToSnakeCaseMethodTwo(string word)
    {
        string newText = "";
        if(word == "")
            return word;
        newText = newText + char.ToLower(word[0]);
        for (int charIndex = 1; charIndex < word.Length; charIndex++)
        {
            if (char.IsUpper(word[charIndex]))
            {
                newText = newText + "_";
                newText = newText + (char.ToLower(word[charIndex]));
            }
            else
                newText = newText + word[charIndex];
        }
        return newText;
    }


}