namespace MyBinaryTree;

public interface IAbstractBinaryTree<T>
{
    T Value { get; }

    IAbstractBinaryTree<T> Right { get;}

    IAbstractBinaryTree<T> Left { get;}

    IEnumerable<IAbstractBinaryTree<T>> PreOrder();

    IEnumerable<IAbstractBinaryTree<T>> InOrder();

    IEnumerable<IAbstractBinaryTree<T>> PostOrder();
}
