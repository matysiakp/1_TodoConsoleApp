using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace _1_TodoConsoleApp
{
    public class TaskModel
    {
        public string Opis { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? StopDate { get; set; }
        public bool? AllDay { get; set; }
        public bool? Important { get; set; }
        

        public static List<TaskModel> list = new List<TaskModel>();
        public static List<TaskModel> orderListOne = new List<TaskModel>();
        public static List<TaskModel> orderListTwo = new List<TaskModel>();
        public static List<string> listast = new List<string>();

        //public TaskModel(string opis, DateTime startDate)
        //{
        //    //Opis = opis;
        //    StartDate = startDate;
        //}
        //public static string Validation(string param)
        //{
        //    if (string.IsNullOrWhiteSpace(param))
        //    {
        //        return null;
        //    }
        //    return param;
        //}
        public static void AddTask(/*string opis, DateTime startDate, DateTime stopDate, bool allDay, bool important*/ string text)
        {
            string[] table = text.Split(';');
            if (string.IsNullOrWhiteSpace(table[2]))
            {
                if (string.IsNullOrWhiteSpace(table[3]))
                {
                    if (string.IsNullOrWhiteSpace(table[4]))
                    {
                        list.Add(new TaskModel { Opis = table[0], StartDate = DateTime.Parse(table[1]), StopDate = null, AllDay = null, Important = null });
                    }
                    else
                    {
                        list.Add(new TaskModel { Opis = table[0], StartDate = DateTime.Parse(table[1]), StopDate = null, AllDay = null, Important = bool.Parse(Validation(table[4])) });
                    }
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(table[4]))
                    {
                        list.Add(new TaskModel { Opis = table[0], StartDate = DateTime.Parse(table[1]), StopDate = null, AllDay = bool.Parse(Validation(table[3])), Important = null });
                    }
                    else
                    {
                        list.Add(new TaskModel { Opis = table[0], StartDate = DateTime.Parse(table[1]), StopDate = null, AllDay = bool.Parse(Validation(table[3])), Important = bool.Parse(Validation(table[4])) });
                    }
                }
            }
            else
            {
                if (string.IsNullOrWhiteSpace(table[3]))
                {
                    if (string.IsNullOrWhiteSpace(table[4]))
                    {
                        list.Add(new TaskModel { Opis = table[0], StartDate = DateTime.Parse(table[1]), StopDate = DateTime.Parse(table[2]), AllDay = null, Important = null });
                    }
                    else
                    {
                        list.Add(new TaskModel { Opis = table[0], StartDate = DateTime.Parse(table[1]), StopDate = DateTime.Parse(table[2]), AllDay = null, Important = bool.Parse(Validation(table[4])) });
                    }
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(table[4]))
                    {
                        list.Add(new TaskModel { Opis = table[0], StartDate = DateTime.Parse(table[1]), StopDate = DateTime.Parse(table[2]), AllDay = bool.Parse(Validation(table[3])), Important = null });
                    }
                    else
                    {
                        list.Add(new TaskModel { Opis = table[0], StartDate = DateTime.Parse(table[1]), StopDate = DateTime.Parse(table[2]), AllDay = bool.Parse(Validation(table[3])), Important = bool.Parse(Validation(table[4])) });
                    }
                }
            }
            //list.Add(new TaskModel() {Opis = table[0], StartDate = DateTime.Parse(table[1]), StopDate = DateTime.Parse(Validation(table[2])), AllDay = bool.Parse(Validation(table[3])), Important = bool.Parse(Validation(table[4])) });
        }
        public static void RemoveTask(int index)
        {
            list.RemoveAt(index);
            //Console.WriteLine($"Rekord o indeksie {index} został usunięty");
        }
        public static void ShowTask()
        { 
            orderListOne = list.OrderByDescending(list => list.Important).ToList();
            //list.OrderByDescending(list => list.StartDate).ToList();
            orderListTwo = orderListOne.OrderByDescending(orderListOne => orderListOne.StartDate).ToList();
            list.Clear();
            list = orderListTwo;
            ConsoleEx.WriteLine("*--------------------------------------------------------------------------------------------------------------*", ConsoleColor.DarkGray);
            ConsoleEx.Write("|", ConsoleColor.DarkGray);
            ConsoleEx.Write("Id|".PadLeft(5), ConsoleColor.DarkGray);
            ConsoleEx.Write("Opis|".PadLeft(41), ConsoleColor.DarkGray);
            ConsoleEx.Write("Data rozpoczęcia|".PadLeft(20), ConsoleColor.DarkGray);
            ConsoleEx.Write("Data zakończenia|".PadLeft(20), ConsoleColor.DarkGray);
            ConsoleEx.Write("Czy całodniowe|".PadLeft(15), ConsoleColor.DarkGray);
            ConsoleEx.WriteLine("Czy ważne|".PadLeft(10), ConsoleColor.DarkGray);

            for (int i = 0; i < list.Count(); i++)
            {
                if (orderListTwo[i].Important == true)
                {
                    ConsoleEx.WriteLine($"|{orderListTwo.IndexOf(orderListTwo[i]).ToString().PadLeft(4)}|{orderListTwo[i].Opis.PadLeft(40)}|{orderListTwo[i].StartDate.ToString().PadLeft(19)}|{orderListTwo[i].StopDate.ToString().PadLeft(19)}|{orderListTwo[i].AllDay.ToString().PadLeft(14)}|{orderListTwo[i].Important.ToString().PadLeft(9)}|", ConsoleColor.DarkGray);
                    //ConsoleEx.WriteLine($"|{list.IndexOf(list[i]).ToString().PadLeft(4)}|{list[i].Opis.PadLeft(40)}|{list[i].StartDate.ToString().PadLeft(11)}|{list[i].StopDate.ToString().PadLeft(11)}|{list[i].AllDay.ToString().PadLeft(7)}|{list[i].Important.ToString().PadLeft(7)}|", ConsoleColor.DarkGray);
                }
            }
            for (int i = 0; i < list.Count(); i++)
            {
                if (orderListTwo[i].Important != true)
                {
                    ConsoleEx.WriteLine($"|{orderListTwo.IndexOf(orderListTwo[i]).ToString().PadLeft(4)}|{orderListTwo[i].Opis.PadLeft(40)}|{orderListTwo[i].StartDate.ToString().PadLeft(19)}|{orderListTwo[i].StopDate.ToString().PadLeft(19)}|{orderListTwo[i].AllDay.ToString().PadLeft(14)}|{orderListTwo[i].Important.ToString().PadLeft(9)}|", ConsoleColor.DarkGray);
                    //ConsoleEx.WriteLine($"|{list.IndexOf(list[i]).ToString().PadLeft(4)}|{list[i].Opis.PadLeft(40)}|{list[i].StartDate.ToString().PadLeft(11)}|{list[i].StopDate.ToString().PadLeft(11)}|{list[i].AllDay.ToString().PadLeft(7)}|{list[i].Important.ToString().PadLeft(7)}|", ConsoleColor.DarkGray);
                }
            }
            ConsoleEx.WriteLine("*--------------------------------------------------------------------------------------------------------------*", ConsoleColor.DarkGray);
        }
        public static void SaveTask(string path)
        {
            if (File.Exists(path))
            {
                listast.Clear();
                for (int j = 0; j < list.Count(); j++)
                {
                    listast.Add($"{list[j].Opis};{list[j].StartDate.ToString()};{list[j].StopDate.ToString()};{list[j].AllDay.ToString()};{list[j].Important.ToString()}");
                }

                File.WriteAllLines(path, listast.ToArray());
                ConsoleEx.WriteLine($"Dane zostały zapisane w pliku {path}", ConsoleColor.Green);
            }
            else
            {
                using (var s = File.Create(@"C:\Users\Admin\Desktop\coders\1_TodoConsoleApp\1_TodoConsoleApp\1_TodoConsoleApp\bin\Debug\Data.txt"))
                    listast.Clear();
                for (int j = 0; j < list.Count(); j++)
                {
                    listast.Add($"{list[j].Opis};{list[j].StartDate.ToString()};{list[j].StopDate.ToString()};{list[j].AllDay.ToString()};{list[j].Important.ToString()}");
                }

                File.WriteAllLines(path, listast.ToArray());
                ConsoleEx.WriteLine($"Dane zostały zapisane w pliku {path}", ConsoleColor.Green);
            }
        }
        public static void LoadTask(string path)
        {
            if (File.Exists(path))
            {
                list.Clear();
                string[] ts = File.ReadAllLines(path);
                if (ts.Length > 0)
                {
                    for (int k = 0; k < ts.Length; k++)
                    {
                        string[] a = ts[k].Split(';');
                        //DateTime b = DateTime.Parse(ts[1]);
                        if (string.IsNullOrWhiteSpace(a[2]))
                        {
                            if (string.IsNullOrWhiteSpace(a[3]))
                            {
                                if (string.IsNullOrWhiteSpace(a[4]))
                                {
                                    list.Add(new TaskModel { Opis = a[0], StartDate = DateTime.Parse(a[1]), StopDate = null, AllDay = null, Important = null });
                                }
                                else
                                {
                                    list.Add(new TaskModel { Opis = a[0], StartDate = DateTime.Parse(a[1]), StopDate = null, AllDay = null, Important = bool.Parse(Validation(a[4])) });
                                }
                            }
                            else
                            {
                                if (string.IsNullOrWhiteSpace(a[4]))
                                {
                                    list.Add(new TaskModel { Opis = a[0], StartDate = DateTime.Parse(a[1]), StopDate = null, AllDay = bool.Parse(Validation(a[3])), Important = null });
                                }
                                else
                                {
                                    list.Add(new TaskModel { Opis = a[0], StartDate = DateTime.Parse(a[1]), StopDate = null, AllDay = bool.Parse(Validation(a[3])), Important = bool.Parse(Validation(a[4])) });
                                }
                            }
                        }
                        else
                        {
                            if (string.IsNullOrWhiteSpace(a[3]))
                            {
                                if (string.IsNullOrWhiteSpace(a[4]))
                                {
                                    list.Add(new TaskModel { Opis = a[0], StartDate = DateTime.Parse(a[1]), StopDate = DateTime.Parse(a[2]), AllDay = null, Important = null });
                                }
                                else
                                {
                                    list.Add(new TaskModel { Opis = a[0], StartDate = DateTime.Parse(a[1]), StopDate = DateTime.Parse(a[2]), AllDay = null, Important = bool.Parse(Validation(a[4])) });
                                }
                            }
                            else
                            {
                                if (string.IsNullOrWhiteSpace(a[4]))
                                {
                                    list.Add(new TaskModel { Opis = a[0], StartDate = DateTime.Parse(a[1]), StopDate = DateTime.Parse(a[2]), AllDay = bool.Parse(Validation(a[3])), Important = null });
                                }
                                else
                                {
                                    list.Add(new TaskModel { Opis = a[0], StartDate = DateTime.Parse(a[1]), StopDate = DateTime.Parse(a[2]), AllDay = bool.Parse(Validation(a[3])), Important = bool.Parse(Validation(a[4])) });
                                }
                            }
                        }
                    }
                    ConsoleEx.WriteLine($"Wczytano dane z pliku {path}", ConsoleColor.Yellow);
                }
                else
                {
                    ConsoleEx.WriteLine("Plik, jest pusty, nie wczytano danych", ConsoleColor.Cyan);
                }
            }
            else
            {
                ConsoleEx.WriteLine("Nie istnieje plik, który możnaby było wczytać", ConsoleColor.DarkCyan);
            }
        }
    }
}



