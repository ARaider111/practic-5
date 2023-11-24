using System;
using System.IO;

class Program 
{
  public static void Main (string[] args) 
  {
    string numsTask1 = "numsTask1.txt";
    int k = 0;

    Console.WriteLine ("Введите количество чисел: ");
    k = int.Parse(Console.ReadLine());
    int[] numbers = new int[k];
    Random rand = new Random();

    try
    {
      for (int i = 0; i < numbers.Length; ++i)
      {
        numbers[i] = rand.Next(-20, 20);
      }

      string stringNumbers = string.Join(" ", numbers);
      using(StreamWriter writer = new StreamWriter(numsTask1))
      {
        writer.WriteLine(stringNumbers);
      }

      using(StreamReader reader = new StreamReader(numsTask1))
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
      int product = 1;
      for (int i = minNum + 1; i < numbers.Length; ++i)
      {
        product *= numbers[i];
      }

      if (minNum == numbers.Length - 1)
      {
        product = 0;
      }
      Console.WriteLine($"Произведение равно: {product}"); 
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
      File.Delete(numsTask1);
    }
  }
}