public sealed class IsValidClosingBracket
{
    public static bool Solution(string s)
    {
        if (s.Length is 0 or 1)
        {
            return false;
        }

        var braces = new Dictionary<char, char>()
        {
            [')'] = '(',
            ['}'] = '{',
            [']'] = '[',
        };
        var stack = new Stack<char>();
        foreach (var character in s.AsSpan())
        {
            if (braces.TryGetValue(character, out var closingBrace))
            {
                if (stack.Count == 0 || closingBrace != stack.Pop())
                {
                    return false;
                }
                else
                {
                    continue;
                }
            }

            stack.Push(character);
        }

        return stack.Count == 0;
    }
}