using System.Xml.Linq;

namespace MyBinarySearchTree;

public class BinarySearchTree<T> : IBinarySerchTree<T> where T : IComparable<T>
{
    public BinarySearchTree()
    {
    }

    private BinarySearchTree(Node node)
    {
        PreOrderCopy(node);
    }

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

    public IBinarySerchTree<T> Search(T item)
    {
        var node = Search(_root, item);
        if (node == null) return null;
        var bst = new BinarySearchTree<T>(node);
        return bst;
    }

    public void DeleteMin()
    {
        if (_root == null) throw new InvalidOperationException();

        var node = _root;

        while (node.Left.Left != null)
        {
            node = node.Left;
        }

        node.Left = null;
    }

    public void DeleteMax()
    {
        var node = _root;

        while (node.Right.Right != null)
        {
            node = node.Right;
        }

        node.Right = null;
    }

    public bool Contains(T item)
    {
       return Search(item) != null ? true : false;
    }  

    public void Insert(T item)
    {
        //if (_root == null)
        //{
        //    _root = new Node(item);
        //    return;
        //}

        //InsertPreOrder(_root,item);

        _root = Insert(_root, item);
    }

    private void PreOrderCopy(Node node)
    {
        if (node == null) return;

        Insert(node.Value);
        PreOrderCopy(node.Left);
        PreOrderCopy(node.Right);
    }

    private Node Search(Node node, T item)
    {
         if (node == null) return null;

        if (node.Value.Equals(item)) return node;

        if (node.Value.CompareTo(item) > 0)
        {
            node = Search(node.Left, item);
        }
        else if (node.Value.CompareTo(item) < 0)
        {
            node = Search(node.Right, item);
        }

        return node;
    }

    private Node Insert(Node node, T item)
    {
        if (node == null)
             node = new Node(item);

        if(node.Value.CompareTo(item) > 0)
        {
            node.Left = Insert(node.Left, item);
        }
        else if(node.Value.CompareTo(item) < 0)
        {
            node.Right = Insert(node.Right, item);
        }

        return node;
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
