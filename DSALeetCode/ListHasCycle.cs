namespace DSALeetCode;

public static class ListHasCycle
{
    public static bool Solution(ListNode head)
    {
        var nodeDic = new HashSet<ListNode>();
        var sentinel = head;
        while (sentinel != null)
        {
            if (nodeDic.Contains(sentinel))
            {
                return true;
            }

            nodeDic.Add(sentinel);
            sentinel = sentinel.next;
        }

        return false;
    }
}