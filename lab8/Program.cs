using System;
using System.Linq;
using System.Collections.Generic;

namespace lab8
{
    record Student(string Name, char Team, int Ects);
    class Program
    {
        static void Main(string[] args)
        {
            int[] ints = { 5, 3, 1, 7, 4, 7, 9, 5, 2 };
            Predicate<int> oddPredicate = n =>
            {
                Console.WriteLine("Obliczanie predykatu dla n " + n);
                return n % 2 == 1;
            };
            Console.WriteLine("Przed wykonaniem wiersza 1");
            IEnumerable<int> odds = from n in ints
            where oddPredicate.Invoke(n)
            select n;
            Console.WriteLine("Przed wykonaniem wiersza 2");
            odds = from n in odds
            where n > 5
            select n;
            //rozbudowany predykat
            int limit = 5;
            odds = from n in ints
            where n % 2 == 1 && n > limit
            select n;
            Console.WriteLine(string.Join(", ", odds));
            string[] strings = {"aa", "bb", "ccc", "fff", "ee", "ggggg"};
            //zapisz wyrażenie linq ktore zwroci liste lancuchow o dlugosci 2 znakow
            IEnumerable<int> znaki = from s in strings
                                     select s.Length;
            Console.WriteLine(string.Join(", ", znaki));
            znaki = from s in strings
                    orderby s descending
                    select s.Length;
            Console.WriteLine(string.Join(", ", znaki));

            Console.WriteLine(string.Join(", ", from n in ints orderby n descending select Math.Pow(n, 2)));
            Student[] students =
            {
                new Student("Jacek", 'A', 89),
                new Student("Anna", 'A', 76),
                new Student("Konstantyn", 'B', 104),
                new Student("Wawrzyniec", 'A', 64),
                new Student("Piotr", 'B', 81),
                new Student("Anna", 'A', 95)
            };
            Console.WriteLine(string.Join(", ", from s in students group s by s.Team into team select (team.Key, team.Count())));
            IEnumerable<IGrouping<char, Student>> teams = from s in students group s by s.Team;
            foreach(var item in teams)
            {
                Console.WriteLine("Grupa: " + item.Key + "| " + string.Join("\n", item));
            }
            string sentence = "ala ma kota ala lubi koty tomek lubi psy";
            //wykonaj zestawienie ile razy każdy z wyrazów występuje w sentence
            string[] tab = sentence.Split(" ");
            Console.WriteLine(string.Join(", ", from t in tab group t by t into wyrazy select (wyrazy.Key, wyrazy.Count())));

            IEnumerable<int> enumerable = ints
                .Where(n => n % 2 == 1)
                .OrderBy(n => n)
                .Select(n => (int)Math.Pow(n, 2));
            Console.WriteLine(string.Join(", ", enumerable));
            students.GroupBy(student => student.Team).Select(gr => (gr.Key, gr.Count()));
            IOrderedEnumerable<Student> sorted = students.OrderBy(student => student.Name).ThenByDescending(student => student.Ects);
            Console.WriteLine(string.Join("\n", sorted));

            //posortuj łańcuchy w strings wg dlugosci a łańcuchy o tej samej dlugosci rosnąco alfabetycznie.
            Console.WriteLine(string.Join("\n",
                strings.OrderBy(s => s.Length).ThenBy(s => s)
                ));
            int wynik = Enumerable.Range(0, 10).Where(n => n % 2 == 0).Sum();
            //suma kwadratów liczb nieparzystych od 0 do 10
            int wynik2 = Enumerable.Range(0, 11).Where(n => n % 2 == 0).Select(n => (int)Math.Pow(n, 2)).Sum();
            Console.WriteLine(wynik2);
            Student second = students.OrderByDescending(s => s.Ects).ElementAt(1);
            Console.WriteLine(second);
            Student st = students.FirstOrDefault(s => s.Name.StartsWith("A"));
            Console.WriteLine(st);

            Random random = new Random();
            random.Next(5);
            //wygenerować tablicę 100 liczb losowych o wartościach od 0 do 9.
            
        }
    }
}
