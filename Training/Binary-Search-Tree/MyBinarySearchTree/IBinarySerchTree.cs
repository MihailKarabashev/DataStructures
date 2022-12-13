namespace MyBinarySearchTree;

public interface IBinarySerchTree<T> where T : IComparable
{
    void EachInOrder(Action<T> action);

    void Insert(T item);
}
