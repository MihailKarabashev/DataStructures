
using MyBinaryTree;
using System.Globalization;
using System.Runtime.CompilerServices;

var binaryTree = new BinaryTree<int>(7,
            new BinaryTree<int>(4,
                new BinaryTree<int>(2,
                      new BinaryTree<int>(1), new BinaryTree<int>(3)),
                new BinaryTree<int>(5,
                     null, new BinaryTree<int>(6))),
            new BinaryTree<int>(9,
                 new BinaryTree<int>(8),
                 new BinaryTree<int>(11, new BinaryTree<int>(10), null)));


var inOrderTree = binaryTree.InOrder();

foreach (var item in inOrderTree)
{
    Console.Write(item.Value + " ");
}

//var binaryTree = new BinaryTree<int>(1,
//    new BinaryTree<int>(2,
//                new BinaryTree<int>(5), new BinaryTree<int>(6)), 
//    new BinaryTree<int>(3));


//var str = binaryTree.PreOrderTest(binaryTree);
//Console.WriteLine(str);