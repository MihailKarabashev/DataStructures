namespace _02.BinarySearchTree
{
    using System;

    public class BinarySearchTree<T> : IBinarySearchTree<T>
        where T : IComparable<T>
    {
        private class Node
        {
            public Node(T value)
            {
                Value = value;
            }

            public T Value { get; private set; }

            public Node Left { get; set; }

            public Node Right { get; set; }
        }

        private Node root;

        public BinarySearchTree() { }

        private BinarySearchTree(Node node)
        {
            this.PreOrderCopy(node);
        }

        public bool Contains(T element)
        {
            //bool isFound = default;
            //this.Contains(element, this.root, ref isFound);
            //return isFound;

            return this.FindElement(element) != null;
        }

        public void EachInOrder(Action<T> action)
        {
            this.EachInOrderRecursive(action, this.root);
        }

        public IBinarySearchTree<T> Search(T element)
        {
           var node = this.FindElement(element);

            if (node == null) return null;

           return new BinarySearchTree<T>(node);
        }

        public void Insert(T element)
        {
            this.root = this.InsertRecursive(element, this.root);
        }

        private Node InsertRecursive(T element, Node node)
        {
            if (node == null)
            {
                node = new Node(element);
            }
            else if (element.CompareTo(node.Value) < 0)
            {
                node.Left = this.InsertRecursive(element, node.Left);
            }
            else if (element.CompareTo(node.Value) > 0)
            {
                node.Right = this.InsertRecursive(element, node.Right);
            }

            return node;
        }

        private void EachInOrderRecursive(Action<T> action, Node node)
        {
            if (node is null)
            {
                return;
            }

            this.EachInOrderRecursive(action, node.Left);
            action.Invoke(node.Value);
            this.EachInOrderRecursive(action, node.Right);
        }

        private Node FindElement(T element)
        {
            var node = this.root;

            while (node != null)
            {
                if (element.CompareTo(node.Value) < 0)
                {
                    node = node.Left;
                }
                else if (element.CompareTo(node.Value) > 0)
                {
                    node = node.Right;
                }
                else if (element.CompareTo(node.Value) == 0) break;
            }

            return node;
        }

        private void Contains(T element, Node node, ref bool isFound)
        {
            if (node is null)
            {
                isFound = false;
            }
            else if (element.CompareTo(node.Value) < 0)
            {
                this.Contains(element, node.Left, ref isFound);
            }
            else if (element.CompareTo(node.Value) > 0)
            {
                this.Contains(element, node.Right, ref isFound);
            }
            else if (element.CompareTo(node.Value) == 0)
            {
                isFound = true;
            }
        }

        private void PreOrderCopy(Node node)
        {
            if (node == null) return;

            this.Insert(node.Value);
            this.PreOrderCopy(node.Left);
            this.PreOrderCopy(node.Right);
        }

    }
}
