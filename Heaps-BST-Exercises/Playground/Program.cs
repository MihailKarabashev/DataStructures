using _02.BinarySearchTree;
using System;

var  bst = new BinarySearchTree<int>();
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

bst.Delete(5);
//bst.Insert(12);
//bst.Insert(5);
//bst.Insert(1);
//bst.Insert(8);
//bst.Insert(19);
//bst.Insert(16);
//bst.Insert(23);
//bst.Insert(21);
//bst.Insert(30);

//4, 5, 8, 9, 10, 37

//bst.Range(4,37);
//var ss = bst.Count();

// rank count should be equals to 5
//var ss = bst.Rank(5500);

//bst.Insert(10);
//bst.Insert(1);
//bst.Insert(5);
//bst.Insert(20);

//bst.Insert(10);
//bst.Insert(15);
//bst.Insert(11);
//bst.Insert(20);

//bst.DeleteMin();
Console.WriteLine(Math.Abs(5 - 4));
