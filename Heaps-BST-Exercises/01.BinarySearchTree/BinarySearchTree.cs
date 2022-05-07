namespace _02.BinarySearchTree
{
    using System;
    using System.Collections.Generic;

    public class BinarySearchTree<T> : IBinarySearchTree<T> where T : IComparable
    {
        private class Node
        {
            public Node(T value)
            {
                this.Value = value;
            }

            public T Value { get; }
            public Node Left { get; set; }
            public Node Right { get; set; }
        }

        private Node root;

        private BinarySearchTree(Node node)
        {
            this.PreOrderCopy(node);
        }

        public BinarySearchTree()
        {
        }

        public void Insert(T element)
        {
            this.root = this.Insert(element, this.root);
        }

        public bool Contains(T element)
        {
            Node current = this.FindElement(element);

            return current != null;
        }

        public void EachInOrder(Action<T> action)
        {
            this.EachInOrder(this.root, action);
        }

        public IBinarySearchTree<T> Search(T element)
        {
            Node current = this.FindElement(element);

            return new BinarySearchTree<T>(current);
        }

        public void Delete(T element)
        {
            throw new NotImplementedException();
        }

        public void DeleteMax()
        {
            if (this.root is null)
            {
                throw new InvalidOperationException();
            }

            this.root = this.DeleteMax(this.root);
        }

        public void DeleteMin()
        {
            if (this.root is null)
            {
                throw new InvalidOperationException();
            }

            //if there isn't  left child we set this.root to this.root.Right, witch means we remove our root
            //if there is left child we go recursivly to the bottom
            this.root = this.DeleteMin(this.root);
        }


        public int Count()
        {
            if (this.root is null) return 0;

            int count = 0;

            this.Count(this.root, ref count);

            return count;
        }

        public int Rank(T element)
        {
            if (this.root is null) return 0;

            int count = 0;

            this.Rank(this.root, element, ref count);

            return count;
        }

        public T Select(int rank)
        {
            if (this.root is null)
            {
                throw new InvalidOperationException();
            }

            Node node = this.Select(this.root, rank);
            return node.Value;
        }

        private Node Select(Node node, int rank)
        {
            if (node is null)
            {
                throw new InvalidOperationException();
            }

            int leftNodes = this.Count(node.Left);

            if (leftNodes == rank)
            {
                return node;
            }
            else if (leftNodes > rank)
            {
                return Select(node.Left, rank);
            }
            else
            {
                return Select(node.Right, rank - (leftNodes + 1));
            }
        }

        public T Ceiling(T element)
        {
            throw new NotImplementedException();
        }

        public T Floor(T element)
        {
            //if (this.root is null)
            //{
            //    throw new InvalidOperationException();
            //}

            //this.Rank(element).Select()

            //this.root = this.Floor(this.root, element);

            throw new NotImplementedException();
        }

        private Node Floor(Node node, T element)
        {
            if (node.Left is null)
            {
                return node.Right;
            }

            if (node.Value.CompareTo(element) == 0)
            {
                
            }

            node.Left = this.Floor(node.Left, element);

            return node;
        }

        public IEnumerable<T> Range(T startRange, T endRange)
        {
            var list = new List<T>();

            if (this.root.Value.CompareTo(startRange) > 0)
            {
                //go from left to right
                this.Range(startRange, endRange, list, this.root);
            }
            else
            {
                this.Range(startRange, endRange, list, this.root);
                //go from right to left
            }

            return list;
        }

        //In-Order Traversal
        private void Range(T startRange, T endRange, List<T> list, Node node)
        {
            if (node.Left is not null)
            {
                this.Range(startRange, endRange, list, node.Left);
            }

            if (node.Value.CompareTo(startRange) >= 0 && endRange.CompareTo(node.Value) >= 0)
            {
                list.Add(node.Value);
            }

            if (node.Right is not null)
            {
                this.Range(startRange, endRange, list, node.Right);
            }
        }

        private void Rank(Node node, T element, ref int count)
        {
            if (node.Left is not null)
            {
                this.Rank(node.Left, element, ref count);
            }

            if (node.Right is not null)
            {
                this.Rank(node.Right, element, ref count);
            }

            if (node.Value.CompareTo(element) < 0)
            {
                count++;
            }
        }

        private void Count(Node node, ref int count)
        {
            if (node.Left is not null)
            {
                this.Count(node.Left, ref count);
            }

            if (node.Right is not null)
            {
                this.Count(node.Right, ref count);
            }

            count++;
        }

        private int Count(Node node)
        {
            if (node is null)
            {
                return 0;
            }

            return 1 + this.Count(node.Left) + this.Count(node.Right);
        }

        private Node DeleteMax(Node node)
        {
            if (node.Right == null)
            {
                return node.Left;
            }

            node.Right = this.DeleteMax(node.Right);

            return node;
        }

        private Node DeleteMin(Node node)
        {
            //here is the bottom of our recursion
            if (node.Left is null)
            {
                //if there is right node we will set node.left to node.right
                // if there isn't node.right , than we will set node.left to null
                return node.Right;
            }

            node.Left = this.DeleteMin(node.Left);

            return node;
        }

        private Node FindElement(T element)
        {
            Node current = this.root;

            while (current != null)
            {
                if (current.Value.CompareTo(element) > 0)
                {
                    current = current.Left;
                }
                else if (current.Value.CompareTo(element) < 0)
                {
                    current = current.Right;
                }
                else
                {
                    break;
                }
            }

            return current;
        }

        private void PreOrderCopy(Node node)
        {
            if (node == null)
            {
                return;
            }

            this.Insert(node.Value);
            this.PreOrderCopy(node.Left);
            this.PreOrderCopy(node.Right);
        }

        private Node Insert(T element, Node node)
        {
            if (node == null)
            {
                node = new Node(element);
            }
            else if (element.CompareTo(node.Value) < 0)
            {
                node.Left = this.Insert(element, node.Left);
            }
            else if (element.CompareTo(node.Value) > 0)
            {
                node.Right = this.Insert(element, node.Right);
            }

            return node;
        }

        private void EachInOrder(Node node, Action<T> action)
        {
            if (node == null)
            {
                return;
            }

            this.EachInOrder(node.Left, action);
            action(node.Value);
            this.EachInOrder(node.Right, action);
        }
    }
}
