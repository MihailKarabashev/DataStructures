namespace MyReversedList;

public interface IAbstractReversedList<T> : IEnumerable<T>
{
    void Add(T item);

    void RemoveAt(int index);

    void Insert(int index, T item);

    bool Contains(T item);

    bool Remove(T item);

    int IndexOf(T item);

    T this[int index] { get; set; }
}
