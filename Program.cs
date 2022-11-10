Console.WriteLine("=========== Задача 54 =============");

// Задача 54: Задайте двумерный массив. Напишите программу,
//которая упорядочит по убыванию элементы каждой строки двумерного массива.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// В итоге получается вот такой массив:
// 7 4 2 1
// 9 5 3 2
// 8 4 4 2

int[,] squareArray  = GetArray(5, 5, 0, 9);
Console.WriteLine("Сгенерированный массив");
PrintArray(squareArray);

LetsSort(squareArray);

Console.WriteLine("Отсортированный массив");
PrintArray(squareArray);

// метод сортировки
void LetsSort(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            for (int z = 0; z < array.GetLength(1) - 1; z++)
            {
                 if (array[i,z] < array[i,z+1])
                 {
                    int tmp = array[i,z];
                     array[i,z] = array[i,z+1];
                     array[i,z+1] = tmp;
                 }
            }
        }
    }
}


Console.WriteLine("=========== Задача 56 =============");
// Задача 56: Задайте прямоугольный двумерный массив.
//Напишите программу, которая будет находить строку с наименьшей суммой элементов.

// Например, задан массив:

// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// 5 2 6 7
// Программа считает сумму элементов в каждой строке и выдаёт номер строки с наименьшей суммой элементов: 1 строка


int[,] rectangularArray  = GetArray(4, 3, 0, 9);
Console.WriteLine("Сгенерированный массив");
PrintArray(rectangularArray);
Console.WriteLine($"номер строки с наименьшей суммой значений в ней => {smallestRow(rectangularArray)}");

int smallestRow(int[,] array)
{
    int[] sums = new int[array.GetLength(0)];
    for (int i = 0; i < array.GetLength(0); i++)
    {
        int sum = 0;
        for (int j = 0; j < array.GetLength(1); j++)
        {
            sum += array[i,j];
        }
        sums[i] = sum;
        //проверка
        //Console.WriteLine($"сумма строки {i} => {sum}");
    }

    //проверка
    //Console.WriteLine($"массив => [{String.Join(",", sums)}]");

    int minIndex = 0;
    int min = sums[0];
    for (int i = 0; i < sums.Length; i++)
    {
        if (sums[i] < min)
        {
            min = sums[i];
            minIndex = i;
        }
    }
    int smallestRowNumber = minIndex + 1;
    return smallestRowNumber;
}

Console.WriteLine("=========== Задача 58 =============");
// Задача 58: Задайте две квадратные матрицы. Напишите программу, которая будет находить произведение двух матриц.
// Например, даны 2 матрицы:
// 2 4 | 3 4
// 3 2 | 3 3
// Результирующая матрица будет:
// 18 20
// 15 18

int[,] firstMartrix  = GetArray(2, 2, 0, 9);
int[,] secomdMartrix  = GetArray(2, 2, 0, 9);
Console.WriteLine("првая матрица:");
PrintArray(firstMartrix);
Console.WriteLine("вторая матрица:");
PrintArray(secomdMartrix);

Console.WriteLine("результат перемножения матриц:");
PrintArray(LetsMultiplyMatrix(firstMartrix, secomdMartrix));



int[,] LetsMultiplyMatrix(int[,] firstMultipliedMartrix,
                        int[,] secomdMultipliedMartrix)

{
    int[,] resultMatrix = new int[firstMultipliedMartrix.GetLength(0), secomdMultipliedMartrix.GetLength(1)];
    for (int i = 0; i < resultMatrix.GetLength(0); i++)
    {
        for (int j = 0; j < resultMatrix.GetLength(1); j++)
        {
            int sum = 0;
            for (int z = 0; z < firstMultipliedMartrix.GetLength(1); z++)
            {
                sum += firstMultipliedMartrix[i, z] * secomdMultipliedMartrix[z, j];
            }
            resultMatrix[i, j] = sum;
        }
    }

    return resultMatrix;
}

Console.WriteLine("Рекомендовано решить(задача с семинара)");
// Рекомендовано решить(задача с семинара)
// Отсортировать нечетные столбцы(смотрите по индексам) массива по возрастанию.
// Вывести массив изначальный и массив с отсортированными нечетными столбцами


int[,] Array  = GetArray(4, 7, 0, 9);
Console.WriteLine("Сгенерированный массив");
PrintArray(Array);

LetsSortEvenColumns(Array);

Console.WriteLine("Отсортированный массив");
PrintArray(Array);

// метод сортировки
void LetsSortEvenColumns(int[,] array)
{
    for (int i = 0; i < array.GetLength(1); i++)
    {
        for (int j = 0; j < array.GetLength(0); j++)
        {
            for (int z = 0; z < array.GetLength(0)-1; z++)
            {
                 if (array[z,i] > array[z+1,i] && i % 2 == 1)
                 {
                    int tmp = array[z,i];
                     array[z,i] = array[z+1,i];
                     array[z+1,i] = tmp;
                 }
            }
        }
    }
}












// общие методы
int[,] GetArray(int rows,
                int columns,
                int min,
                int max)
{
    int[,] result = new int[rows, columns];
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            result[i, j] = new Random().Next(min, max + 1);
        }
    }
    return result;
}

void PrintArray(int[,] Array)
{
    for (int i = 0; i < Array.GetLength(0); i++)
    {
        for (int j = 0; j < Array.GetLength(1); j++)
        {
            Console.Write($" {Array[i, j]:F0}");
        }
        Console.WriteLine();
    }

}