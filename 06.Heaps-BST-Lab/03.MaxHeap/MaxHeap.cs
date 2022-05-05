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
            if (this.Size == 0)
            {
                throw new InvalidOperationException();
            }

            var maxElement = this.elements[0];

            this.Swap(0, this.Size - 1);
            this.elements.RemoveAt(this.Size - 1);

            this.HeapifyDown(0);

            return maxElement;
        }

        //index at the begining is always 0
        private void HeapifyDown(int index)
        {
            //get bigger child index of index  
            var biggerChildIndex = this.GetBiggerChildIndex(index);

            //while index is bigger than array and if child index value is bigger than the index value
            while (this.ValidateIndex(index)  && this.ValidateIndex(biggerChildIndex)
                && this.elements[biggerChildIndex].CompareTo(this.elements[index]) > 0)

            {
                // swap child index value with index value
                this.Swap(biggerChildIndex, index);
                // set index possition to be at possition of bigger child index
                index = biggerChildIndex;
                //find new bigger child index of the new index postion (if there is )
                biggerChildIndex = this.GetBiggerChildIndex(index);
            }
        }

        private int GetBiggerChildIndex(int index)
        {
            var leftIndex = 2 * index + 1;
            var rightIndex = 2 * index + 2;

            if (this.ValidateIndex(leftIndex) && this.ValidateIndex(rightIndex))
            {
                if (this.elements[leftIndex].CompareTo(this.elements[rightIndex]) > 0)
                {
                    return leftIndex;
                }

                return rightIndex;
            }
            else if (this.ValidateIndex(leftIndex) && !this.ValidateIndex(rightIndex))
            {
                return leftIndex;
            }
            else if (this.ValidateIndex(rightIndex) && !this.ValidateIndex(leftIndex))
            {
                return rightIndex;
            }
            else
            {   
                return -1;
            }
        }

        private bool ValidateIndex(int index) => index >= 0 && index < this.Size;

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
 
                              //17         //6
        private void Swap(int index, int parentIndex)
        {
            var curr = this.elements[index]; // 17
            this.elements[index] = this.elements[parentIndex]; //6
            this.elements[parentIndex] = curr; // 17
        }
    }
}
