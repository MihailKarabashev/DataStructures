var stack = new Stack<int>();


var number = 2;
var queue = new Queue<int>();
queue.Enqueue(number);


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

int counter = 0;
int elmentsCounter = 0;



for (int i = 0; i < 50; i++)
{
    if (counter == 0)
    {
        queue.Enqueue(number + 1);
        counter++;
    }
    else if (counter == 1)
    {
        queue.Enqueue(2 * number + 1);
        counter++;
    }
    else
    {
        queue.Enqueue(number + 2);
        counter = 0;
        elmentsCounter++;
    }
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


foreach (var item in queue)
{
    Console.Write(item + " ");
}

