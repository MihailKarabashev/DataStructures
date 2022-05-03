using System;
using System.Diagnostics.CodeAnalysis;
using _01.BinaryTree;
using _02.BinarySearchTree;
using _03.MaxHeap;


//var tree = new BinaryTree<int>(
//                       17,
//                       new BinaryTree<int>(
//                           9,
//                           new BinaryTree<int>(3, null, null),
//                           new BinaryTree<int>(11, null, null)
//                       ),
//                       new BinaryTree<int>(
//                           25,
//                           new BinaryTree<int>(20, null, null),
//                           new BinaryTree<int>(31, null, null)
//                       )
//       );

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

Console.WriteLine(bst.Contains(222));
