namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
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

        public IEnumerable<T> GetInternalKeys() => this.BFSWithResultKeys(x => x.children.Count > 0);

        public IEnumerable<T> GetLeafKeys()  // =>this.BFSWithResultKeys(x=> x.children.Count == 0);
        {
            var list = new List<T>();

            this.GetLeafKeysWithDFS(this, list);

            return list;
        }

        public T GetDeepestKey()
        {
            var dict = new SortedDictionary<int, Tree<T>>();
            this.GetDeepestKeyWithDFS(this, dict, 0);

            var deepestKey = dict.Values.Last().Key;

            return deepestKey;
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

        private IEnumerable<T> BFSWithResultKeys(Predicate<Tree<T>> predicate)
        {
            var list = new List<T>();
            var queue = new Queue<Tree<T>>();

            queue.Enqueue(this);

            while (queue.Count > 0)
            {
                var subTree = queue.Dequeue();

                foreach (var child in subTree.children)
                {
                    if (predicate.Invoke(child))
                    {
                        list.Add(child.Key);
                    }

                    queue.Enqueue(child);
                }
            }

            return list;
        }

        private void GetDeepestKeyWithDFS(Tree<T> tree, IDictionary<int, Tree<T>> dict, int depthCount)
        {
            foreach (var child in tree.children)
            {
                this.GetDeepestKeyWithDFS(child, dict, depthCount + 1);
            }

            if (tree.children.Count == 0 && !dict.ContainsKey(depthCount))
            {
                dict.Add(depthCount, tree);
            }

        }
    }
}
