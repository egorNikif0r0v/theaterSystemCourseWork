using System;
using System.Collections.Generic;
using DataBase.Converters;
using Theater;
using QueryService;

namespace DataBase
{
    public class DBController
    {
        static private string _dataBasePath = "Server/dataBase.json";

        static private ConverterJson _converter = new ConverterJson();

        static public ThSy DataBase { get; set; } = _converter.Unload<ThSy>(_dataBasePath);

        static public void UpgradeDataBase()
        {
            _converter.Load(_dataBasePath, DataBase);
        }
        static public void GenDataBase(List<string> theaterNames)
        {
            _converter.Load(_dataBasePath, new ThSy(null));
        }

        static public Request GetRequest(string requestPath)
        {
            return _converter.Unload<Request>(requestPath);
        }

        static public void UpgradeLog()
        {
        }
    }
}
