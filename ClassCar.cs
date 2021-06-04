using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp3
{
    class Car
    {
        private string _brand;
        public string Breakdown { get; }

        public Car(string brand, string breakdown)
        {
            _brand = brand;
            Breakdown = breakdown;
        }

        public void ShowInfo()
        {
            Console.WriteLine("Автомобиль - " + _brand + " Поломка - " + Breakdown);
        }
    }
}
