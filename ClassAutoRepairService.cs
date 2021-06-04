using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp3
{
    class AutoRepairService
    {
        bool _isOpen = true;
        private int _balansMoney;

        private Queue<Car> _cars = new Queue<Car>();

        private List<Detail> _details = new List<Detail>
        {
            new Detail ("Генератор",80, 20),
            new Detail ("Генератор",80, 20),
            new Detail ("Стратер",40, 10),
            new Detail ("Мотор",200, 60),
            new Detail ("Колесо",50, 10),
            new Detail ("Коробка",85, 25),
        };

        private void AddCars()
        {
            _cars.Enqueue(new Car("BMW", "Коробка"));
            _cars.Enqueue(new Car("AUDI", "Генератор"));
            _cars.Enqueue(new Car("FORD", "Мотор"));
            _cars.Enqueue(new Car("OPEL", "Руль"));
        }

        public void Work()
        {
            AddCars();

            while (_isOpen)
            {
                Console.WriteLine("Баланс автосервиса - " + _balansMoney);
                Console.WriteLine("\nОчередь из автомобилей и их поломки:");
                foreach (var car in _cars)
                    car.ShowInfo();

                Console.WriteLine("\n1 - Загнать машину в бокс и начать ремонт\n2 - Выход");

                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Clear();
                        Console.SetCursorPosition(0, 20);
                        Console.WriteLine("Список деталей на складе");
                        foreach (var detail in _details)
                            detail.ShowInfo();

                        Console.SetCursorPosition(0, 0);

                        RepairCar();
                        break;
                    case "2":
                        _isOpen = false;
                        break;
                    default:
                        Console.WriteLine("Такой команды нет....");
                        break;
                }

                Console.WriteLine("\nНажмите любую клавишу для продолжения...");
                Console.ReadLine();
                Console.Clear();
            }
        }

        private void RepairCar()
        {
            if (_cars.Count > 0)
            {
                Car car = _cars.Dequeue();
                Console.Write("\nВ боксе находится: ");
                car.ShowInfo();

                if (IsAvailabilityDetail(_details, car.Breakdown))
                {
                    Console.WriteLine("Введите деталь, которую хотите установить в автомобиль клиента:");
                    string userInput = Console.ReadLine();


                    if (userInput == car.Breakdown)
                    {
                        for (int i = 0; i < _details.Count; i++)
                        {
                            if (_details[i].NameDetail == userInput)
                            {
                                Console.WriteLine("Вы успешно отремонтировали автомобиль и заработали: " + _details[i].Price + " $");
                                GetMoneyPerJob(_details[i]);
                                _details.Remove(_details[i]);
                            }
                        }
                    }
                    else if (IsAvailabilityDetail(_details, userInput))
                    {
                        RemoveDetailFromDetailshouse(userInput);
                        Console.WriteLine("Вы установили не ту деталь, нужно возмесить ущерб клиенту");
                        CompensationMoney();
                    }
                    else
                        Console.WriteLine("Вы о чем? Это что-то не понятное, клиент уехал, вы остаетесь без зарплаты");
                }
                else
                {
                    Console.WriteLine("Такой детали нет на складе, придется заплатить штраф");
                    CompensationMoney();
                }
            }
        }

        private bool IsAvailabilityDetail(List<Detail> details, string carBreakdown)
        {
            for (int i = 0; i < details.Count; i++)
            {
                if (details[i].NameDetail == carBreakdown)
                    return true;
            }

            return false;
        }

        private void RemoveDetailFromDetailshouse(string userInput)
        {
            for (int i = 0; i < _details.Count; i++)
            {
                if (_details[i].NameDetail == userInput)
                    _details.Remove(_details[i]);
            }
        }

        private void GetMoneyPerJob(Detail detail)
        {
            _balansMoney += detail.Price;
        }

        private void CompensationMoney()
        {
            int compensation = 50;

            if (_balansMoney > compensation)
                _balansMoney -= compensation;
            else
                Console.WriteLine("У сервиса нет денег на возмещение ущерба, мы предалгаем чинить ваш автомибиль бесплатно на протяжении года");
        }
    }
}
