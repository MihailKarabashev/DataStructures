namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Tree<T> : IAbstractTree<T>
    {
        private T value;
        private Tree<T> parent;
        private List<Tree<T>> children;

        public Tree()
        {
            this.children = new List<Tree<T>>();
        }

        public Tree(T value)
        {
            this.value = value;
            this.children = new List<Tree<T>>();
        }

        public Tree(T value, params Tree<T>[] children)
            : this(value)
        {
            foreach (var child in children)
            {
                child.parent = this;
                this.children.Add(child);
            }
        }

        public void AddChild(T parentKey, Tree<T> child)
        {
            var parent = this.FindNodeWithBfs(this,parentKey);
            //var parent = this.FindChildDFS(this, parentKey);
            parent.children.Add(child);
            child.parent = parent;
        }

        public IEnumerable<T> OrderBfs()
        {
            var queue = new Queue<Tree<T>>();
            var list = new List<T>();

            queue.Enqueue(this);

            while (queue.Count > 0)
            {
                var subTree = queue.Dequeue();

                foreach (var child in subTree.children)
                {
                    queue.Enqueue(child);
                }

                list.Add(subTree.value);
            }

            return list;
        }

        public IEnumerable<T> OrderDfs()
        {
            var result = new Stack<T>();

            var stack = new Stack<Tree<T>>();
            stack.Push(this);


            while (stack.Count > 0)
            {
                var nodeTree = stack.Pop();

                foreach (var child in nodeTree.children)
                {
                    stack.Push(child);
                }

                result.Push(nodeTree.value);
            }

            return result;
        }

        public IEnumerable<T> OrderDfsWithRecursion()
        {
            var list = new List<T>();

            this.RecursiveDFS(this,list);

            return list;
        }

        public void RemoveNode(T nodeKey)
        {
            var nodeForDeletion = this.FindNodeWithBfs(this,nodeKey);
            var parentNode = nodeForDeletion.parent;

            if (nodeForDeletion.parent is null)
            {
                throw new ArgumentException();
            }

            parentNode.children.Remove(nodeForDeletion);
        }

        public void Swap(T firstKey, T secondKey)
        {
            var firstNode = this.FindNodeWithBfs(this, firstKey);
            var secoundNode = this.FindNodeWithBfs(this, secondKey);

            if (firstNode.parent is  null || secoundNode.parent is null)
            {
                throw new ArgumentException();
            }

            if (firstNode.children.Any(x => x.value.Equals(secoundNode.value))
                && secoundNode.parent.value.Equals(firstNode.value))
            {
                firstNode.value = secoundNode.value;

                if (firstNode.children.Count > 0)
                {
                    firstNode.children.RemoveAll(x => x.value != null);
                }
            }
            else
            {
               var indexOfFirstChild = firstNode.parent.children.IndexOf(firstNode);
               var indexOfSecoundChild = secoundNode.parent.children.IndexOf(secoundNode);

               firstNode.parent.children[indexOfFirstChild] = secoundNode;
               secoundNode.parent.children[indexOfSecoundChild] = firstNode;
            }

        }

        private void RecursiveDFS(Tree<T> node , ICollection<T> collection)
        {
            foreach (var child in node.children)
            {
                this.RecursiveDFS(child, collection);
            }

            collection.Add(node.value);
        }

        private Tree<T> FindNodeWithBfs(Tree<T> root, T searchedValue)
        {
            var queue = new Queue<Tree<T>>();

            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                if (node.value.Equals(searchedValue))
                {
                    return node;
                }

                foreach (var child in node.children)
                {
                    queue.Enqueue(child);
                }
            }

            throw new ArgumentNullException("Parent Key Not Found");
        }

        private Tree<T> FindNodeWithDfs(Tree<T> root, T searchedValue)
        {
            if (root.value.Equals(searchedValue))
            {
                return root;
            }

            foreach (var child in root.children)
            {
                if (child.value.Equals(searchedValue))
                {
                    return child;
                }

                this.FindNodeWithDfs(root,searchedValue);
            }

            throw new ArgumentNullException("Parent Key Not Found");
        }

      
    }
}
