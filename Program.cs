//*******************************************************************************************
//* Практическая работа №17                                                                 *
//* Выполнил: Абдуллаев Э.С., группа 2-ИСПд                                                 *
//* Задание: Написать программу, исвользуя "наследственность"                               *
//*******************************************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Computingdevice
{
    abstract class ComputingDeviceBase
    {
        protected string name;
        protected double power;
        protected uint speed;

        public ComputingDeviceBase()
        {
            Console.WriteLine("Это абстрактное вычислительное устройство.");
        }
        ~ComputingDeviceBase() {}
        public abstract void Input();

        protected abstract double CalculateEfficiency();
    }

    class ComputingDevice : ComputingDeviceBase
    {
        public ComputingDevice()
        {
            Console.WriteLine("Создано вычислительное устройство.");
        }

        public override void Input()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Название устройства: ");
            string inputName = Console.ReadLine();
            if (String.IsNullOrWhiteSpace(inputName))
            {
                throw new ArgumentException("Название не может быть пустым.");
            }
            name = inputName;
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("Мощность (Вт): ");
            string powerStr = Console.ReadLine();
            if (String.IsNullOrWhiteSpace(powerStr)) 
            {
                throw new Exception("Мощность не может быть пустой");
            }
            if (!Double.TryParse(powerStr, out double p) || p <= 0)
            {
                throw new ArgumentException("Мощность должна быть положительным числом.");
            }
            power = p;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Скорость (операций/сек): ");
            string speedStr = Console.ReadLine();
            if (String.IsNullOrWhiteSpace(speedStr)) 
            {
                throw new Exception("Скорость не может быть пустой!");
            }
            if (!UInt32.TryParse(speedStr, out uint s) || s == 0)
            {
                throw new ArgumentException("Скорость должна быть целым положительным числом.");
            }
            speed = s;
        }

        ~ComputingDevice()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Вычислительное устройство ВЗОРВАЛОСЬ!!! \nГлавное, не переживайте!)))");
            Console.ReadKey();
        }

        protected override double CalculateEfficiency()
        {
            if (power <= 0)
                throw new ArgumentException("Невозможно рассчитать эффективность: мощность недопустима.");
            return Math.Round(speed / power, 2);
        }

        protected void GetInfo()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"Информация о вычислительном устройстве" +
                $"\nНазвание устройства: {name}" +
                $"\nМощность: {power} Вт" +
                $"\nСкорость: {speed} операций/сек" +
                $"\nЭнергоэффективность: {CalculateEfficiency()} операций/Вт");
        }

        public void Output()
        {
            GetInfo();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    Console.Clear();
                    Console.Title = "Практическая работа №17";
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Здравствуйте!");
                    Console.WriteLine("Работа с вычислительным устройством:");
                    ComputingDevice device = new ComputingDevice();
                    device.Input();
                    device.Output();
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine("\nВыберите действие:");
                    Console.WriteLine("1 - Новый поиск");
                    Console.WriteLine("0 - Выйти из программы");
                    Console.Write("Ваш выбор: ");
                    string choice = Console.ReadLine();
                    switch (choice)
                    {
                        case "1":
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Новый поиск...");
                            break;
                        case "0":
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine("Программа завершена.");
                            return;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            throw new Exception("Неверный выбор!");
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Ошибка ввода: {ex.Message}");
                    Console.WriteLine("Нажмите любую клавишу для повтора...");
                    Console.ReadKey();
                }
                catch (InvalidOperationException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Ошибка: {ex.Message}");
                    Console.WriteLine("Нажмите любую клавишу для повтора...");
                    Console.ReadKey();
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Ошибка: {ex.Message}");
                    Console.WriteLine("Нажмите любую клавишу для повтора...");
                    Console.ReadKey();
                }
                Console.ReadKey();
            }
        }
    }
}







//*******************************************************************************************
//* Практическая работа №17                                                                 *
//* Выполнил: Абдуллаев Э.С., группа 2-ИСПд                                                 *
//* Задание: Написать программу, исвользуя "наследственность"                               *
//*******************************************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Computingdevice
{
    abstract class ComputingDeviceBase //предок
    {
        protected string name;
        protected double power;
        protected uint speed;

        public ComputingDeviceBase() //конструктор
        {
            Console.WriteLine("Это абстрактное вычислительное устройство.");
        }
        ~ComputingDeviceBase() { }

        protected abstract double CalculateEfficiency(); //Абстрактный метод
        public void Output()
        {
            GetInfo();
        }
        protected void GetInfo()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"Информация о вычислительном устройстве" +
                $"\nНазвание устройства: {name}" +
                $"\nМощность: {power} Вт" +
                $"\nСкорость: {speed} операций/сек" +
                $"\nЭнергоэффективность: {CalculateEfficiency()} операций/Вт");
        }
    }

    class ComputingDevice : ComputingDeviceBase //наследник
    {
        public void Input()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Название устройства: ");
            string inputName = Console.ReadLine();
            if (String.IsNullOrWhiteSpace(inputName))
            {
                throw new ArgumentException("Название не может быть пустым.");
            }
            base.name = inputName;
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("Мощность (Вт): ");
            string powerStr = Console.ReadLine();
            if (String.IsNullOrWhiteSpace(powerStr))
            {
                throw new Exception("Мощность не может быть пустой");
            }
            if (!Double.TryParse(powerStr, out double p) || p <= 0)
            {
                throw new ArgumentException("Мощность должна быть положительным числом.");
            }
            base.power = p;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Скорость (операций/сек): ");
            string speedStr = Console.ReadLine();
            if (String.IsNullOrWhiteSpace(speedStr))
            {
                throw new Exception("Скорость не может быть пустой!");
            }
            if (!UInt32.TryParse(speedStr, out uint s) || s == 0)
            {
                throw new ArgumentException("Скорость должна быть целым положительным числом.");
            }
            base.speed = s;
            base.GetInfo();
        }
        protected override double CalculateEfficiency() //Виртуальный метод
        {
            if (base.power <= 0)
                throw new ArgumentException("Невозможно рассчитать эффективность: мощность недопустима.");
            return Math.Round(base.speed / base.power, 2);
        }
        ~ComputingDevice() //деструктор
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Вычислительное устройство ВЗОРВАЛОСЬ!!! \nГлавное, не переживайте!)))");
            Console.ReadKey();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    Console.Clear();
                    Console.Title = "Практическая работа №17";
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Здравствуйте!");
                    Console.WriteLine("Работа с вычислительным устройством:");
                    ComputingDevice device = new ComputingDevice();
                    device.Input();
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine("\nВыберите действие:");
                    Console.WriteLine("1 - Новый поиск");
                    Console.WriteLine("0 - Выйти из программы");
                    Console.Write("Ваш выбор: ");
                    string choice = Console.ReadLine();
                    switch (choice)
                    {
                        case "1":
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Новый поиск...");
                            break;
                        case "0":
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine("Программа завершена.");
                            return;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            throw new Exception("Неверный выбор!");
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Ошибка ввода: {ex.Message}");
                    Console.WriteLine("Нажмите любую клавишу для повтора...");
                    Console.ReadKey();
                }
                catch (InvalidOperationException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Ошибка: {ex.Message}");
                    Console.WriteLine("Нажмите любую клавишу для повтора...");
                    Console.ReadKey();
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Ошибка: {ex.Message}");
                    Console.WriteLine("Нажмите любую клавишу для повтора...");
                    Console.ReadKey();
                }
                Console.ReadKey();
            }
        }
    }
}
