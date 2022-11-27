/* Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
Например, даны 2 матрицы:
2 4 | 3 4
3 2 | 3 3
Результирующая матрица будет:
18 20
15 18
 */

Console.Write("Колличество строк 1-й матрицы: ");
int rowFirst = Convert.ToInt32(Console.ReadLine());
Console.Write("Колличество столбцов 1-й матрицы: ");
int columnFirst = Convert.ToInt32(Console.ReadLine());
Console.Write("Колличество строк 2-й матрицы: ");
int rowSecond = Convert.ToInt32(Console.ReadLine());
Console.Write("Колличество столбцов 2-й матрицы: ");
int columnSecond = Convert.ToInt32(Console.ReadLine());
Console.WriteLine();
int[,] arrayFirst = GetArray(rowFirst, columnFirst);
Console.WriteLine("1-й Массив:");
Console.WriteLine();
PrintArray(arrayFirst);
Console.WriteLine();
Console.WriteLine("\t X \t");
Console.WriteLine();
Console.WriteLine("2-й Массив:");
Console.WriteLine();
int[,] arraySecond = GetArray(rowSecond, columnSecond);
PrintArray(arraySecond);
Console.WriteLine();
Console.Write("\t = \t");
Console.WriteLine();
Console.WriteLine();
int[,] arrayResult = FirstArrayOnSecondArray(arrayFirst, arraySecond);
PrintArray(arrayResult);


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

int[,] FirstArrayOnSecondArray(int[,] ArrayFirst, int[,] ArraySecond)
{
    int[,] result = new int[ArraySecond.GetLength(0), ArraySecond.GetLength(1)];
    if (ArrayFirst.GetLength(1) != ArraySecond.GetLength(0))
    {
        Console.WriteLine("Число столбцов первой матрицы должно совпадать с числом строк второй матрицы");
    }
    else
    {
        for (int i = 0; i < ArrayFirst.GetLength(0); i++)
        {
            for (int j = 0; j < ArraySecond.GetLength(1); j++)
            {

                for (int k = 0; k < ArrayFirst.GetLength(1); k++)
                {
                    result[i, j] += ArrayFirst[i, k] * ArraySecond[k, j];
                }
            }
        }
    }
    return result;
}
