using Microsoft.EntityFrameworkCore;
using QueryService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using Theater;

namespace DataBase
{
    public class DBControllerSql
    {

        static public void LoadTheaterCHain(ThSy theaterChain, string dbName = "My")
        {
            Task.Run(() =>
            {
                using (Context db = new Context(dbName))
                {
                    db.TheaterChain.AddAsync(theaterChain);
                    foreach (var theater in theaterChain.Theaters)
                    {
                        db.Theater.AddAsync(theater);
                        db.Adress.AddAsync(theater.address);
                        foreach (var perforemnace in theater.Performances)
                        {
                            db.Performance.AddAsync(perforemnace);
                            foreach (var place in perforemnace.Places)
                            {
                                db.Place.AddAsync(place);
                            }
                        }
                    }
                    db.SaveChangesAsync();
                }
            });
        }

        static public void AddPerformance(Performance per, string dbName = "My")
        {
            using (Context db = new Context(dbName))
            {
                db.Update(per);
                db.SaveChangesAsync();
            }
        }

        static public void ClearDB(string dbName = "My")
        {
                using (Context db = new Context(dbName))
                {
                    db.TheaterChain.Clear();
                    db.Theater.Clear();
                    db.Adress.Clear();
                    db.Performance.Clear();
                    db.Place.Clear();
                    db.SaveChanges();
                }
        }

        static public List<ThSy> UnloadTheaterChain(string dbName = "My")
        {
            using (Context db = new Context(dbName))
            {
                var TheaterChain = db.TheaterChain
                    .Include(p => p.Theaters)
                    .ToList();
                return TheaterChain;
            }
        }

        static public Performance UnloadPerformance(string namePerformance, Theaterl theater, string dbName = "My")
        {
            using (Context db = new Context(dbName))
            {
                var performance = db.Performance
                    .Include(x => x.Places)
                    .Where(x => x.Theater == theater)
                    .First(x => x.NamePerformance == namePerformance);
                return performance;
            }
        }

        static public void UpdatePlace(Performance performance,
            Request request,
            Place.Condition condition,
            string dbName = "My")
        {
            using (Context db = new Context(dbName))
            {
                Place place;
                foreach (var numb in request.PlaceNumber)
                {
                    place = db.Place
                   .First(x => x.Number.Equals(numb));
                    place.ChangeCondition(condition);
                }
                db.SaveChangesAsync();
            }
        }

        static public Theaterl UnloadTheater(string nameTheater, string dbName = "My")
        {
            using (Context db = new Context(dbName))
            {
                var theater = db.Theater
                    .Include(x => x.address)
                    .Include(x => x.Performances)
                    .First(x => x.NameTheater == nameTheater);
                return theater;
            }
        }
    }
}
