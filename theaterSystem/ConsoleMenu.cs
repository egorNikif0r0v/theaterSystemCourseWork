using System;
using System.Collections.Generic;
using System.Linq;
using QueryService;

namespace theaterSystem
{
    internal class ConsoleMenu
    {
        public static void Menu()
        {
            while (true)
            {
                Console.WriteLine("1) get info\n2) ticket booking\n3) cancellation\n4)exit");
                var temp = Console.ReadLine();
                Console.Write("name theater - > ");
                var nameTheater = Console.ReadLine();
                Console.Write("name performance - > ");
                var namePerformance = Console.ReadLine();
                switch (temp)
                {
                    case "1":
                        RequestProcessing.requestProcessin(new Request() { Request_ = "get info", NamePerformance = namePerformance, NameTheater = nameTheater });
                        break;
                    case "2":

                        Console.Write("place number - > ");
                        try
                        {
                            var placeNumber = Console.ReadLine().Split(',').Select(Int32.Parse).ToList();
                            RequestProcessing.requestProcessin(new Request() { Request_ = "ticket booking", NamePerformance = namePerformance, PlaceNumber = placeNumber, NameTheater = nameTheater });
                        }
                        catch (FormatException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case "3":
                        Console.Write("place number - > ");
                        try
                        {
                            var placeNumber = Console.ReadLine().Split(',').Select(Int32.Parse).ToList();
                            RequestProcessing.requestProcessin(new Request() { Request_ = "cancellation", NamePerformance = namePerformance, PlaceNumber = placeNumber , NameTheater = nameTheater });
                        }
                        catch (FormatException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case "4":
                        Console.WriteLine("exit");
                        return;
                    default:
                        Console.WriteLine("param error");
                        break;
                }
            }
        }
    }
}
