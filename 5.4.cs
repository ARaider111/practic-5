using System;
using System.IO;

class Program 
{
  public static void Main (string[] args) 
  {
    string numsTask4 = "numsTask4.txt";
    int k = 0;

    Console.WriteLine ("Введите количество чисел: ");
    k = int.Parse(Console.ReadLine());
    int[] numbers = new int[k];
    Random rand = new Random();

    try
    {
      for (int i = 0; i < numbers.Length; ++i)
      {
        numbers[i] = rand.Next(1, 20);
      }

      string stringNumbers = string.Join(" ", numbers);
      using(StreamWriter writer = new StreamWriter(numsTask4))
      {
        writer.WriteLine(stringNumbers);
      }

      using(StreamReader reader = new StreamReader(numsTask4))
      {
        stringNumbers = reader.ReadLine();
        string[] numberStrings = stringNumbers.Split(" ");
        numbers = new int[k];
        for (int j = 0; j < numberStrings.Length; ++j)
        {
          numbers[j] = int.Parse(numberStrings[j]); 
        }
      }

      int maxElement = 0;
      Console.WriteLine("Массив чисел: ");    
      for (int i = 0; i < numbers.Length; ++i)
      {
        Console.Write(numbers[i] + " ");
        if (numbers[i] > maxElement)
        {
          maxElement = numbers[i];
        }
      }

      Console.WriteLine(" "); 
      Console.WriteLine($"Максимальное число: {maxElement}"); 
      int sum = 0;
      for (int i = 0; i < numbers.Length; ++i)
      {
        if(numbers[i] == maxElement - 1)
        {
          sum += numbers[i];
        }
      }

      Console.WriteLine($"Сумма равна:{sum}"); 
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
      File.Delete(numsTask4);
    }
  }
}