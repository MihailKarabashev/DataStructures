namespace _02.LowestCommonAncestor
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BinaryTree<T> : IAbstractBinaryTree<T>
        where T : IComparable<T>
    {
        public BinaryTree(
            T value,
            BinaryTree<T> leftChild,
            BinaryTree<T> rightChild)
        {
            this.Value = value;
            this.LeftChild = leftChild;
            this.RightChild = rightChild;
            if (leftChild != null)
            {
                this.LeftChild.Parent = this;
            }

            if (rightChild != null)
            {
                this.RightChild.Parent = this;
            }
        }

        public T Value { get; set; }

        public BinaryTree<T> LeftChild { get; set; }

        public BinaryTree<T> RightChild { get; set; }

        public BinaryTree<T> Parent { get; set; }

        public T FindLowestCommonAncestor(T first, T second)
        {
            var firstNode = this.FindNode(first, this);
            var secoundNode = this.FindNode(second, this);

            if (firstNode is null || secoundNode is null)
            {
                throw new InvalidOperationException();
            }

            var firstNodeAncestors = this.FindNodeAncestors(firstNode);
            var secoundNodeAncestors = this.FindNodeAncestors(secoundNode);

            
            var lowestCommonAncestor = firstNodeAncestors.Intersect(secoundNodeAncestors).FirstOrDefault();
                                       

            return lowestCommonAncestor;
        }

        private List<T> FindNodeAncestors(BinaryTree<T> tree)
        {
            var list = new List<T>();

            while (tree != null)
            {
                list.Add(tree.Value);
                tree = tree.Parent;
            }

            return list;
        }

        private BinaryTree<T> FindNode(T element, BinaryTree<T> tree)
        {
            var queue = new Queue<BinaryTree<T>>();
            var count = 1;
            queue.Enqueue(tree);

            while (queue.Count > 0)
            {
                var subTree = queue.Dequeue();

                if (subTree.Value.Equals(element) && count > 1)
                {
                    return subTree;
                }

                if (subTree.LeftChild is not null)
                {
                    queue.Enqueue(subTree.LeftChild);

                }

                if (subTree.RightChild is not null)
                {
                    queue.Enqueue(subTree.RightChild);
                }

                count++;
            }

            return null;
        }
    }
}
