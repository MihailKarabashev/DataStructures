﻿using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
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

//var bst = new BinarySearchTree<int>();

//bst.Insert(17);
//bst.Insert(9);
//bst.Insert(3);
//bst.Insert(11);
//bst.Insert(25);
//bst.Insert(20);
//bst.Insert(31);

//var bsSubTree = bst.Search(9);
//bsSubTree.EachInOrder(x => Console.Write(x + " "));


var maxHeap = new MaxHeap<int>();
//maxHeap.Add(25);
//maxHeap.Add(17);
//maxHeap.Add(16);
//maxHeap.Add(9);
//maxHeap.Add(5);
//maxHeap.Add(8);
//maxHeap.Add(15);
//maxHeap.Add(6);

maxHeap.Add(5);
maxHeap.Add(3);
maxHeap.Add(1);


maxHeap.ExtractMax();
maxHeap.ExtractMax();
