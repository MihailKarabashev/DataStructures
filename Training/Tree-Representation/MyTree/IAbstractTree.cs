namespace MyTree;

public interface IAbstractTree<T>
{
    IEnumerable<T> OrderBfs();

    IEnumerable<T> OrderDfs();
}
