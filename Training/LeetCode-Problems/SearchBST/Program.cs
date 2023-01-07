using RangeBST;

var treeNode = new TreeNode(
    new TreeNode(new TreeNode(null,null,1),new TreeNode(null,null,3),2),
    new TreeNode(null,null,7),
    4);

var solution = new Solution();
var searchedTree = solution.SearchBST(treeNode, 5);
;
