namespace DSALeetCode;

public static class ReverseLinkedList
{
    public static ListNode Solution(ListNode head)
    {
        if (head.next is null)
        {
            return head;
        }

        var current = head;
        ListNode prev = null;
        while (current != null)
        {
            var next = current.next;
            current.next = prev;
            prev = current;
            current = next;
        }

        return prev;
        // var stack = new Stack<int>();
        // var currentNode = head;
        // while (currentNode is not null)
        // {
        //     stack.Push(currentNode.Val);
        //     currentNode = currentNode.Next;
        // }
        //
        // switch (stack.Count)
        // {
        //     case 0:
        //         return null;
        //     case 1:
        //         return new ListNode(stack.Pop());
        // }
        //
        // var newHead = new ListNode(stack.Pop());
        // var current = newHead;
        // while (stack.Count > 0)
        // {
        //     current.Next = new ListNode(stack.Pop());
        //     current = current.Next;
        // }
        //
        // return newHead;
    }
}