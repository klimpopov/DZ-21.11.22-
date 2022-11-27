/* 
Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.
Массив размером 2 x 2 x 2
66(0,0,0) 25(0,1,0)
34(1,0,0) 41(1,1,0)
27(0,0,1) 90(0,1,1)
26(1,0,1) 55(1,1,1) 

*/

Console.Write("Колличество строк: ");
int row = Convert.ToInt32(Console.ReadLine());
Console.Write("Колличество столбцов: ");
int column = Convert.ToInt32(Console.ReadLine());
Console.Write("Глубина массива: ");
int deep = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Ваш массив:");
int[,,] array = GetArray(row, column, deep);
PrintArray(array);


int[,,] GetArray(int row, int column, int deep)
{
    int[,,] array = new int[row, column, deep];
    for (int i = 0; i < row; i++)
    {
        for (int j = 0; j < column; j++)
        {
            for (int k = 0; k < deep; k++)
            {
                array[i, j, k] = new Random().Next(0, 100);
            }
        }
    }
    return array;
}

void PrintArray(int[,,] Array)
{
    for (int i = 0; i < Array.GetLength(0); i++)            //Печать элементов массива
    {
        for (int j = 0; j < Array.GetLength(1); j++)
        {
            for (int k = 0; k < Array.GetLength(2); k++)
            {
                
                Console.Write($"{Array[i, j, k]} ({i}, {j}, {k})  \t");            //Непосредственная печать соответствующего элемента массива 
            }
        }
        Console.WriteLine(" \t");
    }
}

