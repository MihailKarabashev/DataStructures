namespace MyBinarySearchTree;

public interface IBinarySerchTree<T> where T : IComparable<T>
{
    void EachInOrder(Action<T> action);

    void Insert(T item);

    bool Contains(T item);

    IBinarySerchTree<T> Search(T item);

    void DeleteMin();

    void DeleteMax();
}
