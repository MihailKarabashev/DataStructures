

using Problem03.ReversedList;

var reversedList = new ReversedList<string>() { "Koce", "Misho", "Ivan"};


reversedList.Insert(2, "Gabo");


foreach (var item in reversedList)
{
    Console.WriteLine(item);
}

//0               //1          //2

//Grabo        //Ivan         //Iavn
//Ivan         //Gabo         //Misho
//Misho        //Misho        //Gabo
//Koce         //Koce         //Koce