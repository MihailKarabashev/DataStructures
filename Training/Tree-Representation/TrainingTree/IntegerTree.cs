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

        throw new NotImplementedException();
        //var stack = new Stack<int>();
        //var listOfLists = new List<List<int>>();

        //base.GetPathsWithDfs(this, stack, listOfLists);

        //var subTree = listOfLists.Where(x => x.Sum(n => n) == sum).ToList();
        //var leftMostSubTree = subTree[0].Select(x => new Tree<int>(x)).ToList();

        //return leftMostSubTree;
    }
}
