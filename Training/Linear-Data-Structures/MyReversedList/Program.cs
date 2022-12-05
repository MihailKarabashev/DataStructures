using MyReversedList;

var reversedList = new AbstractReversedList<string>();

var list = new List<string>();

list.Add("Misho");
list.Add("Koci");  
list.Add("Neli"); 

reversedList.Add("Misho"); 
reversedList.Add("Koci"); 
reversedList.Add("Anton"); 
reversedList.Add("Neli"); 

reversedList.Insert(2, "Fantom"); // Neli {Anton} Koci Misho



foreach (var item in reversedList)
{
    Console.WriteLine(item);
}

