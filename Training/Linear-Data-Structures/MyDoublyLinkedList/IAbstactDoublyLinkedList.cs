namespace MyDoublyLinkedList;

public interface IAbstactDoublyLinkedList<T> : IEnumerable<T>
{
    void AddFirst(T item);

    void AddLast(T item);

    T GetFirst();

    T GetLast();

    T RemoveFirst();

    T RemoveLast(); 
}
