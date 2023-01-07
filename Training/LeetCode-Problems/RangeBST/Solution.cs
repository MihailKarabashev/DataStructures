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
        if (root._value >= low && root._value <= high) sum += root._value;

        if (root._left != null) sum = RangeSumBST(root._left, low, high, sum);
        if (root._right != null) sum = RangeSumBST(root._right, low, high, sum);

        return sum;
    }

    public TreeNode IncreasingBST(TreeNode root)
    {
        var listNodes = new List<TreeNode>();
        IncreasingBST(root, listNodes);

        root = listNodes[0];
        root._left = null;
        root._right = listNodes[1];

        for (int i = 1; i < listNodes.Count; i++)
        {
            listNodes[i]._left = null;

            if (i < listNodes.Count - 1) listNodes[i]._right = listNodes[i + 1];
            else listNodes[i]._right = null;
        }

        return root;
    }

    private void IncreasingBST(TreeNode node, List<TreeNode> listOfNodes)
    {
        if (node == null) return;

        if (node._left != null) IncreasingBST(node._left, listOfNodes);
         listOfNodes.Add(node);
        if (node._right != null) IncreasingBST(node._right, listOfNodes);
    }
}
