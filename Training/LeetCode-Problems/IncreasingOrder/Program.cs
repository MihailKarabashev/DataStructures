using RangeBST;

var treeNode = new TreeNode(
    new TreeNode(
        new TreeNode(new TreeNode(null,null,1), null, 2), new TreeNode(null, null, 4), 3),
    new TreeNode(null, new TreeNode(new TreeNode(null,null,7), new TreeNode(null,null,9), 8), 6),
    5);

var solution = new Solution();
solution.IncreasingBST(treeNode);