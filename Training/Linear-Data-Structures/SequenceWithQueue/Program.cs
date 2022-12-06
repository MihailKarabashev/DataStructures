var number = int.Parse(Console.ReadLine());

var queue = new Queue<int>();

queue.Enqueue(number);

int? itterationsCount = 0;
int numbersCount = 0;
int currentNumber = number;

//S1 = N = 2 

//S2 = S1 + 1  = 3 
//S3 = 2 * S1 + 1 = 5 
//S4 = S1 + 2 = 4 

//S5 = S2 + 1 = 4
//S6 = 2 * S2 + 1 = 7
//S7 = S2 + 2 = 5

//S8 = S3 + 1 = 6
//S9 = S3 * 2 + 1 = 11
//S10 = S3 + 2 = 7

// queue.Enqueue(2, 3 , 5 , 4) = queue.Count - i + numbersCount = 1
// queue.Enqueue(2, 3 , 5 , 4 ,   4, 7 ,5) = queue.Count - i numbersCount++ = 2
// queue.Enqueue(2, 3 , 5 , 4 ,   4, 7 ,5 ,   6, 11, 7) = queue.Count - i numbersCount+++ = 3

//queue.Count (4) - i(3) + sCounter(0) = 1


for (int i = 0; i < 50; i++)
{
    if (i % 3 == 0 && itterationsCount == null)
    {
        itterationsCount = SetNextMember(queue, ref numbersCount, ref currentNumber, i);
    }

    //if(itterationsCount < 2)
    //{
    //    itterationsCount == 0 ? queue.Enqueue(currentNumber + 1) : queue.Enqueue(2 * currentNumber + 1);
    //}
    if (itterationsCount == 0)
    {
        queue.Enqueue(currentNumber + 1);
        itterationsCount++;
    }
    else if (itterationsCount == 1)
    {
        queue.Enqueue(2 * currentNumber + 1);
        itterationsCount++;
    }
    else
    {
        queue.Enqueue(currentNumber + 2);
        itterationsCount = null;
    }

}


 int? SetNextMember(Queue<int> queue, ref int numbersCount, ref int currentNumber, int i)
{
    int? itterationsCount;
    foreach (var item in queue.Select((value, index) => (value, index)))
    {
        if (item.index == queue.Count - i + numbersCount)
        {
            currentNumber = item.value;
            break;
        }
    }

    numbersCount++;
    itterationsCount = 0;
    return itterationsCount;
}



foreach (var item in queue)
{
    Console.Write(item + "   ");
}


//for (int i = 0; i < 50; i++)
//{
//var elementAt = queue.ElementAt(elmentsCounter);

//    if (counter == 0)
//    {
//        queue.Enqueue(elementAt + 1);
//        counter++;
//    }
//    else if (counter == 1)
//    {
//        queue.Enqueue(2 * elementAt + 1);
//        counter++;
//    }
//    else
//    {
//        queue.Enqueue(elementAt + 2);
//        counter = 0;
//        elmentsCounter++;
//    }
//}
