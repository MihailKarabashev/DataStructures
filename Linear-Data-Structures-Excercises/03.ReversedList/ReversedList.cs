namespace Problem03.ReversedList
{
    using System;
    using System.Linq;
    using System.Collections;
    using System.Collections.Generic;

    public class ReversedList<T> : IAbstractList<T>
    {
        private const int DefaultCapacity = 4;

        private T[] items;

        public ReversedList()
            : this(DefaultCapacity) { }

        public ReversedList(int capacity)
        {
            if (capacity < 0)
                throw new ArgumentOutOfRangeException(nameof(capacity));

            this.items = new T[capacity];
        }

        public T this[int index]
        {
            get
            {
                this.ValidateIndex(index);
                return this.items[this.Count - 1 - index];
            }
            set
            {
                this.ValidateIndex(index);
                this.items[index] = value;
            }
        }

        public int Count { get; private set; }

        public void Add(T item)
        {
            if (this.Count == this.items.Length)
            {
                this.Grow();
            }

            this.items[this.Count++] = item;
        }


        public bool Contains(T item)
        {
            var number = this.IndexOf(item);

            return number == -1 ? false : true;
        }

        public int IndexOf(T item)
        {
            for (int i = this.Count - 1; i >= 0; i--)
            {
                if (this.items[i].Equals(item))
                {
                    return this.Count - 1 - i;
                }
            }

            return -1;
        }

        public void Insert(int index, T item)
        {
            this.ValidateIndex(index);
            this.Grow();

            //Koce () Misho Ivan null
            

            for (int i = this.Count; i >= index; i--)
            {
                //null = Ivan
                this.items[i] = this.items[i -1];
            }

            this.items[index] = item;

            this.Count++;

        }

        public bool Remove(T item)
        {
            var index = this.IndexOf(item);

            if (index == -1)
            {
                return false;
            }

            this.RemoveAt(index);

            return true;
        }

        public void RemoveAt(int index)
        {
            this.ValidateIndex(index);

            var realIndexPosition = this.Count - 1 - index;

            for (int i = realIndexPosition; i <= this.Count - 1; i++)
            {
                this.items[i] = this.items[i + 1];
            }

            this.Count--;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.Count - 1; i >= 0; i--)
            {
                yield return this.items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        private void ValidateIndex(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new IndexOutOfRangeException();
            }
        }

        private void Grow()
        {
            var newArray = new T[this.items.Length * 2];
            Array.Copy(this.items, newArray, this.Count);
            this.items = newArray;
        }
    }
}