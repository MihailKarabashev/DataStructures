using RangeBST;

var treeNode = new TreeNode(
    new TreeNode(
        new TreeNode(null,null,3), new TreeNode(null,null,7), 5),
    new TreeNode(null, new TreeNode(null,null,18), 15),
    10);
var solution = new Solution();

var count = solution.RangeSumBST(treeNode, 7, 15);
Console.WriteLine(count);
