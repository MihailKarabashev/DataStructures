﻿namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class IntegerTree : Tree<int>, IIntegerTree
    {
        public IntegerTree(int key, params Tree<int>[] children)
            : base(key, children)
        {
        }

        public IEnumerable<IEnumerable<int>> GetPathsWithGivenSum(int sum)
        {
            var leafs = this.GetLeafKeys(x => x.Children.Count == 0);

            var list = new List<List<int>>();
            int resultSum = default;

            foreach (var leaf in leafs)
            {
                var currentBestPath = this.SumCurrentBestPath(leaf);
                resultSum += currentBestPath.Sum();

                if (resultSum == sum)
                {
                    list.Add(currentBestPath.ToList());
                    currentBestPath.Clear();
                }

                resultSum = 0;
            }

            return list;
        }

        public IEnumerable<Tree<int>> GetSubtreesWithGivenSum(int sum)
        {
            throw new NotImplementedException();
        }

        private Stack<int> SumCurrentBestPath(Tree<int> leaf)
        {
            var stack = new Stack<int>();
            var currentLeaft = leaf;

            while (currentLeaft.Parent != null)
            {
                stack.Push(currentLeaft.Key);
                currentLeaft = currentLeaft.Parent;
            }

            stack.Push(currentLeaft.Key);

            return stack;
        }
    }
}
