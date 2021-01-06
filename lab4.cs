using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab4
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var taskProcessorPairs = new Dictionary<int, int>(5);
            const int size = 5;
            var matrix = new List<List<int>>(5);
            var random = new Random();
            for (var i = 0; i < size; i++)
            {
                matrix.Add(new List<int>(5));
            }
            foreach (var row in matrix)
            {
                for (var i = 0; i < size; i++)
                {
                    row.Add(random.Next(0, 2));
                }   
            }
            DisplayMatrix(matrix);
            UniqueRow(matrix, taskProcessorPairs);
            FirstAppropriate(matrix, taskProcessorPairs);
            Console.WriteLine("Result");
            foreach (var item in taskProcessorPairs)
            {
                Console.WriteLine($"{item.Key}:{item.Value}");
            }
        }

        static void UniqueRow(List<List<int>> array, Dictionary<int, int> result)
        {
            bool modified = false;
            for (var i = 0; i < array.Count; i++)
            {
                var quantity = 0;
                var position = 0;
                for (var j = 0; j < array.Count; j++)
                {
                    if (array[i][j] == 1)
                    {
                        quantity++;
                        position = j;
                    }
                }
                if (quantity == 1)
                {
                    Reduce(new KeyValuePair<int, int>(i, position), array);
                    Console.WriteLine($"[{i} : {position}]");
                    DisplayMatrix(array);
                    result.Add(i, position);
                    modified = true;
                }
            }
            if (modified)
            {
                UniqueRow(array, result);
                UniqueColumn(array, result);
            }
            else
            {
                FirstAppropriate(array, result);
            }
        }

        static void UniqueColumn(List<List<int>> array, Dictionary<int, int> result)
        {
            var modified = false;
            for (var i = 0; i < array.Count; i++)
            {
                var quantity = 0;
                var position = 0;
                for (var j = 0; j < array.Count; j++)
                {
                    if (array[j][i] == 1)
                    {
                        quantity++;
                        position = j;
                    }
                }
                if (quantity == 1)
                {
                    Reduce(new KeyValuePair<int, int>(position, i), array);
                    Console.WriteLine($"[{position} : {i}]");
                    DisplayMatrix(array);
                    result.Add(position, i);
                    modified = true;
                }
            }
            if (modified)
            {
                UniqueRow(array, result);
                UniqueColumn(array, result);
            }
            else
            {
                FirstAppropriate(array, result);
            }
        }
        static void Reduce(KeyValuePair<int, int> keyValuePair, List<List<int>> array)
        {
            for (int i = 0; i < 5; i++)
            {
                    array[keyValuePair.Key][i] = 0;
            }
            for (int i = 0; i < 5; i++)
            {
                    array[i][keyValuePair.Value] = 0;
            }
        }

        static void DisplayMatrix(List<List<int>> array)
        {
            foreach (var row in array)
            {
                foreach (var item in row)
                {
                    Console.Write(item + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        static void FirstAppropriate(List<List<int>> array, Dictionary<int, int> result)
        {
            for (var i = 0; i < array.Count; i++)
            {
                for (var j = 0; j < array.Count; j++)
                {
                    if (array[i][j] == 1)
                    {
                        Reduce(new KeyValuePair<int, int>(i, j), array);
                        Console.WriteLine($"FirstAppropriate");
                        Console.WriteLine($"[{i} : {j}]");
                        result.Add(i/*ряд*/, j/*стовпчик*/);
                        DisplayMatrix(array);
                        UniqueRow(array, result);
                        UniqueColumn(array, result);
                        return;
                    }
                }
            }
        }
    }
}