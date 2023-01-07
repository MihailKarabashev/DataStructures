namespace RangeBST;

public class Solution
{
    public int RangeSumBST(TreeNode root, int low, int high)
    {
        var sum = 0;

        return RangeSumBST(root, low, high, sum);
    }

    private int RangeSumBST(TreeNode root, int low, int high, int sum)
    {
        if (root._value >= low && root._value <= 15) sum += root._value;

        if (root._left != null) sum = RangeSumBST(root._left, low, high, sum);
        if (root._right != null) sum = RangeSumBST(root._right, low, high, sum);

        return sum;
    }
}
