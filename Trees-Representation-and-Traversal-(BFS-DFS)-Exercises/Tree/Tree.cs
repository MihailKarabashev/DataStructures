namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Tree<T> : IAbstractTree<T>
    {
        private List<Tree<T>> children;

        public Tree(T key, params Tree<T>[] children)
        {
            this.Key = key;
            this.children = new List<Tree<T>>();

            foreach (var child in children)
            {
                this.AddChild(child);
                child.Parent = this;
            }
        }

        public T Key { get; private set; }

        public Tree<T> Parent { get; private set; }

        public IReadOnlyCollection<Tree<T>> Children => this.children.AsReadOnly();

        public void AddChild(Tree<T> child)
        {
            this.children.Add(child);
        }

        public void AddParent(Tree<T> parent)
        {
           this.Parent = parent;
        }

        public string AsString()
        {
            var result = new StringBuilder();

            this.DfsAsString(result, this, 0);

            return result.ToString().TrimEnd();
        }

        public IEnumerable<T> GetInternalKeys()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetLeafKeys()  // =>this.GetLeafKeysWithBFS(this);
        {
            var list = new List<T>();

            this.GetLeafKeysWithDFS(this, list);

            return list;
        }

        public T GetDeepestKey()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetLongestPath()
        {
            throw new NotImplementedException();
        }

        private void DfsAsString(StringBuilder result, Tree<T> tree, int indent)
        {
            result
                .Append(' ', indent)
                .AppendLine(tree.Key.ToString());

            foreach (var child in tree.children)
            {
                this.DfsAsString(result, child, indent + 2);
            }
        }

        private void GetLeafKeysWithDFS(Tree<T> tree, ICollection<T> collection)
        {
            foreach (var child in tree.children)
            {
                this.GetLeafKeysWithDFS(child, collection);
            }

            if (tree.children.Count == 0)
            {
                collection.Add(tree.Key);
            }
        }

        private IEnumerable<T> GetLeafKeysWithBFS(Tree<T> tree)
        {
            var queue = new Queue<Tree<T>>();
            var list = new List<T>();

            queue.Enqueue(this);

            while (queue.Count > 0)
            {
                var subTree = queue.Dequeue();

                foreach (var child in subTree.children)
                {
                    if (child.children.Count == 0)
                    {
                        list.Add(child.Key);
                    }

                    queue.Enqueue(child);
                }
            }


            return list;
        }
    }
}
