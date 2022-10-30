// See https://aka.ms/new-console-template for more information

using System.Text.Json;
using DSALeetCode;

// LengthOfLongestSubstring("au");
// LengthOfLongestSubstring("pwwkew");
// FindMedianSortedArrays(new[] { 1, 2 }, new[] { 3, 4 });
// IsAnagram("anagram", "nagaram");
// TwoSum(new[] { 3, 2, 4 }, 6);
// Search(new[] { -1, 0, 5 }, 2);
// IsValid("}(");
// SingleNumber(new[] { -1, -1, -2 });
//["MinStack","push","push","push","push","getMin","pop","getMin","pop","getMin","pop","getMin"]
//[[],[2],[0],[3],[0],[],[],[],[],[],[],[]]
//[null,null,null,null,null,0,null,0,null,0,null,2]
//MinStack minStack = new MinStack();
//minStack.Push(2);
//minStack.Push(0);
//minStack.Push(3);
//minStack.Push(0);
//SimpleResultLog(0, minStack.GetMin());
//minStack.Pop();
//SimpleResultLog(0, minStack.GetMin());
//minStack.Pop();
//SimpleResultLog(0, minStack.GetMin());
//minStack.Pop();
//SimpleResultLog(2,minStack.GetMin());


SimpleResultLog(
    new[] { 2, 2, 2, 1, 4, 3, 3, 9, 6, 7, 19 },
    RelativeSortArray.Function(new[] { 2, 3, 1, 3, 2, 4, 6, 7, 9, 2, 19 }, new[] { 2, 1, 4, 3, 9, 6 })
);

void SimpleResultLog(object expect, object actual)
{
    Console.WriteLine(
        $"expected {JsonSerializer.Serialize(expect)} - actual {JsonSerializer.Serialize(actual)}");
}