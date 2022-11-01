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

public class TreeNode
{
    public int val;
    public TreeNode? left;
    public TreeNode? right;

    public TreeNode(int[]? array)
    {
        if (array is null || array.Length == 0)
        {
            return;
        }

        if (array.Length >= 1)
        {
            val = array[0];
        }

        for (var index = 1; index < array.Length; index++)
        {
            AddNode(this, array[index], 0);
        }
    }

    private static void AddNode(TreeNode root, int value, int index)
    {
        if (root.left is null)
        {
            root.left = new TreeNode(value);
            return;
        }

        if (root.right is null)
        {
            root.right = new TreeNode(value);
            return;
        }

        if (index % 2 == 0)
        {
            AddNode(root.right, value, ++index);
        }
        else
        {
            AddNode(root.left, value, ++index);
        }
    }

    public TreeNode(int val = 0, TreeNode? left = null, TreeNode? right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}