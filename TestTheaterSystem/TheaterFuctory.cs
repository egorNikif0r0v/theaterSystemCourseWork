using DataBase;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Xml.Linq;
using Theater;
using static Theater.Performance;
using static Theater.Place;

namespace TestTheaterSystem
{
    internal class TheaterFuctory
    {
        internal class SqlServer
        {
            private Context _context;

            public SqlServer(Context context)
            {
                _context = context;
            }

            public SqlServer WithTheaterChain(ThSy theaterChain)
            {
                _context.TheaterChain.Add(theaterChain);
                return this;
            }
            public SqlServer WhithAdress(Address address)
            {
                _context.Adress.Add(address);
                return this;
            }
            public SqlServer WhithPlace(Place place)
            {
                _context.Place.Add(place);
                return this;
            }
            public SqlServer WhithPerformance(Performance performance)
            {
                _context.Performance.Add(performance);
                return this;
            }
            public SqlServer WhithTheater(Theaterl theater)
            {
                _context.Theater.Add(theater);
                return this;
            }

            public void Build()
            {
                _context.SaveChanges();
            }
        }

        internal class JsonServer
        {
            private Performance _performance;
            private Place _place;
            private Theaterl _theater;
            private string _theaterName;

            public ThSy TheaterSystem { get; set; }


            public ThSy GetTheaterSystem(string name)
            {
                var theaterSystem = new ThSy(new List<KeyValuePair<string, Address>>
            {
                new KeyValuePair<string, Address>(name, null)
            });

                return theaterSystem;
            }

            public JsonServer WithPlace(int number, Place.Position position, Place.Condition condition)
            {
                _place = new Place(number, position, condition);
                return this;
            }
            public JsonServer WithPerformance(string name, Performance.Condition condition)
            {
                List<Place> places = new List<Place> { _place };
                _performance = new Performance(name, condition, places, null, null);

                return this;
            }

            public JsonServer WithTheater(string name)
            {
                _theaterName = name;
                return this;
            }

            public void Build()
            {
                _theater = new Theaterl(_theaterName, new List<Performance>() { _performance });
                TheaterSystem = new ThSy();
                TheaterSystem.Theaters.Add(_theater);
            }
        }
    }
}
