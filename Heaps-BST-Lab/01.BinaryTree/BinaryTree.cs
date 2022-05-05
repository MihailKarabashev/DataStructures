namespace _01.BinaryTree
{
    using System;
    using System.Collections.Generic;
    using System.Text;

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
            var sb = new StringBuilder();

            this.PreOrderDfs(sb, indent, this);

            return sb.ToString().TrimEnd();
        }
        //Left-Root-Right - 3, 9, 11, 17, 20, 25, 31
        public void ForEachInOrder(Action<T> action)
        {
            if (this.LeftChild is not null)
            {
                this.LeftChild.ForEachInOrder(action);
            }

            action.Invoke(this.Value);

            if (this.RightChild is not null)
            {
                this.RightChild.ForEachInOrder(action);
            }
        }

        //Left-Root-Right - 3, 9, 11, 17, 20, 25, 31
        public IEnumerable<IAbstractBinaryTree<T>> InOrder()
        {
            var list = new List<IAbstractBinaryTree<T>>();

            if (this.LeftChild is not null)
            {
                list.AddRange(this.LeftChild.InOrder());
            }

            list.Add(this);

            if (this.RightChild is not null)
            {
                list.AddRange(this.RightChild.InOrder());
            }

            return list;

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

        private void PreOrderDfs(StringBuilder sb, int indent, IAbstractBinaryTree<T> tree)
        {
            sb
            .Append(' ', indent)
            .AppendLine(tree.Value.ToString());

            if (tree.LeftChild is not null)
            {
                this.PreOrderDfs(sb, indent + 2, tree.LeftChild);
            }

            if (tree.RightChild is not null)
            {
                this.PreOrderDfs(sb, indent + 2, tree.RightChild);
            }
        }

    }
}
