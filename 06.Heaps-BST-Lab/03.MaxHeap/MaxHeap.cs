namespace _03.MaxHeap
{
    using System;
    using System.Collections.Generic;

    public class MaxHeap<T> : IAbstractHeap<T> where T : IComparable<T>
    {
        private List<T> elements;

        public MaxHeap()
        {
            this.elements = new List<T>();
        }

        public int Size => this.elements.Count;

        public void Add(T element)
        {
           this.elements.Add(element);
           this.HeapifyUp(this.elements.Count - 1);
        }

        public T ExtractMax()
        {
            throw new NotImplementedException();
        }

        public T Peek()
        {
            if (this.Size == 0)
            {
                throw new InvalidOperationException();
            }

            return this.elements[0];
        }

        private void HeapifyUp(int index)
        {
            var parentIndex = (index - 1) / 2;

            while (this.elements[index].CompareTo(this.elements[parentIndex]) > 0 && index > 0)
            {
                //swap values inside the array
                this.Swap(index, parentIndex);

                //set index to parentIndex cuz there you will find your  value
                index = parentIndex;

                //find the parent of the swapped index again
                parentIndex = (index - 1) / 2;
            }
        }

        private void Swap(int index, int parentIndex)
        {
            var curr = this.elements[index];
            this.elements[index] = this.elements[parentIndex];
            this.elements[parentIndex] = curr;
        }
    }
}
