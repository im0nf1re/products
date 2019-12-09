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


        static List<Dish> Dishes = new List<Dish>();
        static Random Rnd = new Random();

        static private void MakeAMenu()
        {
            
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
            }

            Console.WriteLine("");
        }

        static private void MakeDishesList()
        {
            StreamReader sr = new StreamReader(@"Dishes.txt", Encoding.Default);

            Dishes.Clear();

            while (sr.Peek() != -1)
            {
                string str = sr.ReadLine();
                string name = str.Split(',')[0];
                bool basis = str.Split(',')[1] == "0" ? false : true;

                Dishes.Add(new Dish(name, basis, Dishes.Count));
            }

            sr.Close();
        }

        static void PrintDishesList()
        {
            Console.WriteLine("");
            foreach (Dish dish in Dishes)
            {
                Console.WriteLine(dish.Id + ". " +  dish.Name + ", " + dish.Basis);
            }

            ChooseOption("printlist");
        }

        static void AddDish()
        {
            Console.WriteLine("Введите название блюда:");
            string name = Console.ReadLine();
            Console.WriteLine("Если блюдо главное - введите 1, если гарнир - 0");
            string basis = Console.ReadLine();
            

            StreamWriter sw = new StreamWriter(@"Dishes.txt", true, Encoding.Default);

            sw.WriteLine(name + "," + basis);
            sw.Close();

            MakeDishesList();
            ChooseOption("printlist");
        }
    }
}
