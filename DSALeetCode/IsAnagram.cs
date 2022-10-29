namespace DSALeetCode;

public sealed class IsAnagram
{
    public static bool Function(string s, string t)
    {
        if (s.Length != t.Length)
        {
            return false;
        }

        var sDic = new Dictionary<char, int>();
        for (var index = 0; index < s.Length; index++)
        {
            if (sDic.TryGetValue(s[index], out var count))
            {
                sDic[s[index]] = count + 1;
            }
            else
            {
                sDic.Add(s[index], 1);
            }
        }


        	for (var index = 0; index < t.Length; index++)
        {
            if (sDic.TryGetValue(t[index], out var count))
            {
                if(count - 1 < 0)
                {
                    return false;
                }
                sDic[t[index]] = count - 1;
            }
            else
            {
                return false;
            }
        }

        return true;
    }
}