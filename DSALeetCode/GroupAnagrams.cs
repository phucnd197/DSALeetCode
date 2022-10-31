using System.Text;

namespace DSALeetCode;

public static class GroupAnagrams
{
    public static IList<IList<string>> Solution(string[] strs)
    {
        switch (strs.Length)
        {
            case 0:
                return Array.Empty<IList<string>>();
            case 1:
                return new IList<string>[] { new List<string> { strs[0] } };
            default:
                var result = new Dictionary<string, List<string>>();
                for (var index = 0; index < strs.Length; index++)
                {
                    var word = strs[index];
                    var count = new int[26];
                    for (var inner = 0; inner < word.Length; inner++)
                    {
                        count[word[inner] - 'a'] += 1;
                    }

                    var key = new StringBuilder().AppendJoin('_', count).ToString();
                    // var key = $"{count.GetHashCode()}";
                    if (result.TryGetValue(key, out var words))
                    {
                        words.Add(word);
                    }
                    else
                    {
                        result.Add(key, new List<string> { word });
                    }
                }

                return result.Values.ToArray();
        }
    }
    // public static IList<IList<string>> Function(string[] strs)
    // {
    //     if (strs.Length == 0)
    //     {
    //         return Array.Empty<IList<string>>();
    //     }
    //
    //     if (strs.Length == 1)
    //     {
    //         return new IList<string>[] { new[] { strs[0] } };
    //     }
    //
    //     // var processedWord = new HashSet<string>(); // cache of processed words
    //     // var resultIndex = 0;
    //     // var count = 0;
    //     var result = new List<IList<string>>(strs.Length);
    //     var anagramDic = new Dictionary<string, Dictionary<char, int>>();
    //
    //     // process to see if word is anagram
    //     for (var index = 0; index < strs.Length; index++)
    //     {
    //         // V2
    //         var word = strs[index];
    //         var shouldContinue = false;
    //         for (var i = 0; i < result.Count; i++)
    //         {
    //             var wordBucket = result[i];
    //             if (!IsAnagram(wordBucket[0], word, anagramDic))
    //             {
    //                 continue;
    //             }
    //
    //             wordBucket.Add(word);
    //             shouldContinue = true;
    //             break;
    //         }
    //
    //         if (shouldContinue)
    //         {
    //             continue;
    //         }
    //
    //         result.Add(new List<string> { word });
    //
    //         // V1
    //         // var word = strs[index];
    //         // count++;
    //         // if (processedWord.Contains(word))
    //         // {
    //         //     continue;
    //         // }
    //         //
    //         // result.Add(new List<string> { strs[index] });
    //         // processedWord.Add(word);
    //         // for (var inner = index + 1; inner < strs.Length; inner++)
    //         // {
    //         //     count++;
    //         //
    //         //     if (!IsAnagram(word, strs[inner]))
    //         //     {
    //         //         continue;
    //         //     }
    //         //
    //         //     // Add to result
    //         //     result[resultIndex].Add(strs[inner]);
    //         //     processedWord.Add(strs[inner]);
    //         // }
    //         //
    //         // resultIndex++;
    //     }
    //
    //     return result;
    // }
    //
    // private static bool IsAnagram(string original, string toCompare, IDictionary<string, Dictionary<char, int>> anagramDic)
    // {
    //     if (original.Length != toCompare.Length)
    //     {
    //         return false;
    //     }
    //
    //     if (!anagramDic.TryGetValue(original, out var dict))
    //     {
    //         dict = new Dictionary<char, int>();
    //         for (var index = 0; index < original.Length; index++)
    //         {
    //             if (dict.TryGetValue(original[index], out var currentCount))
    //             {
    //                 dict[original[index]] = currentCount + 1;
    //             }
    //             else
    //             {
    //                 dict.Add(original[index], 1);
    //             }
    //         }
    //
    //         anagramDic.Add(original, dict);
    //     }
    //     
    //     dict = new Dictionary<char, int>(dict);
    //
    //     for (var index = 0; index < toCompare.Length; index++)
    //     {
    //         if (!dict.TryGetValue(toCompare[index], out var currentCount))
    //         {
    //             return false;
    //         }
    //
    //         var newCount = currentCount - 1;
    //         if (newCount < 0)
    //         {
    //             return false;
    //         }
    //
    //         dict[toCompare[index]] = newCount;
    //     }
    //
    //     return true;
    // }
}