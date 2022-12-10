namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Metrics;
    using System.Reflection;
    using System.Text;

    public class Tree<T> : IAbstractTree<T>
    {
        private List<Tree<T>> _children;

        public Tree(T key)
        {
            Key = key;
            _children = new List<Tree<T>>();
        }

        public Tree(T key, params Tree<T>[] children)
            : this(key)
        {
            foreach (var child in children)
            {
                child.Parent = this;
                _children.Add(child);
            }
        }

        public T Key { get; private set; }

        public Tree<T> Parent { get; private set; }

        public IReadOnlyCollection<Tree<T>> Children => _children.AsReadOnly();

        public void AddChild(Tree<T> child)
        {
            throw new NotImplementedException();
        }

        public void AddParent(Tree<T> parent)
        {
            throw new NotImplementedException();
        }

        public string AsString()
        {
            var sb = new StringBuilder();
            int counter = 0;
            AsStringWithDfs(this, sb, ref counter);
            return sb.ToString();
        }

        public IEnumerable<T> GetInternalKeys()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetLeafKeys()
        {
            var list = new List<T>();
            GetLeafKeysWithDfs(this, list);
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

        private void GetLeafKeysWithDfs(Tree<T> tree ,List<T> list)
        {
            foreach (var child in tree.Children)
            {
                GetLeafKeysWithDfs(child, list);
            }

            if (tree.Children.Count == 0) list.Add(tree.Key);
        }

        private void AsStringWithDfs(Tree<T> tree, StringBuilder sb, ref int counter)
        {
            //   7
            // 19
            //1 12 31
            sb.AppendLine(new string(' ', counter) +  tree.Key.ToString()); 

            foreach (var child in tree.Children)
            {
                counter += 2;
                AsStringWithDfs(child,sb, ref counter);
            }

            counter-=2;
        }
    }
}
