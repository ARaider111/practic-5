using System;
using System.IO;

class Program 
{
  public static void Main (string[] args) 
  {
    string numsTask3 = "numsTask3.txt";
    int k = 0;

    Console.WriteLine ("Введите количество чисел: ");
    k = int.Parse(Console.ReadLine());
    int[] numbers = new int[k];
    Random rand = new Random();

    try
    {
      for (int i = 0; i < numbers.Length; ++i)
      {
        numbers[i] = rand.Next(1, 100);
      }

      string stringNumbers = string.Join(" ", numbers);
      using(StreamWriter writer = new StreamWriter(numsTask3))
      {
        writer.WriteLine(stringNumbers);
      }

      using(StreamReader reader = new StreamReader(numsTask3))
      {
        stringNumbers = reader.ReadLine();
        string[] numberStrings = stringNumbers.Split(" ");
        numbers = new int[k];
        for (int j = 0; j < numberStrings.Length; ++j)
        {
          numbers[j] = int.Parse(numberStrings[j]); 
        }
      }

      int minNum = 0;
      int minElement = numbers[0];
      Console.WriteLine("Массив чисел: ");    
      for (int i = 0; i < numbers.Length; ++i)
      {
        Console.Write(numbers[i] + " ");
        if (numbers[i] < minElement)
        {
          minElement = numbers[i];
          minNum = i;
        }
      }

      Console.WriteLine(" "); 
      Console.WriteLine($"Минимальное число: {minElement}"); 
      int sum = 0, n = 0;
      for (int i = 0; i < minNum; ++i)
      {
        sum += numbers[i];
        ++n;
      }

      double result = (double)sum / n;
      Console.WriteLine($"Среднее арифметическое равно: {result:F2}"); 
    }

    catch (FileNotFoundException)
    {
        Console.WriteLine("Файл не найден");
    }
    catch (IOException)
    {
        Console.WriteLine("Ошибка чтения файла или записи в файл");
    }

    finally 
    {
      Console.WriteLine("Нажмите любую клавишу для завершения программы");
      Console.ReadKey();
      File.Delete(numsTask3);
    }
  }
}