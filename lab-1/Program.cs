using System;

namespace lab_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine("hello");
            Person person = Person.OfName("Jakub");
            Console.WriteLine(person.FirstName);

            Money money = Money.OfWithException(15, Currency.PLN);
            Console.WriteLine(money.Value + " " + money.Currency);
            Money result = money * 0.22m;
            Console.WriteLine(result.Value);
            Console.WriteLine(money);
            Console.WriteLine(person);
            Console.WriteLine("Parse:");
            Money one = Money.ParseValue("15,54", Currency.PLN);
            Console.WriteLine(one);

            IEquatable<Money> ie = money;

            Money[] prices =
            {
                Money.Of(5, Currency.PLN),
                Money.Of(21, Currency.EUR),
                Money.Of(16, Currency.USD),
                Money.Of(9, Currency.EUR),
                Money.Of(33, Currency.PLN)
            };
            Console.WriteLine("Sort");
            Array.Sort(prices);
            foreach(var p in prices)
            {
                Console.WriteLine(p.ToString());
            }

        }
    }
    public class Person
    {
        private string firstName;

        private Person(string first_name)
        {
            firstName = first_name;
        }
        public static Person OfName(string name)
        {
            if (name != null && name.Length >= 2)
            {
                return new Person(name);
            }
            else
            {
                throw new ArgumentOutOfRangeException("Imię zbyt krótkie");
            }
        }

        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                if (value != null && value.Length >= 2)
                {
                    firstName = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Imię zbyt krótkie");
                }
            }
        }
        public override string ToString()
        {
            return $"Name: {firstName}";
        }

    }
    public enum Currency
    {
        PLN = 2,
        USD = 3,
        EUR = 1
    }

    public class Money : IEquatable<Money>, IComparable<Money>
    {
        private readonly decimal _value;
        private readonly Currency _currency;
        private Money(decimal value, Currency currency)
        {
            _value = value;
            _currency = currency;
        }

        public static Money operator*(Money money, decimal factor)
        {
            return Money.Of(money.Value * factor, money.Currency);
        }

        public decimal Value
        {
            get
            {
                return _value;
            }
        }
        public Currency Currency
        {
            get
            {
                return _currency;
            }
        }
        public static Money? Of(decimal value, Currency currency)
        {
            return value < 0 ? null : new Money(value, currency);
        }
        
        public static Money OfWithException(decimal value, Currency currency)
        {
            if(value >= 0)
            {
                return new Money(value, currency);
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }
        public static Money ParseValue(string valueStr, Currency currency)
        {
            if(decimal.Parse(valueStr) >= 0)
            {
                return new Money(decimal.Parse(valueStr), currency);
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }
        public override string ToString()
        {
            return $"Value: {_value}, Currency: {_currency}";
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Money);
        }

        public bool Equals(Money other)
        {
            return other != null &&
                   _value == other._value &&
                   _currency == other._currency;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_value, _currency);
        }

        public int CompareTo(Money other)
        {
           int curResult = _currency.CompareTo(other._currency);
            if(curResult == 0)
            {
                return _value.CompareTo(other._value);
            } else
            {
                return curResult;
            }
        }
    }

}