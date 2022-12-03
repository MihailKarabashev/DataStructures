namespace MyLinkedList;

public interface IAbstractLinkedList<T> : IEnumerable<T>
{
    void AddFirst(T item);

    void AddLast(T item);

    T RemoveFirst();

    T RemoveLast();

    T GetLast();

    T GetFirst();
}
