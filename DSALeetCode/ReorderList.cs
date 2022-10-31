namespace DSALeetCode;

public static class ReorderList
{
    public static void Solution(ListNode head)
    {
        var sentinel = head;
        var buffer = new ListNode(0);
        var next = sentinel.next;
        head.next = buffer;
        buffer.next = next;
        while (true)
        {
            if (sentinel.next.next is null)
            {
                var final = sentinel.next;
                sentinel.next = null;
                sentinel = final;
                break;
            }

            sentinel = sentinel.next;
        }

        buffer.val = sentinel.val;
    }
}