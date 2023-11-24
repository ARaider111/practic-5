using System;
using System.IO;

class Program
{
  static void WritingToFile(string numsTask2, double[] numbers)
  {
    string stringNumbers = string.Join(";" + " ", numbers);
    using(StreamWriter writer = new StreamWriter(numsTask2))
    {
      writer.WriteLine(stringNumbers);
    }
  }
  
  public static void Main (string[] args) 
  {
    string numsTask2 = "numsTask2.txt";
    int k = 0;

    Console.WriteLine ("Введите количество чисел: ");
    k = int.Parse(Console.ReadLine());
    double[] numbers = new double[k];
    Random rand = new Random();
    string stringNumbers = "";
    try
    {
      for (int i = 0; i < numbers.Length; ++i)
      {
        numbers[i] =  Math.Round(rand.NextDouble() * 100 - 10, 2);
      }

      WritingToFile(numsTask2, numbers);

      using(StreamReader reader = new StreamReader(numsTask2))
      {
        stringNumbers = reader.ReadLine();
        string[] numberStrings = stringNumbers.Split(";" + " ");
        numbers = new double[k];
        for (int j = 0; j < numberStrings.Length; ++j)
        {
          numbers[j] = Convert.ToDouble(numberStrings[j]); 
        }
      }
      
      for (int i = 0; i < numbers.Length; ++i)
      {
        for (int j = 0; j < numbers.Length - i - 1; ++j)
        {
         if (numbers[j] > numbers[j + 1])
          {
            double num = numbers[j];
            numbers[j] = numbers[j + 1];
            numbers[j + 1] = num;
          }

        }
      }
      WritingToFile(numsTask2, numbers);
      
      Console.WriteLine("Отсортированный массив: ");
      using(StreamReader reader = new StreamReader(numsTask2))
      {
        Console.WriteLine(reader.ReadLine());
      }
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
      File.Delete(numsTask2);
    }
  }
}
