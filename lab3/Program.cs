using System;

namespace lab3
{
    abstract class Product
    {
        public virtual decimal Price { get; init; }

        public abstract decimal GetVatPrice();
    }

    class Computer : Product
    {
        public decimal Vat { get; init; }
        public override decimal GetVatPrice()
        {
            return Price * Vat / 100m;
        }
    }
    interface IFly
    {
        void Fly();
    }
    interface ISwim
    {
        void Swim();
    }
    abstract class Animal
    {

    }
    class Duck : Animal, ISwim, IFly
    {
        public void Fly()
        {
            throw new NotImplementedException();
        }

        public void Swim()
        {
            throw new NotImplementedException();
        }
    }

    class Paint : Product
    {
        public decimal Vat { get; set; }
        public decimal Capacity { get; init; }

        public decimal PriceUnit { get; init; }
        public override decimal GetVatPrice()
        {
            return Price * Capacity * Vat / 100m;
        }

        public override decimal Price
        {
            get
            {
                return PriceUnit * Capacity;
            }
        }
    }

    class Butter : Product
    {
        public override decimal GetVatPrice()
        {
            return 2m;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Product[] shop = new Product[4];
            shop[0] = new Computer() { Price = 2000m, Vat = 23m };
            shop[1] = new Paint() { PriceUnit = 12, Capacity = 5, Vat = 8m };
            shop[2] = new Computer() { Price = 3500m, Vat = 23m };
            shop[3] = new Butter();
            decimal sumVat = 0;
            decimal sumPrice = 0;
            foreach (var product in shop)
            {
                sumVat += product.GetVatPrice();
                sumPrice += product.Price;
                Computer computer = product as Computer;
                Console.WriteLine(computer?.Vat);              
            }

        }
    }

    abstract class Person
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public DateTime BirthDate { get; init; }
    }

    class Student
    {
        public int studentId { get; init; }
    }
    class Lecturer
    {
       public string AcademicDegree { get; init; }
    }

}
