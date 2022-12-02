using MyList;

var list = new AbstractList<int>();

list.Add(10);
list.Add(20);
list.Insert(1, 50);

foreach (var item in list)
{
    Console.WriteLine(item);
}

list.RemoveAt(0);
Console.WriteLine(list[0]);

list.Remove(20);

Console.WriteLine(list.Contains(20));