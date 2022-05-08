using _02.LowestCommonAncestor;
using System;
using System.Collections.Generic;
using System.Linq;

var binaryTree = new BinaryTree<int>(
          12,
          new BinaryTree<int>(5,
              new BinaryTree<int>(1, null, null),
              new BinaryTree<int>(8, null, null)
          ),
          new BinaryTree<int>(19,
              new BinaryTree<int>(16, null, null),
              new BinaryTree<int>(23,
                  new BinaryTree<int>(21, null, null),
                  new BinaryTree<int>(30, null, null)
              )
          )
      );



binaryTree.FindLowestCommonAncestor(19, 23);