namespace MyBinaryTree;

public class BinaryTree<T> : IAbstractBinaryTree<T>
{
    public BinaryTree(T element)
    {
        Value = element;
    }

    public BinaryTree(T element, IAbstractBinaryTree<T> left, IAbstractBinaryTree<T> right)
        : this(element)
    {
        Left = left;
        Right = right;
    }
    public T Value { get; private set; }

    public IAbstractBinaryTree<T> Right { get; private set; }

    public IAbstractBinaryTree<T> Left { get; private set; }


    public IEnumerable<IAbstractBinaryTree<T>> InOrder()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<IAbstractBinaryTree<T>> PostOrder()
    {
        throw new NotImplementedException();
    }

    //Root Left Right
    // 7 4 2 1 3
    public IEnumerable<IAbstractBinaryTree<T>> PreOrder()
    {
        var list = new List<IAbstractBinaryTree<T>>();
        list.Add(this);

        if (this.Left != null) list.AddRange(this.Left.PreOrder());

        if (this.Right != null) list.AddRange(this.Right.PreOrder());

        return list;
    }
}
