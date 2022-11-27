/* Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.

Например, задан массив:

1 4 7 2

5 9 2 3

8 4 2 4

5 2 6 7

Программа считает сумму элементов в каждой строке и выдаёт номер строки с наименьшей суммой элементов: 1 строка
 */

Console.Write("Колличество строк: ");
int row = Convert.ToInt32(Console.ReadLine());
Console.Write("Колличество столбцов: ");
int column = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Ваш массив:");
int[,] array = GetArray(row, column);
PrintArray(array);
Console.WriteLine();
Console.Write($"Строки с наименьшей суммой: {MinSumStringIn(array)}");


int[,] GetArray(int row, int column)
{
    int[,] array = new int[row, column];
    for (int i = 0; i < row; i++)
    {
        for (int j = 0; j < column; j++)
        {
            array[i, j] = new Random().Next(0, 100);
        }
    }
    return array;
}

void PrintArray(int[,] Array)
{
    int shiftRow = 1;
    int shiftColumn = 1;

    Console.Write(" \t");                                   //Сдвиг индексов колон массива вправо 
    for (int k = 0; k < Array.GetLength(1); k++)            //Печать индексов колон массива сверху
    {
        Console.Write($"({shiftColumn}) \t");
        shiftColumn++;
    }
    Console.WriteLine();                                    //Пропуск строки для визуального отделения индексов колон массива от значений массива.
    Console.WriteLine();                                    //Перенос последующих элементов строки массива на следующую строку
    for (int i = 0; i < Array.GetLength(0); i++)            //Печать элементов массива
    {
        for (int j = 0; j < Array.GetLength(1); j++)
        {
            if (j == 0)                                     //Печать индексы колон массива слевой стороны
            {
                Console.Write($"|{shiftRow}| \t");
                shiftRow++;
            }
            Console.Write($"{Array[i, j]}  \t");            //Непосредственная печать соответствующего элемента массива 
        }
        Console.WriteLine();
    }
}

string MinSumStringIn(int[,] Array)
{
    int[] arraySum = new int[Array.GetLength(0)];
    int sum = 0;
    for (int i = 0; i < Array.GetLength(0); i++)
    {
        for (int j = 0; j < Array.GetLength(1); j++)
        {
            sum += Array[i, j];
        }
        arraySum[i] = sum;
        sum = 0;
    }
    int minSum = arraySum[0];
    int rowMin = 0;
    string positions = "";
    for (int i = 1; i < arraySum.Length; i++)
    {

        if (arraySum[i] < minSum)
        {
            minSum = arraySum[i]; //Нашли минимальное значение
            rowMin = i;           //Нашли строку, в которой это значение лежит
        }
    }
        for (int j = 0; j < arraySum.Length; j++)
        {
            if (minSum == arraySum[j]) //Минимальное значение может лежать в нескольких строках
                {
                    positions += $"{j+1} ";
                }
        }
    
    return positions;
}
