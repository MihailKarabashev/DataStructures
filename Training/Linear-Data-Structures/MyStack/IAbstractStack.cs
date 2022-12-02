namespace MyStack;

public interface IAbstractStack<T> : IEnumerable<T>
{
    T Peek();

    T Pop();

    void Push(T item);

    bool Contains(T item);
}
