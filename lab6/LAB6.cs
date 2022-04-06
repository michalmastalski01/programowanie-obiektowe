/*using System;
using System.Collections;
using System.Collections.Generic;

namespace lab6
{
    record Ingredient
    { 
        public double Calories { get; init; }
        public string Name { get; init; }
    }
    class Sandwich: IEnumerable<Ingredient>
    {
        public Ingredient Bread { get; init; }
        public Ingredient Butter { get; init; }
        public Ingredient Salad { get; init; }
        public Ingredient Ham { get; init; }

        public IEnumerator<Ingredient> GetEnumerator()
        {
            //return new SandwichEnumerator(this);
            yield return Bread; //zwrócone w Current po pierwszym wywołaniu MoveNext
            yield return Butter; //zwrócone w Current po drugim wywołaniu MoveNext
            yield return Salad;
            yield return Ham;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    class Parking: IEnumerable<string>
    {
        private String[] _arr = {null, "KR 2137", "KNT 123N2", null, "KNS Y23WG", "KLI 6ULO9", null, null};
        public string this[char slot] 
        {
            get
            {
                return _arr[slot - 'A'];
            }
            set
            {
                _arr[slot - 'A'] = value;
            }
        }

        public IEnumerator<string> GetEnumerator()
        {
            foreach(string car in _arr)
            {
                if(car != null)
                {
                    yield return car;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    class SandwichEnumerator : IEnumerator<Ingredient>
    {
        private Sandwich _sandwich;
        int counter = -1;

        public SandwichEnumerator(Sandwich sandwich)
        {
            _sandwich = sandwich;
        }

        public Ingredient Current
        {
            get
            {
                return counter switch
                {
                    0 => _sandwich.Bread,
                    1 => _sandwich.Butter,
                    2 => _sandwich.Ham,
                    3 => _sandwich.Salad,
                    _ => null
                };
            }
        }

        object IEnumerator.Current => throw new NotImplementedException();

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool MoveNext()
        {
            return ++counter < 4;
        }

        public void Reset()
        {

        }
    }

    class LAB6
    {
        static void Main(string[] args)
        {
            Sandwich sandwich = new Sandwich()
            {
                Bread = new Ingredient() { Calories = 100, Name = "Bułka" },
                Ham = new Ingredient() { Calories = 400, Name = "Poznańska" },
                Salad = new Ingredient() { Calories = 10, Name = "Lodowa" },
                Butter = new Ingredient() { Calories=300, Name = "Masło"}
            };

            IEnumerator<Ingredient> enumerator = sandwich.GetEnumerator();
            while(enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current);
            }
            foreach(Ingredient i in sandwich)
            {
                Console.WriteLine(i);
            }

            Parking parking = new Parking();
            foreach(string str in parking)
            {
                Console.WriteLine(str);
            };
            Console.WriteLine(string.Join(", ", parking));
            Console.WriteLine(string.Join(", ", sandwich));
            Console.WriteLine(parking['C']);
            parking['A'] = "KTT 3WS68";
            Console.WriteLine(string.Join(", ", parking));

        }
    }
}
*/