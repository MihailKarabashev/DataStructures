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

        public bool Contains(T element)
        {
            throw new NotImplementedException();
        }

        public void EachInOrder(Action<T> action)
        {

           this.EachInOrderRecursive(action, this.root);

        }

        private void EachInOrderRecursive(Action<T> action, Node node)
        {
            if (node is null)
            {
                return;
            }

            this.EachInOrderRecursive(action,node.Left);
            action.Invoke(node.Value);
            this.EachInOrderRecursive(action,node.Right);
        }

        public IBinarySearchTree<T> Search(T element)
        {
            throw new NotImplementedException();
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
            else if(element.CompareTo(node.Value) > 0)
            {
                node.Right = this.InsertRecursive(element,node.Right);
            }

            return node;
        }
    }
}
