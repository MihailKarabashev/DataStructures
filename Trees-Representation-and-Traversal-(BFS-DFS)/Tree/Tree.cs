namespace Tree
{
    using System;
    using System.Collections.Generic;

    public class Tree<T> : IAbstractTree<T>
    {
        private T value;
        private Tree<T> parent;
        private List<Tree<T>> children;

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
            throw new NotImplementedException();
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

            this.Dfs(this,list);

            return list;
        }

        public void RemoveNode(T nodeKey)
        {
            throw new NotImplementedException();
        }

        public void Swap(T firstKey, T secondKey)
        {
            throw new NotImplementedException();
        }

        private void Dfs(Tree<T> node , ICollection<T> collection)
        {
            foreach (var child in node.children)
            {
                this.Dfs(child, collection);
            }

            collection.Add(node.value);
        }
    }
}
