using System.Text;

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

    public string AsIndentedPreOrder(int indent)
    {
        var sb = new StringBuilder();
        SetIndentationWithPreOrder(this, sb, indent);
        return sb.ToString();
    }

    public void ForEachInOrder(Action<T> action)
    {
        if (this.Left != null) this.Left.ForEachInOrder(action);

        action.Invoke(this.Value);

        if (this.Right != null) this.Right.ForEachInOrder(action);
    }

    //Left Root Right
    public IEnumerable<IAbstractBinaryTree<T>> InOrder()
    {
        var list = new List<IAbstractBinaryTree<T>>();

        if (this.Left != null) list.AddRange(this.Left.InOrder());

        list.Add(this);

        if(this.Right != null) list.AddRange(this.Right.InOrder());

        return list;
    }

    //Left Right Root
    public IEnumerable<IAbstractBinaryTree<T>> PostOrder()
    {
        var list = new List<IAbstractBinaryTree<T>>();

        if (this.Left != null) list.AddRange(this.Left.PostOrder());

        if (this.Right != null) list.AddRange(this.Right.PostOrder());

        list.Add(this);

        return list;
    }

    //Root Left Right
    // 7 4 2 1 3 5 6 
    public IEnumerable<IAbstractBinaryTree<T>> PreOrder()
    {
        var list = new List<IAbstractBinaryTree<T>>();
        list.Add(this);

        if (this.Left != null) list.AddRange(this.Left.PreOrder());

        if (this.Right != null) list.AddRange(this.Right.PreOrder());

        return list;
    }

    private void SetIndentationWithPreOrder(IAbstractBinaryTree<T> tree, StringBuilder sb, int indent)
    {
        sb.AppendLine(new string(' ', indent) + tree.Value.ToString());

        indent = tree.Left == null && tree.Right == null ? indent -= 2 : indent += 2;

        if (tree.Left != null) SetIndentationWithPreOrder(tree.Left, sb, indent);

        if (tree.Right != null) SetIndentationWithPreOrder(tree.Right, sb, indent);
    }
}
