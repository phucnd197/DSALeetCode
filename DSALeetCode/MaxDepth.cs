namespace DSALeetCode;

public static class MaxDepth
{
    public static int Solution(TreeNode? root)
    {
        if (root is null)
        {
            return 0;
        }

        if (root.left is null && root.right is null)
        {
            return 1;
        }

        var left = 1;
        var right = 1;
        var tasks = new[]
        {
            Task.Run(() =>
            {
                if (root.left is { })
                {
                    left = Iterate(root.left, 1);
                }
            }),
            Task.Run(() =>
            {
                if (root.right is { })
                {
                    right = Iterate(root.right, 1);
                }
            })
        };
        Task.WhenAll(tasks).Wait();
        return Math.Max(left, right);
    }

    private static int Iterate(TreeNode node, int currentCount)
    {
        ++currentCount;
        if (node.left is null && node.right is null)
        {
            return currentCount;
        }

        var left = currentCount;
        if (node.left is { })
        {
            left = Iterate(node.left, currentCount);
        }

        var right = currentCount;
        if (node.right is { })
        {
            right = Iterate(node.right, currentCount);
        }

        return Math.Max(left, right);
    }
}