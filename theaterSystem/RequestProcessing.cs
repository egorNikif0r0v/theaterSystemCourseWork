using System;
using Theater;
using QueryService;
using QueryService.Requests;
using DataBase;


namespace theaterSystem
{
    internal class RequestProcessing
    {


        static public void requestProcessin(Request req)
        {
            switch (req.Request_)
            {
                case "get info":
                    GetInfo.GetResponseRequest(req, DBController.DataBase);
                    break;
                case "ticket booking":
                    BookingBelet.GetResponseRequest(req, DBController.DataBase);
                    DBController.UpgradeDataBase();
                    break;
                case "cancellation":
                    Cancellation.GetResponseRequest(req, DBController.DataBase);
                    DBController.UpgradeDataBase();
                    break;
                default:
                    Console.WriteLine("request not recognized");
                    break;
            }
        }
    }
}
