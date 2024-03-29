﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linq
{
    class Program
    {
        static void Main(string[] args)
        {







            // 1////////////////
            //LinqBegin6. Дана строковая последовательность.
            //Найти сумму длин всех строк, входящих в данную последовательность.
            //TODO


            List<string> str = new List<string> { "1qwerty", "cqwertyc", "cqwe", "c" };
            
           var length = str.Sum((x) => x.Length);
           // Console.WriteLine(length);

            ///////////////////


            ////2////////////////
            //LinqBegin11. Дана последовательность непустых строк. 
            //Пполучить строку, состоящую из начальных символов всех строк исходной последовательности.
            //TODO

            var first = str.Aggregate("",(x, y) => x + y.First());


            ///////
            ///



            ////////3///////////  
            /////LinqBegin22. Дано целое число K (> 0) и строковая последовательность A.
            //Строки последовательности содержат только цифры и заглавные буквы латинского алфавита.
            //Извлечь из A все строки длины K, оканчивающиеся цифрой, отсортировав их по возрастанию.
            //TODO

            int k = 5;
            List<string> str2 = new List<string> { "32A", "CNGJ6","A5H47","BH477","DTBDB" };

            var el = str2.Where(x => x.Length == k&& char.IsDigit( x[x.Length-1])).OrderBy(x=>x);


            /* foreach (var item in el)
             {
                 Console.WriteLine(item);
             }*/




            //LinqBegin29. Даны целые числа D и K (K > 0) и целочисленная последовательность A.
            //Найти теоретико - множественное объединение двух фрагментов A: первый содержит все элементы до первого элемента, 
            //большего D(не включая его), а второй — все элементы, начиная с элемента с порядковым номером K.
            //Полученную последовательность(не содержащую одинаковых элементов) отсортировать по убыванию.
            //TODO
            int D = 15;
            int K = 8;
            int[] A = { 6, 3, 10, 1, 2, 15, 45, 11, 9,14,69 };
           
            
            var el2 = A.TakeWhile(x => x < D).
                Concat(A.SkipWhile((x,i)=>i<K)).OrderByDescending(x=>x) ;


            /*  foreach (var item in el2)
              {
                  Console.WriteLine(item);
              }*/


            //////////////////////////////////////////////////////////////////////////////



            //LinqBegin36. Дана последовательность непустых строк. 
            //Получить последовательность символов, которая определяется следующим образом: 
            //если соответствующая строка исходной последовательности имеет нечетную длину, то в качестве
            //символа берется первый символ этой строки; в противном случае берется последний символ строки.
            //Отсортировать полученные символы по убыванию их кодов.
            //TODO

            List<string> str3 = new List<string> { "1qwerty", "cqgwertyc8", "cqwe", "cwcG57" };
            Func<string,char> greet = line =>
            {
                if (line.Length%2==0)
                {
                    return line[line.Length-1];
                }
                else
                {
                    return line[0];
                }
            };

            var el3 = str3.Select((x,i) =>new {
                cha=greet(x),
                index =i
            }).OrderBy(x=>x.cha);

            /* foreach (var item in el3)
             {
                 Console.WriteLine($"{item.index}  {item.cha}");

             }*/


            //////////////////////////////////////////////////////////////////////


            //LinqBegin44. Даны целые числа K1 и K2 и целочисленные последовательности A и B.
            //Получить последовательность, содержащую все числа из A, большие K1, и все числа из B, меньшие K2. 
            //Отсортировать полученную последовательность по возрастанию.
            //TODO



            int K1 = 20;
            int K2 = 15;
            int[] A1 = { 3, 10, 1, 2, 15, 45, 11, 9, 14, 69 };
            int[] B1 = { 6, 9, 1, 11, 68, 22, 34, 101 };

            var el4 = A1.Where(x => x > K1).Concat(B1.Where(x=>x<K2)).OrderBy(x=>x);


            /*  foreach (var item in el4)
              {
                  Console.WriteLine(item);
              }*/


            //////////////////////////////////////////////////////////
            ///




            //LinqBegin48.Даны строковые последовательности A и B; все строки в каждой последовательности различны, 
            //имеют ненулевую длину и содержат только цифры и заглавные буквы латинского алфавита. 
            //Найти внутреннее объединение A и B, каждая пара которого должна содержать строки одинаковой длины.
            //Представить найденное объединение в виде последовательности строк, содержащих первый и второй элементы пары, 
            //разделенные двоеточием, например, «AB: CD». Порядок следования пар должен определяться порядком 
            //первых элементов пар(по возрастанию), а для равных первых элементов — порядком вторых элементов пар(по убыванию).
            //TODO


            IEnumerable<string> col1 = new string[] { "B4GGG5", "VRYR4", "R455BFD", "VN7348" };

            IEnumerable<string> col2 = new string[] { "5rG5G", "L4RggYR4", "R455BF", "VN", "Afntwq" };
            ///////////////////////////////////////////////////////////////////////////

            var el5 = col1.Join(col2,
                e => e.Length,
                o => o.Length,
                (e, o) => new
                {
                    name = String.Format($" {e}  : {o} "),
                    first = e,
                    second = o,
                   

                }).OrderBy(e=>e.first).ThenByDescending(o=>o.second)
                ;


            /* foreach (var item in el5)
             {
                 Console.WriteLine(item);
             }*/





            //////////////////////////////////////////////////////////////////////
            ///


            //LinqObj17. Исходная последовательность содержит сведения об абитуриентах. Каждый элемент последовательности
            //включает следующие поля: < Номер школы > < Год поступления > < Фамилия >
            //Для каждого года, присутствующего в исходных данных, вывести число различных школ, которые окончили абитуриенты, 
            //поступившие в этом году (вначале указывать число школ, затем год). 
            //Сведения о каждом годе выводить на новой строке и упорядочивать по возрастанию числа школ, 
            //а для совпадающих чисел — по возрастанию номера года.
            //TODO

            Abiturient[] abiturients= new Abiturient[]{

                new Abiturient("Maluk",24,2017),
                 new Abiturient("Honchar",25,2018),
                  new Abiturient("Andrushchenko",26,2017),
                   new Abiturient("Vigor",25,2018),
                    new Abiturient("Petrenko",28,2018),
            };

            var sort = abiturients.GroupBy(x => x.Year).Select(x => new { Year = x.Key, Count = x.GroupBy(y => y.School).Count() });



            
            foreach (var item in sort)
            {
               Console.WriteLine($"{item.Year }   {item.Count} ");
            }
                
                



           

         
                





            /////////////////////////////////////////////////////////////////////



            Console.ReadLine();
        }

    }
}
