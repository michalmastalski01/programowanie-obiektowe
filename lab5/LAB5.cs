/*using System;

namespace lab5
{
    enum Degree
    {
        BardzoDobry = 50,
        DobryPlus = 45,
        Dobry = 40,
        DostatecznyPlus = 35,
        Dostateczny = 30,
        Niedostateczny = 20
    }
    record Student(string Name, int Points, char Group);

    class LAB5
    {
        static void Main(string[] args)
        {
            Degree ocena = Degree.Dostateczny;
            Console.WriteLine(ocena);
            Console.WriteLine((int)ocena);
            string[] vs = Enum.GetNames<Degree>();
            Console.WriteLine(string.Join(",", vs));
            Degree[] degrees = Enum.GetValues<Degree>();
            foreach(Degree d in degrees)
            {
                Console.WriteLine($"{d} {(int)d}");
            }
            Console.WriteLine("Wpisz ocene: ");
            //string input = Console.ReadLine();
            try
            {
                //Degree degree = Enum.Parse<Degree>(input);
                //Console.WriteLine($"Wpisałeś {degree} o wartości {(int)degree}");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("Wpisałeś nieznaną ocenę!");
            }
            string usDegree;
            switch (ocena)
            {
                case Degree.BardzoDobry:
                    usDegree = "A";
                    break;
                case Degree.DobryPlus:
                    usDegree = "B";
                    break;
            }
            usDegree = ocena switch
            {
                Degree.BardzoDobry => "A",
                Degree.DobryPlus => "B",
                Degree.Dobry => "C",
                Degree.DostatecznyPlus => "D",
                Degree.Dostateczny => "E",
                _ => "F"
            };

            Console.WriteLine(usDegree);

            int points = 67;
            Degree result;

            result = points switch
            {
                >= 50 and < 60 => Degree.Dostateczny,
                >= 60 and < 70 => Degree.DostatecznyPlus,
                >= 70 and < 80 => Degree.Dobry,
                >= 80 and < 90 => Degree.DobryPlus,
                >= 90 and <= 100 => Degree.BardzoDobry,
                _ => Degree.Niedostateczny
            };

            Student[] students =
            {
                new Student("Marcin", 87, 'C'),
                new Student("Jacek", 67, 'B'),
                new Student("Kacper", 54, 'A'),
                new Student("Julia", 48, 'D')
            };
            Console.WriteLine(students[1] == new Student("Jacek", 23, 'B'));
            foreach(Student st in students)
            {
                Console.WriteLine(st);
            }
            (string, bool)[] results = new (string, bool)[students.Length];
            for(int i = 0; i < students.Length; i++)
            {
                Student st = students[i];
                results[i] = (st.Name,
                    st switch
                    {
                        { Points: >= 100, Group: 'E' } => true,
                        { Points: >= 50, Group: 'B' } => true,
                        _ => false
                    }
                );
            }
            foreach(var s in results)
            {
                Console.WriteLine($"Student: {s.Item1}, czy zdał: {s.Item2}");
            }
        }
    }
}
*/