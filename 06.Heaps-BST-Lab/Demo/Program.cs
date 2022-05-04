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

bst.Insert(17);
bst.Insert(9);
bst.Insert(3);
bst.Insert(11);
bst.Insert(25);
bst.Insert(20);
bst.Insert(31);

var bsSubTree = bst.Search(9);
bsSubTree.EachInOrder(x => Console.Write(x + " "));
