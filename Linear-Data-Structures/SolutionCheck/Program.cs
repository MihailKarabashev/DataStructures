using Problem01.List;

IAbstractList<string> list = new Problem01.List.List<string>();
list.Add("M");
list.Add("F");
list.Add("K");
list.Add("A");


list.RemoveAt(-1);

foreach (var item in list)
{
    Console.WriteLine(item);
}