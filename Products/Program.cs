using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Products
{
    class Program
    {
        static void Main(string[] args)
        {
            MakeDishesList();

            ChooseOption("start");




        }


        static List<Dish> Basis = new List<Dish>();
        static List<Dish> Garnish = new List<Dish>();

        static Random Rnd = new Random();

        static private void MakeAMenu()
        {
            Console.WriteLine("");
            ///////////////
            Console.WriteLine("На сколько дней вы хотите составить меню?");
            int days = Convert.ToInt32(Console.ReadLine());
            
        }

        static void ChooseOption(string position)
        {
            Console.WriteLine("");

            switch (position)
            {
                case "start":
                    Console.WriteLine("[0].Просмотреть список блюд");
                    Console.WriteLine("[1].Составить меню");

                    int option = Convert.ToInt32(Console.ReadLine());

                    switch (option)
                    {
                        case 0:
                            PrintDishesList();
                            break;
                        case 1:
                            MakeAMenu();
                            break;
                    }
                    break;

                case "printlist":
                    Console.WriteLine("[0].Назад");
                    Console.WriteLine("[1].Добавить блюдо в список");
                    Console.WriteLine("[2].Составить меню");

                    option = Convert.ToInt32(Console.ReadLine());

                    switch (option)
                    {
                        case 0:
                            ChooseOption("start");
                            break;
                        case 1:
                            AddDish();
                            break;
                        case 2:
                            MakeAMenu();
                            break;
                    }
                    break;

                default: ChooseOption(position);
                    break;
            }

            Console.WriteLine("");
        }

        static private void MakeDishesList()
        {
            makeList(Basis, @"Lists/Basis.txt");
            makeList(Garnish, @"Lists/Garnish.txt");
        }

        static void makeList(List<Dish> list, string path)
        {
            StreamReader sr = new StreamReader(path, Encoding.Default);

            list.Clear();

            while (sr.Peek() != -1)
            {
                string name = sr.ReadLine();

                list.Add(new Dish(name, list.Count));
            }

            sr.Close();
        }

        static void PrintDishesList()
        {
            Console.WriteLine("");
            ///////////////
            Console.WriteLine("Основные блюда:");
            printList(Basis);

            Console.WriteLine("Гарниры:");
            printList(Garnish);

            ChooseOption("printlist");
        }

        static void printList(List<Dish> list)
        {
            foreach (Dish dish in list)
            {
                Console.WriteLine(dish.Id + ". " + dish.Name);
            }

            Console.WriteLine("");
        }

        static void AddDish()
        {
            Console.WriteLine("Введите название блюда:");
            string name = Console.ReadLine();
            Console.WriteLine("Если блюдо главное - введите 1, если гарнир - 0");
            string basis = Console.ReadLine();
            StreamWriter sw;
            if (basis == "1")
                sw = new StreamWriter(@"Lists/Basis.txt", true, Encoding.Default);
            else
                sw = new StreamWriter(@"Lists/Garnish.txt", true, Encoding.Default);

            sw.WriteLine(name);
            sw.Close();

            MakeDishesList();
            ChooseOption("printlist");
        }
    }
}
