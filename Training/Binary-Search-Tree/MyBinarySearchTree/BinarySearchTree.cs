namespace MyBinarySearchTree;

public class BinarySearchTree<T> : IBinarySerchTree<T> where T : IComparable
{
    private class Node
    {
        public Node(T value)
        {
            Value = value;
        }

        public T Value { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }
    }

    private Node _root;

    public void EachInOrder(Action<T> action)
    {
        EachInOrderDfs(_root, action);
    }

    public void Insert(T item)
    {
        if (_root == null)
        {
            _root = new Node(item);
            return;
        }

        InsertPreOrder(_root,item);
    }

    private void InsertPreOrder(Node node, T item)
    {
        if (node.Left == null && node.Value.CompareTo(item) > 0) node.Left = new Node(item);

        if(node.Right == null && node.Value.CompareTo(item) < 0) node.Right = new Node(item);
        
        if (node.Value.CompareTo(item) > 0) InsertPreOrder(node.Left, item);

        if (node.Value.CompareTo(item) < 0) InsertPreOrder(node.Right, item);

    }

    private void EachInOrderDfs(Node node, Action<T> action)
    {
        if (node == null) return;

        action.Invoke(node.Value);

        EachInOrderDfs(node.Left, action);

        EachInOrderDfs(node.Right, action);
    }
}
