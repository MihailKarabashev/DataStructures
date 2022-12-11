using Tree;

namespace TrainingTree;

public class IntegerTree : Tree<int>, IIntegerTree
{
    public IntegerTree(int key)
        : base(key)
    {
    }

    public IntegerTree(int key, params Tree<int>[] children)
        : base(key, children)
    {
    }

    public IEnumerable<IEnumerable<int>> GetPathsWithGivenSum(int sum)
    {
        var listOfLists = new List<Stack<int>>();

        base.GetPathsWithDfs(this, listOfLists);

        var paths = listOfLists.Where(x => x.Sum(n => n) == sum).ToList();

        return paths;
    }

    public IEnumerable<Tree<int>> GetSubtreesWithGivenSum(int sum)
    {
        var list = new List<Tree<int>>();
        //var listOfStacks = new List<Stack<Tree<int>>>();
        GetSubtreesWithGivenSumDfs(this, list, sum);
        return list;
    }

    //250 кинта вкарани още
    private void GetSubtreesWithGivenSumDfs(Tree<int> tree, List<Tree<int>> list, int sum)
    {
        foreach (var child in tree.Children)
        {
            if (tree.Parent == null) list.Clear();
           
            list.Add(child);

            if (list.Sum(x => x.Key) == sum) return;

            GetSubtreesWithGivenSumDfs(child, list, sum);

            if (list.Sum(x => x.Key) == sum) return;
        }
    }
}
