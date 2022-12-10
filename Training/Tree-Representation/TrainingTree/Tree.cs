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
            var stack = new Stack<T>();
            var queue = new Queue<Tree<T>>();
            queue.Enqueue(this);


            while (queue.Count > 0)
            {
                var currentTree = queue.Dequeue();

                if (currentTree.Parent is not null && currentTree.Children.Count > 0)
                {
                    stack.Push(currentTree.Key);
                }

                foreach (var child in currentTree.Children)
                {
                    queue.Enqueue(child);
                }
            }

            return stack;
        }

        public IEnumerable<T> GetLeafKeys()
        {
            var list = new List<T>();
            GetLeafKeysWithDfs(this, list);
            return list;
        }

        public T GetDeepestKey()
        {
            int currentDepth = 0;
            int depth = 0;
            T key = default;
            
            DeepestNodeWithDfs(this, ref key, ref currentDepth, ref depth);
            return key;
        }
     
        public IEnumerable<T> GetLongestPath()
        {
            var stack = new Stack<T>();
            var listOfLists = new List<List<T>>();

            GetLongestPathWithDfs(this, stack, listOfLists);
            
            var longestPath = listOfLists.
                OrderByDescending(x=> x.Count).ToList();

            return longestPath[0];
        }

        private void GetLongestPathWithDfs(Tree<T> tree, Stack<T> stack, List<List<T>> listOfLists)
        {
            foreach (var child in tree.Children)
            {
                GetLongestPathWithDfs(child, stack, listOfLists);
            }

            while (tree.Parent != null)
            {
                stack.Push(tree.Key);
                tree = tree.Parent;
            }

            stack.Push(tree.Key);
            listOfLists.Add(stack.ToList());
            stack.Clear();
        }

        private void DeepestNodeWithDfs(Tree<T> tree, ref T key, ref int currentDepth, ref int depth)
        {

            foreach (var child in tree.Children)
            {
                currentDepth++;
                DeepestNodeWithDfs(child,ref key, ref currentDepth, ref depth);
            }

            if (currentDepth > depth)
            {
                key = tree.Key;
                depth = currentDepth;
            }

            currentDepth--;
        }

        private void GetLeafKeysWithDfs(Tree<T> tree, List<T> list)
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
            sb.AppendLine(new string(' ', counter) + tree.Key.ToString());

            foreach (var child in tree.Children)
            {
                counter += 2;
                AsStringWithDfs(child, sb, ref counter);
            }

            counter -= 2;
        }
    }
}
