namespace _01.BinaryTree
{
    using System;
    using System.Collections.Generic;

    public class BinaryTree<T> : IAbstractBinaryTree<T>
    {
        public BinaryTree(T element, IAbstractBinaryTree<T> left, IAbstractBinaryTree<T> right)
        {
            this.Value = element;
            this.LeftChild = left;
            this.RightChild = right;
        }

        public T Value { get; private set; }

        public IAbstractBinaryTree<T> LeftChild { get; private set; }

        public IAbstractBinaryTree<T> RightChild { get; private set; }

        public string AsIndentedPreOrder(int indent)
        {
            throw new NotImplementedException();
        }

        public void ForEachInOrder(Action<T> action)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IAbstractBinaryTree<T>> InOrder()
        {
            throw new NotImplementedException();
        }

        //Left-Right-Root - 3, 11, 9, 20, 31, 25, 17
        public IEnumerable<IAbstractBinaryTree<T>> PostOrder()
        {
            var list = new List<IAbstractBinaryTree<T>>();

            if (this.LeftChild is not null)
            {
                list.AddRange(this.LeftChild.PostOrder());
            }

            if (this.RightChild is not null)
            {
                list.AddRange(this.RightChild.PostOrder());
            }

            list.Add(this);

            return list;

        }

        //Root - Left - Right - 17 9 3 11 25 20 31
        public IEnumerable<IAbstractBinaryTree<T>> PreOrder()
        {
            var list = new List<IAbstractBinaryTree<T>>();
            list.Add(this);

            if (this.LeftChild is not null)
            {
                list.AddRange(this.LeftChild.PreOrder());
            }

            if (this.RightChild is not null)
            {
                list.AddRange(this.RightChild.PreOrder());
            }

            return list;
        }
    }
}
