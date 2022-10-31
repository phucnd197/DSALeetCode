namespace DSALeetCode;

public class ListNode
{
    public int val;
    public ListNode? next;

    public ListNode(int[]? values)
    {
        if (values is null)
        {
            return;
        }

        val = values[0];
        if (values.Length == 1)
        {
            return;
        }

        var head = new ListNode(values[1]);
        ListNode? sentinel = head;
        for (var index = 2; index < values.Length; index++)
        {
            sentinel.next = new ListNode(values[index]);
            sentinel = sentinel.next;
        }

        next = head;
    }

    public ListNode(int val = 0, ListNode? next = null)
    {
        this.val = val;
        this.next = next;
    }
}
