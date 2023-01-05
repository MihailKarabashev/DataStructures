namespace MyBinarySearchTree;

public interface IBinarySerchTree<T> where T : IComparable<T>
{
    void EachInOrder(Action<T> action);

    void Insert(T item);

    bool Contains(T item);

    IBinarySerchTree<T> Search(T item);

    void DeleteMin();

    void DeleteMax();

    void Delete(T item);

    int Count();

    int Rank(T value);

    T Select(int number);

    T Floor(T value);

    T Ceiling(T value);

    IEnumerable<T> Range(T first, T secound);
}
