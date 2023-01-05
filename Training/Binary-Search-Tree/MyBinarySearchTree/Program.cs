using MyBinarySearchTree;

var binarySearchTree = new BinarySearchTree<int>();

//binarySearchTree.Insert(7);
//binarySearchTree.Insert(9);
//binarySearchTree.Insert(8);
//binarySearchTree.Insert(4);
//binarySearchTree.Insert(2);
//binarySearchTree.Insert(1);

//var count = binarySearchTree.Rank(2);
//Console.WriteLine(count);

var bst = new BinarySearchTree<int>();


bst.Insert(10);
bst.Insert(5);
bst.Insert(3);
bst.Insert(1);
bst.Insert(4);
bst.Insert(8);
bst.Insert(9);
bst.Insert(37);
bst.Insert(39);
bst.Insert(45);

var floor = bst.Floor(5);
Console.WriteLine(floor);
