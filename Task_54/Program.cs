/* Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
В итоге получается вот такой массив:
7 4 2 1
9 5 3 2
8 4 4 2
 */


Console.Write("Колличество строк: ");
int row = Convert.ToInt32(Console.ReadLine());
Console.Write("Колличество столбцов: ");
int column = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Ваш массив:");
int[,] array = GetArray(row, column);
PrintArray(array);
array = MaxToMinArray(array);
Console.WriteLine();
Console.WriteLine("Отсортированный массив по строкам: от наибольшего к меньшему");
PrintArray(array);

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
    for (int i = 0; i < Array.GetLength(0); i++)
    {
        for (int j = 0; j < Array.GetLength(1); j++)
        {
            Console.Write($"{Array[i, j]} \t");
        }
        Console.WriteLine();
    }
}

int[,] MaxToMinArray(int[,] Array)
{
    int temp = 0; //Переменная, хранящая значение временного элемента, необходимого для перестановки
    for (int i = 0; i < Array.GetLength(0); i++)
    {
        for (int j = 0; j < Array.GetLength(1) - 1; j++) //j=1, т.к. в величину max уже записан элемент 0-ого столбца 
        {
            for (int t = j + 1; t < Array.GetLength(1); t++)
            {
                if (Array[i, t] > Array[i, j]) //Сравниваем правый элемент t-ый с левым j-м элементом. Если ДА, то меняем их местами
                {
                    temp = Array[i, j];
                    Array[i, j] = Array[i, t];
                    Array[i, t] = temp;
                }
            }
        }
    }
    return Array;
}
