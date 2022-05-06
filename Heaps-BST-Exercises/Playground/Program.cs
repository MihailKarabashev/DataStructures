using _02.BinarySearchTree;
using System;

var  bst = new BinarySearchTree<int>();

//bst.Insert(10);
//bst.Insert(5);
//bst.Insert(3);
//bst.Insert(1);
//bst.Insert(4);
//bst.Insert(8);
//bst.Insert(9);
//bst.Insert(37);
//bst.Insert(39);
//bst.Insert(45);

//bst.Range(37,4);

bst.Insert(10);
bst.Insert(1);
bst.Insert(5);
bst.Insert(20);

// 5, 10, 20 
bst.DeleteMin();
bst.EachInOrder(Console.WriteLine);
