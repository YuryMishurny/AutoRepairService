using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp3
{
    class Detail
    {
        public string NameDetail { get; }
        public int Price { get; }

        public Detail(string nameDetail, int price, int pricePerJob)
        {
            NameDetail = nameDetail;
            Price = price + pricePerJob;
        }

        public void ShowInfo()
        {
            Console.WriteLine("Название детали - " + NameDetail + " | " + " Цена за деталь с учетом работы - " + Price);
        }
    }
}
