using System;
using System.Collections.Generic;
using System.Linq;

namespace ex54
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string CommandSortByName = "1";
            const string CommandSortByAge = "2";
            const string CommandShowByDisease = "3";
            const string CommandExit = "4";

            bool isOpen = true;

            Hospital hospital = new Hospital();

            while (isOpen)
            {
                hospital.ShowPatients();

                Console.Write($"Больница\n" +
                    $"{CommandSortByName} - отсортировать больных по имени\n" +
                    $"{CommandSortByAge} - отсортировать больных по возрасту\n" +
                    $"{CommandShowByDisease} - вывести больных с заболеванием\n" +
                    $"{CommandExit} - выйти из программы\n" +
                    $"Ваш ввод: ");

                switch (Console.ReadLine())
                {
                    case CommandSortByName:
                        hospital.SortByName();
                        break; 

                    case CommandSortByAge:
                        hospital.SortByAge();
                        break;

                    case CommandShowByDisease:
                        hospital.ShowByDisease();
                        break;

                    case CommandExit:
                        isOpen = false;
                        break;

                    default:
                        Console.WriteLine("Неверный ввод...");
                        break;
                }

                Console.ReadKey();
                Console.Clear();
            }
        }
    }

    class Hospital
    {
        private List<Patient> _patients = new List<Patient>();

        public Hospital()
        {
            AddPatients();
        }

        public void SortByName()
        {
            var sortedPatients = _patients.OrderBy(patient => patient.Name).ToList();
            _patients = sortedPatients;
        }

        public void SortByAge()
        {
            var sortedPatients = _patients.OrderBy(patient => patient.Age).ToList();
            _patients = sortedPatients;
        }

        public void ShowByDisease()
        {
            Console.WriteLine("Напишите название заболевания: ");
            string disease = Console.ReadLine();

            var sortedPatients = _patients.Where(patient => patient.Disease == disease).ToList();

            Console.Clear();

            ShowPatients(sortedPatients, disease);
        }

        public void ShowPatients()
        {
            Console.SetCursorPosition(0, 10);
            Console.WriteLine("Список больных: ");

            for (int i = 0; i < _patients.Count; i++)
            {
                _patients[i].ShowInfo();
            }

            Console.SetCursorPosition(0, 0);
        }

        public void ShowPatients(List<Patient> patients, string disease)
        {
            Console.WriteLine($"Список больных болезнью {disease}: ");

            for (int i = 0; i < patients.Count; i++)
            {
                patients[i].ShowInfo();
            }
        }

        private void AddPatients()
        {
            _patients.Add(new Patient("Мыларщиков Илья Константинович", 22, "Альцгеймер"));
            _patients.Add(new Patient("Ступников Роман Дмитриевич", 25, "Гипертония"));
            _patients.Add(new Patient("Васьков Роман Олегович", 30, "Ушной отит"));
            _patients.Add(new Patient("Богатырев Иван Олегович", 18, "Простуда"));
            _patients.Add(new Patient("Ларионов Егор Александрович", 40, "Сердечная недостаточность"));
            _patients.Add(new Patient("Красовский Михаил Евгеньевич", 52, "Рак легких"));
            _patients.Add(new Patient("Волосников Вениамин Олегович", 12, "Простуда"));
            _patients.Add(new Patient("Мыларщикова Елена Романовна", 23, "ПМС"));
        }
    }

    class Patient
    {
        public Patient(string name, int age, string disease)
        {
            Name = name;
            Age = age;
            Disease = disease;
        }

        public string Name { get; private set; }
        public int Age { get; private set; }
        public string Disease { get; private set; }

        public void ShowInfo()
        {
            Console.WriteLine($"{Name}. Возраст: {Age} лет. Заболевание: {Disease}");
        }
    }
}