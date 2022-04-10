namespace Tree
{
    using System.Collections.Generic;

    interface IAbstractTree<T>
    {
        IEnumerable<T> OrderBfs();

        IEnumerable<T> OrderDfs();

        IEnumerable<T> OrderDfsWithRecursion();

        void AddChild(T parentKey, Tree<T> child);

        void RemoveNode(T nodeKey);

        void Swap(T firstKey, T secondKey);
    }
}
