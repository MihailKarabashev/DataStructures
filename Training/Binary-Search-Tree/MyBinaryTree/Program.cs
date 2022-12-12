
using MyBinaryTree;

var binaryTree = new BinaryTree<int>(7,
            new BinaryTree<int>(4 ,
                new BinaryTree<int>(2, 
                      new BinaryTree<int>(1), new BinaryTree<int>(3)),
                new BinaryTree<int>(5,
                     null, new BinaryTree<int>(6))),
            new BinaryTree<int>(9, 
                 new BinaryTree<int>(8), 
                 new BinaryTree<int>(11, new BinaryTree<int>(10), null)));


var preOrderedTree = binaryTree.PreOrder();

foreach (var item in preOrderedTree)
{
    Console.WriteLine(item.Value);
}

