// See https://aka.ms/new-console-template for more information

using System.Text.Json;
using System.Xml.Serialization;
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
// SimpleResultLog(
//     new[] { 2, 2, 2, 1, 4, 3, 3, 9, 6, 7, 19 },
//     RelativeSortArray.Function(new[] { 2, 3, 1, 3, 2, 4, 6, 7, 9, 2, 19 }, new[] { 2, 1, 4, 3, 9, 6 })
// );
// SimpleResultLog(
//     "no expectation",
//     GroupAnagrams.Function(new[] { "eat", "tea", "tan", "ate", "nat", "bat" })
// );
// var node = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5)))));
// SimpleResultLog(
//    "5,4,3,2,1",
//    ReverseLinkedList.Function(node)
// );
// var node1 = new ListNode(1, new ListNode(2, new ListNode(4)));
// var node2 = new ListNode(1, new ListNode(3, new ListNode(4)));
// SimpleResultLog(
//    "1, 1, 2, 3, 4, 4",
//    MergeTwoSortedList.Function(node1, node2)
// );

// var node1 = new ListNode(new[] { 1, 2, 3, 4 });
// ReorderList.Solution(node1);

// var node1 = new ListNode(new[] { -21, 10, 17, 8, 4, 26, 5, 35, 33, -7, -16, 27, -12, 6, 29, -12, 5, 9, 20, 14, 14, 2, 13, -24, 21, 23, -21, 5 });
// ListHasCycle.Solution(node1);

// var treeNode = new TreeNode(3, new TreeNode(9), new TreeNode(20, new TreeNode(15), new TreeNode(7)));
// SimpleResultLog(
//     3,
//      MaxDepth.Solution(treeNode)
// );
// var array = new[] { 2, 7, 7, 7, 11, 15 };
// var expectation = new[] { 1, 2 };
// const int target = 9;
// SimpleResultLog(
//     expectation,
//     TwoSum2.BinarySearchLeftMost(array, 0, target)
// );

void SimpleResultLog(object expect, object actual)
{
    Console.WriteLine(
        $"expected {JsonSerializer.Serialize(expect)} - actual {JsonSerializer.Serialize(actual)}");
}