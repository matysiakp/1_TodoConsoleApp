using System;
using System.Net;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_TodoConsoleApp
{
    class Program
    {
        public static void Main(string[] args)
        {
            string command = "";
            string path = @"C:\Users\Admin\Desktop\coders\1_TodoConsoleApp\1_TodoConsoleApp\1_TodoConsoleApp\bin\Debug\Data.txt";
            //TaskModel tm = new TaskModel();

            do
            {
                Console.WriteLine("Wpisz polecenie:");
                command = Console.ReadLine();
                if (command == "add")
                {
                    ConsoleEx.WriteLine("Wpisz dane w następującej formie: opis;data rozpoczęcia;data zakończenia;czy zadanie całodniowe - true/false;czy zadanie ważne - true/false", ConsoleColor.Blue);
                    TaskModel.AddTask(Console.ReadLine());
                    ConsoleEx.WriteLine("Wiersz został dodany", ConsoleColor.Blue);
                }
                else if (command == "delete")
                {
                    ConsoleEx.WriteLine("Wpisz numer id wiersza, którychcesz usunąć:", ConsoleColor.Red);
                    int nr = int.Parse(Console.ReadLine());
                    ConsoleEx.WriteLine($"Czy jeseteś pewien, że chcesz usunąć wiersz {nr}? t/n", ConsoleColor.DarkRed);
                    command = Console.ReadLine();
                    if (command == "t")
                    {
                        TaskModel.RemoveTask(nr);
                        ConsoleEx.WriteLine($"Wiersz {nr} został usunięty", ConsoleColor.DarkRed);
                    }
                    else if (command == "n")
                    {
                        ConsoleEx.WriteLine($"Nie usunięto wiersza {nr}.", ConsoleColor.DarkRed);
                        return;
                    }
                }
                else if (command == "show")
                {
                    TaskModel.ShowTask();
                }
                else if (command == "save")
                {
                    TaskModel.SaveTask(path);
                }
                else if (command == "get")
                {
                    TaskModel.LoadTask(path);
                }
            } while (command != "exit");
        }
    }

}
