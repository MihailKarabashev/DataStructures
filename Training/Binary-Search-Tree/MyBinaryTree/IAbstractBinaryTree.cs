namespace MyBinaryTree;

public interface IAbstractBinaryTree<T>
{
    T Value { get; }

    IAbstractBinaryTree<T> Right { get;}

    IAbstractBinaryTree<T> Left { get;}

    void ForEachInOrder(Action<T> action);

    string AsIndentedPreOrder(int indent);

    IEnumerable<IAbstractBinaryTree<T>> PreOrder();

    IEnumerable<IAbstractBinaryTree<T>> InOrder();

    IEnumerable<IAbstractBinaryTree<T>> PostOrder();
}
