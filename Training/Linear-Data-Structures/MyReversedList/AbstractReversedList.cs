using System.Collections;

namespace MyReversedList;

public class AbstractReversedList<T> : IAbstractReversedList<T>
{
    private T[] _items;
    private const int DEFAULT_CAPACITY = 4;

    public AbstractReversedList()
        :this(DEFAULT_CAPACITY)
    {
    }

    public AbstractReversedList(int capacity)
    {
        if (capacity < 0) throw new ArgumentOutOfRangeException(nameof(capacity));
        _items = new T[capacity];
    }

    public int Count { get; private set; }

    public T this[int index]
    { 
        get 
        {
            ValidateIndex(index);
            return _items[Count-1-index];
        }
        set 
        {
            ValidateIndex(index);
            _items[index] = value;
        }
    }

    public void Add(T item)
    {
        Grow();
        _items[Count] = item;
        Count++;
    }

    public int IndexOf(T item)
    {
        for (int i = 0; i < Count; i++)
        {
            if (_items[Count - 1 - i].Equals(item)) return i;
        }

        return -1;
    }

    public bool Contains(T item)
    {
        return IndexOf(item) >= 0;
    }

    public void Insert(int index, T item)
    {
        ValidateIndex(index);
        Grow();

        for (int i = Count; i > Count - index; i--)
        {
            _items[i] = _items[i - 1];
        }

        _items[Count-index] = item;
        Count++;
    }

    public bool Remove(T item)
    {
        var index = IndexOf(item);

       if(index == -1) return false;

        RemoveAt(index);

        return true;
    }

    public void RemoveAt(int index)
    {
        ValidateIndex(index);

        for (int i = Count - 1 - index; i < Count-1; i++)
        {
            _items[i] = _items[i + 1];
        }

       _items[Count - 1] = default;
        Count--;
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = Count - 1; i >= 0; i--)
        {
            yield return _items[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    private void Grow()
    {
        if(_items.Length == Count)
        {
            var newArray = new T[DEFAULT_CAPACITY * 2];
            Array.Copy(_items, newArray, _items.Length);
            _items = newArray;
        }
    }

    private void ValidateIndex(int index)
    {
        if (index < 0 || index >= Count) throw new ArgumentOutOfRangeException(nameof(index));
    }

    //Neli Misho Koce
    //Koce Misho Neli
    // 3 - 1 - 2 = 0
    //
}
