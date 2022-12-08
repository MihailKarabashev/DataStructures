namespace MyTree;

public interface IAbstractTree<T>
{
    IEnumerable<T> OrderBfs();
}
