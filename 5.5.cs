 using System;
 using System.IO;

 class Program 
 {
   public static void Main (string[] args) 
   {
     string numsTask5 = "numsTask5.txt";
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
       using(StreamWriter writer = new StreamWriter(numsTask5))
       {
         writer.WriteLine(stringNumbers);
       }

       using(StreamReader reader = new StreamReader(numsTask5))
       {
         stringNumbers = reader.ReadLine();
         string[] numberStrings = stringNumbers.Split(" ");
         numbers = new int[k];
         for (int j = 0; j < numberStrings.Length; ++j)
         {
           numbers[j] = int.Parse(numberStrings[j]); 
         }
       }

       int minNum = 0, maxNum = 0, maxElement = 0;
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
         if (numbers[i] > maxElement)
          {
            maxElement = numbers[i];
            maxNum = i;
          }
       }

       if(minNum > maxNum)
       {
         int temp = 0;
         maxNum = temp;
         minNum = maxNum;
         maxNum = temp;
       }

       Console.WriteLine(" "); 
       Console.WriteLine($"Минимальное число: {minElement}"); 
       Console.WriteLine($"Максимальное число: {maxElement}");
       int sum = 0, n = 0;
       for (int i = minNum + 1; i < maxNum; ++i)
       {
         sum += numbers[i];
         ++n;
       }

       if (sum != 0)
       {
         double result = (double)sum / n;
         Console.WriteLine($"Среднее арифметическое равно: {result:F2}"); 
       }
       else
       {
         Console.WriteLine("Чисел между минимальным и максимульным нет");
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
       File.Delete(numsTask5);
     }
   }
 }