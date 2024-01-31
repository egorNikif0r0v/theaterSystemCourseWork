using System;
using System.Collections.Generic;
using QueryService;
using DataBase;
using QueryService.Requests;
using Theater;
using QueryService.Exaption;

namespace theaterSystem
{
    internal class Program
    {
        static internal string DATABASEPATH = "Server/dataBase.json";
        static private List<string> _THEATERNAMES = new List<string>() 
        {
            "Name 1",
            "Name 2",
            "Name 3",
        };

       
        static int Main(string[] args)
        {

            DBControllerSql.ClearDB();

            /*
            //DBController.GenDataBase(_THEATERNAMES);

            try
            {
                Request request = DBController.GetRequest(CommandLineProcessing.GetCommandLineData(args).RequestPath);
                RequestProcessing.requestProcessin(request);
            }
            catch (CommandLineExaption ex)
            {
                Console.WriteLine($"{ex.Message}");
                return 1;
            }
            catch (Newtonsoft.Json.JsonReaderException ex)
            {
                Console.WriteLine($"{ex.Message}");
                return 1;
            }
            catch (AggregateException ex)
            {
                Console.WriteLine($"{ex.Message}");
                return 1;
            }

            ConsoleMenu.Menu();
            */
            return 0;
        }
        
    }
}
