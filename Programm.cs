using LibraryNameSpace;
using StudentNameSpace;
using System;
using System.Text.RegularExpressions;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student[] students = new Student[1];
            for (int i = 0; i < students.Length; i++)
            {
                students[i] = new Student
                {
                    Name = "",
                };
            }
            Reader reader = new Reader(students[0].Name);

            Console.WriteLine();

            Console.WriteLine(reader.takeBook(2, "Книга 1, Книга 2"));
            Console.WriteLine(reader.returnBook(2));

            Console.WriteLine();

            Console.WriteLine(reader.takeBook(2));
            Console.WriteLine(reader.returnBook(2));

            Console.WriteLine();

            Console.WriteLine(reader.takeBook(2, "Книга 1", "Книга 2", "Книга 3", "Книга 4", "Книга 5"));
            Console.WriteLine(reader.returnBook());

            Console.WriteLine();

            Console.WriteLine(reader.takeBook("Книга 1", "Книга 2", "Книга 3"));
            Console.WriteLine(reader.returnBook());
        }
    }
}
namespace StudentNameSpace
{
    class Student 
    {
        private string name;
        private string surname;

        public string Name
        {
            get { return name + " " + surname; }
            set
            {
                Console.Write("Введите имя: ");
                string inputName = Console.ReadLine();
                if (nameIsMatch(inputName))
                    name = inputName;
                else
                {
                    Console.WriteLine("Некорректное имя.");
                    while (!nameIsMatch(inputName))
                    {
                        Console.Write("Введите имя: ");
                        inputName = Console.ReadLine();
                    }
                    name = inputName;
                }

                Console.Write("Введите фамилию: ");
                string inputSurname = Console.ReadLine();
                if (nameIsMatch(inputSurname))
                    surname = inputSurname;
                else
                {
                    Console.WriteLine("Некорректная фамилия.");
                    while (!nameIsMatch(inputSurname))
                    {
                        Console.Write("Введите фамилию: ");
                        inputSurname = Console.ReadLine();
                    }
                    surname = inputSurname;
                }
            }
        }
        static bool nameIsMatch(string name)
        {
            string pattern = @"^[а-яА-Яa-zA-Z]{2,}$";
            return Regex.IsMatch(name, pattern);
        }
    }
}
namespace LibraryNameSpace
{
    class Reader
    {
        private string fullName;
        private string[] takeBookName;
        public Reader(string fullName)
        {
            this.fullName = fullName;
        }
        public string takeBook(byte takeBookNum)
        {
            return $"{fullName} взял {takeBookNum} книг";
        }
        public string takeBook(byte takeBookNum, params string[] takeBookName)
        {
            this.takeBookName = takeBookName;
            return $"{fullName} взял {takeBookNum} книг: {string.Join(",",takeBookName)}";
        }
        public string takeBook(params string[] takeBookName)
        {
            this.takeBookName = takeBookName;
            return $"{fullName} взял: {string.Join(",", takeBookName)}";
        }
        public string returnBook(byte takeBookNum)
        {
            return $"{fullName} вернул {takeBookNum} книг";
        }
        public string returnBook()
        {
            return $"{fullName} вернул: {string.Join(", ", takeBookName)}";
        }
    }
}
