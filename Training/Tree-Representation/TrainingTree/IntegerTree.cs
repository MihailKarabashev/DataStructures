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
        var stack = new Stack<int>();
        var listOfLists = new List<List<int>>();

        base.GetPathsWithDfs(this, stack, listOfLists);
        var paths = listOfLists.Where(x => x.Sum(n => n) == sum).ToList();

        return paths;
    }

    public IEnumerable<Tree<int>> GetSubtreesWithGivenSum(int sum)
    {
        throw new NotImplementedException();
    }
}
