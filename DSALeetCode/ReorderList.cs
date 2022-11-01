namespace DSALeetCode;

public static class ReorderList
{
    /// <summary>
    /// Solution idea
    /// 1. Get the middle of the linked list <br/>
    /// 2. Reverse direction of the list from middle <br/>
    /// 3. Reorder list <br/>
    /// </summary>
    /// <param name="head"></param>
    public static void Solution(ListNode head)
    {
        var mid = GetMid(head);
        var reversedFromMid = Reverse(mid);

        Reorder(head, reversedFromMid);
        Console.WriteLine("end");
    }

    /// <summary>
    /// Reorder list
    /// 1. Start node will point to end node then move to old next node <br/>
    /// 2. End node will point to start node and move to old next node <br/> 
    /// </summary>
    /// <param name="fromStart"></param>
    /// <param name="fromEnd"></param>
    private static void Reorder(ListNode fromStart, ListNode fromEnd)
    {
        ListNode? startPointer = fromStart, endPointer = fromEnd;
        while (endPointer.next != null)
        {
            var next = startPointer.next;
            startPointer.next = endPointer;
            startPointer = next;

            next = endPointer.next;
            endPointer.next = startPointer;
            endPointer = next;
        }
    }

    /// <summary>
    /// return the middle of the linked list by using 2 pointer <br/>
    /// the faster increment by factor of 2 <br/>
    /// the other increment by 1 <br/>
    /// we return the slower - the middle of the list
    /// </summary>
    /// <param name="head"></param>
    /// <returns></returns>
    private static ListNode GetMid(ListNode head)
    {
        ListNode? slow = head, fast = head;
        while (fast is { next: { } })
        {
            slow = slow!.next;
            fast = fast.next.next;
        }

        return slow!;
    }

    /// <summary>
    /// Reverse direction of the linked list from <br/>
    /// 1 -> 2 -> 3 ... -> n to n -> n-1 -> n-2 ... -> 1
    /// </summary>
    /// <param name="head"></param>
    /// <returns></returns>
    private static ListNode Reverse(ListNode head)
    {
        ListNode? prev = null, current = head, next = null;
        while (current is { })
        {
            next = current.next;
            current.next = prev;
            prev = current;
            current = next;
        }

        return prev;
    }

    /// <summary>
    /// Solution idea, create list containing all nodes
    /// loop create new linked list with even index = 1 and odd index = n - 1
    /// </summary>
    /// <param name="head"></param>
    private static void SolutionV1(ListNode head)
    {
        var sentinel = head;
        var list = new List<ListNode>();
        while (sentinel is not null)
        {
            list.Add(new ListNode(sentinel.val));
            sentinel = sentinel.next;
        }

        var index = 1;
        var mainIndex = 1;
        sentinel = head;
        while (mainIndex < list.Count)
        {
            if ((mainIndex + 1) % 2 == 0)
            {
                sentinel.next = list[^index];
            }
            else
            {
                sentinel.next = list[index];
                ++index;
            }

            sentinel = sentinel.next;
            ++mainIndex;
        }
    }
}