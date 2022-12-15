using MyBinarySearchTree;

var binarySearchTree = new BinarySearchTree<int>();

binarySearchTree.Insert(17);
binarySearchTree.Insert(9);
binarySearchTree.Insert(19);
binarySearchTree.Insert(6);
binarySearchTree.Insert(8);

var rank = binarySearchTree.Rank(8);
Console.WriteLine(rank);

//var count = binarySearchTree.Count();
//Console.WriteLine(count);

//binarySearchTree.Delete(8);
// binarySearchTree.DeleteMin();
//binarySearchTree.DeleteMax();
//var isFound = binarySearchTree.Contains(8);
//Console.WriteLine(isFound);

//var bst = binarySearchTree.Search(9);
//bst.Insert(50);
//binarySearchTree.EachInOrder(Console.WriteLine);