using Tree;

namespace TrainingTree;

public interface IIntegerTree : IAbstractTree<int>
{
    IEnumerable<IEnumerable<int>> GetPathsWithGivenSum(int sum);

    IEnumerable<Tree<int>> GetSubtreesWithGivenSum(int sum);
}
