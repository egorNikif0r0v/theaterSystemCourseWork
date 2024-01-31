using System;
using System.Collections.Generic;
using System.Text;
using Theater;
using DataBase;
using QueryService;
using UIwpf.ViewModel;
using UIwpf.ViewModelResponseWindow;

namespace UIwpf.Model
{
    internal class Repository
    {
        static private ThSy _thsy = new ThSy(
            new List<KeyValuePair<string, Address>>
            {
                new KeyValuePair<string, Address>("Red flambeau", new Address
                {
                    City = "Novosibirsk",
                    District = "Railway",
                    PostalCode = "343435",
                    House = 43
                }),
                new KeyValuePair<string, Address>("Grand Theatre", new Address
                {
                    City = "Moscow",
                    District = "central",
                    PostalCode = "6573345",
                    House = 12
                }),
                new KeyValuePair<string, Address>("novat", new Address
                {
                    City = "Novosibirsk",
                    District = "central",
                    PostalCode = "423523",
                    House = 4
                }),
            });

        static private ResponseRequestWindow _responseWindow =
            new ResponseRequestWindow();
 
        static public ResponseRequestWindow GetResponseWindow()
        {
            return _responseWindow;
        }

        static public IResponseRequest ResponseRequest { get; set; } 
       
        static public ThSy GetTheaterChain()
        {
            return _thsy;
        }
    }
}
