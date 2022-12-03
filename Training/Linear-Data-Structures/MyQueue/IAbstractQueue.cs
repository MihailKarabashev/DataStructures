namespace MyQueue;

public interface IAbstractQueue<T> : IEnumerable<T>
{
    void Enqueue(T item);

    bool Contains(T element);

    T Dequeue();

    T Peek();
}
