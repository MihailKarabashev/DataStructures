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

    public int Counter { get; private set; }

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
        ValidateRoot();

        _root = DeleteMin(_root);
        Counter--;
    }

    public void DeleteMax()
    {
        ValidateRoot();

        _root = DeleteMax(_root);
        Counter--;
    }

    public void Delete(T item)
    {
        ValidateRoot();

        _root = Delete(_root, item);
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
        Counter++;
    }

    public T Select(int number)
    {
        return default;
    }

    public int Count() => Counter;

    public int Rank(T value)
    {
        int count = 0;

        return Rank(_root, value, count);
    }

    public IEnumerable<T> Range(T first , T secound)
    {
        var list = new List<T>();

        Range(_root, list, first, secound);

        return list;
    }

    public T Floor(T value)
    {
        ValidateRoot();
        var node = Floor(_root, value);
        return node.Value;
    }

    public T Ceiling(T value)
    {
        throw new NotImplementedException();
    }

    private void Range(Node node, List<T> list, T firstValue, T secoundValue)
    {
        if (node.Left != null) Range(node.Left, list, firstValue, secoundValue);

        if (node.Value.CompareTo(firstValue) >= 0 && node.Value.CompareTo(secoundValue) <= 0)
        {
            list.Add(node.Value);
        }

        if (node.Right != null) Range(node.Right, list, firstValue, secoundValue);

    }

    private Node Floor(Node node, T value)
    {
        var element = (decimal)Math.Floor(Convert.ToDecimal(node.Right.Value));

        if (node.Value.Equals(element))
        {
            return node;
        }

        if (node.Left != null) node = Floor(node.Left, value);
        if(node.Right != null) node = Floor(node.Right, value);

        return node;
    }

    private int Count(Node node, int count)
    {
        count++;

        if (node.Left != null) count = Count(node.Left, count);

        if (node.Right != null) count = Count(node.Right, count);

        return count;
    }

    private Node DeleteMax(Node node)
    {
        if (node.Right == null) return node.Left;

        node.Right = DeleteMax(node.Right);

        return node;
    }

    private Node DeleteMin(Node node)
    {
        if (node.Left == null) return node.Right;

        node.Left = DeleteMin(node.Left);

        return node;
    }

    private int Rank(Node node, T value, int count)
    {
        if (node.Value.CompareTo(value) < 0) count++;

        if (node.Left != null) count = Rank(node.Left, value, count);
        if (node.Right != null) count = Rank(node.Right, value, count);

        return count;
    }

    private Node Delete(Node node, T item)
    {
        if (node.Value.Equals(item))
        {
            Counter--;
            node = null;
            return node;
        }
        else if (node.Left != null) node.Left = Delete(node.Left, item);
        else if (node.Right != null) node.Right = Delete(node.Right, item);

        return node;
    }

    private void ValidateRoot()
    {
        if (_root == null) throw new InvalidOperationException();
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

        if (node.Value.CompareTo(item) > 0)
        {
            node.Left = Insert(node.Left, item);
        }
        else if (node.Value.CompareTo(item) < 0)
        {
            node.Right = Insert(node.Right, item);
        }

        return node;
    }

    private void InsertPreOrder(Node node, T item)
    {
        if (node.Left == null && node.Value.CompareTo(item) > 0) node.Left = new Node(item);

        if (node.Right == null && node.Value.CompareTo(item) < 0) node.Right = new Node(item);

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
