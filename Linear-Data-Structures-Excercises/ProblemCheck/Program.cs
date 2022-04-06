

using Problem03.ReversedList;

var reversedList = new ReversedList<int>(1);

var numbers = new int[] { 3, 5, 7};


foreach (var num in numbers)
{
    reversedList.Add(num);
}

reversedList.Insert(2, 100);

foreach (var item in reversedList)
{
    Console.WriteLine(item);
}

//7 5 100 3