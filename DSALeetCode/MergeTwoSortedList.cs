namespace DSALeetCode;

public static class MergeTwoSortedList
{
    public static ListNode? Solution(ListNode? list1, ListNode? list2)
    {
        if (list1 is null && list2 is null)
        {
            return null;
        }
        if (list1 is null)
        {
            return list2;
        }
        if (list2 is null)
        {
            return list1;
        }

        ListNode? head;
        if (list1.val < list2.val)
        {
            head = list1;
            list1 = list1.next;
        }
        else
        {
            head = list2;
            list2 = list2.next;
        }

        var current = head;
        while (list1 != null && list2 != null)
        {
            if (list1.val < list2.val)
            {
                current.next = list1;
                list1 = list1.next;
            }
            else
            {
                current.next = list2;
                list2 = list2.next;
            }

            current = current.next;
        }

        current.next = list1 ?? list2;
        return head;
    }
}