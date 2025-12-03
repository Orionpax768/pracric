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

        public abstract void Input();

        protected abstract double CalculateEfficiency();

        protected void GetInfo()
        {
            Console.WriteLine($"Информация о вычислительном устройстве" +
                $"\nНазвание устройства: {name}" +
                $"\nМощность: {power} Вт" +
                $"\nСкорость: {speed} операций/сек" +
                $"\nЭнергоэффективность: {CalculateEfficiency()} операций/Вт");
        }
    }

    class ComputingDevice : ComputingDeviceBase
    {
        public ComputingDevice()
        {
            Console.WriteLine("Создано вычислительное устройство.");
        }

        public override void Input()
        {
            Console.Write("Название устройства: ");
            string inputName = Console.ReadLine();
            if (String.IsNullOrWhiteSpace(inputName))
            {
                throw new ArgumentException("Название не может быть пустым.");
            }
            name = inputName;
            Console.Write("Мощность (Вт): ");
            string powerStr = Console.ReadLine();
            if (!Double.TryParse(powerStr, out double p) || p <= 0)
            {
                throw new ArgumentException("Мощность должна быть положительным числом.");
            }
            power = p;
            Console.Write("Скорость (операций/сек): ");
            string speedStr = Console.ReadLine();
            if (!UInt32.TryParse(speedStr, out uint s) || s == 0)
            {
                throw new ArgumentException("Скорость должна быть целым положительным числом.");
            }
            speed = s;
        }

        protected override double CalculateEfficiency()
        {
            if (power <= 0)
                throw new ArgumentException("Невозможно рассчитать эффективность: мощность недопустима.");
            return speed / power;
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
                    Console.Title = "Практическая работа №16";
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Здравствуйте!");
                    Console.WriteLine("Работа с вычислительным устройством (Нажмите клавишу Enter):");
                    ComputingDevice device = new ComputingDevice();
                    device.Input();
                    device.Output();
                    Console.ForegroundColor = ConsoleColor.White;
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
