using System.Collections;

namespace MyList;

public class AbstractList<T> : IAbstractList<T>
{
    private const int DEFAULT_CAPACITY = 4;
    private T[] _items;

    public AbstractList()
        : this(DEFAULT_CAPACITY)
    {
    }

    public AbstractList(int capacity)
    {
        if (capacity < 0) throw new ArgumentOutOfRangeException(nameof(capacity));
        _items = new T[capacity];
    }

    public T this[int index]
    {
        get
        {
            ValidateIndex(index);
            return _items[index];
        }
        set
        {
            ValidateIndex(index);
            _items[index] = value;
        }
    }

    public int Count { get; private set; }

    public void Add(T item)
    {
        Grow();

        _items[Count] = item;
        Count++;
    }

    public int IndexOf(T item)
    {
        if (item == null) throw new ArgumentNullException(nameof(item));

        for (int i = 0; i < Count; i++)
        {
            if (_items[i].Equals(item)) return i;
        }

        return -1;
    }

    public bool Contains(T item)
    {
        return IndexOf(item) == -1 ? false : true;
    }

    public void Insert(int index, T item)
    {
        if (index < 0 || index > Count) throw new ArgumentOutOfRangeException(nameof(index));
        Grow();

        for (int i = Count; i < index; i--)
        {
            _items[i] = _items[i - 1];
        }

        _items[index] = item;
        Count++;
    }

    public bool Remove(T item)
    {
        var index = IndexOf(item);
        if (index == -1) return false;

        RemoveAt(index);
        return true;
    }

    public void RemoveAt(int index)
    {
        ValidateIndex(index);

        for (int i = index; i < Count - 1; i++)
        {
            _items[i] = _items[i + 1];
        }

        _items[Count] = default(T);
        Count--;
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < Count; i++)
        {
            yield return _items[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    private void ValidateIndex(int index)
    {
        if (index < 0 || index >= Count) throw new ArgumentOutOfRangeException(nameof(index));
    }

    private void Grow()
    {
        if (_items.Length == Count)
        {
            var coppyArray = new T[_items.Length * 2];
            Array.Copy(_items, coppyArray, _items.Length);
            _items = coppyArray;
        }
    }
}
