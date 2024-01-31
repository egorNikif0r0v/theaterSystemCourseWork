using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Theater
{
    public class Theaterl
    {
        public string PhoneNumber { get; set; }
        public int Id { get; set; }
        public string NameTheater { get; set; }
        public int ThSyId { get; set; }
        public ThSy ThSy { get; set; }
        public List<Performance> Performances { get; set; }
        public Address address { get; set; }

        static private List<Place>[] _places;
        static private List<Place> _placesL;

        public Theaterl(KeyValuePair<string, Address> theaterDate)
        {
            NameTheater = theaterDate.Key;
            Performances = new List<Performance>();
            _placesL = new List<Place>();


            for (int _ = 1; _ <= 30; _++)
            {
                if(_ <= 10)
                    _placesL.Add(new Place(_, Place.Position.groundFloor, Place.Condition.free));
                else if(_ <= 15)
                    _placesL.Add(new Place(_, Place.Position.highGroundFloor, Place.Condition.free));
                else if(_ <= 25)
                    _placesL.Add(new Place(_, Place.Position.lodge, Place.Condition.free));
                else if(_ <= 30)
                    _placesL.Add(new Place(_, Place.Position.centralLodge, Place.Condition.free));

            }
            /*
        for (int _ = 1; _ <= 30; _++)
        {
            _places[(int)Place.Position.groundFloor].Add(new Place(_, Place.Position.groundFloor, Place.Condition.free));
            if (_ <= 10) _places[(int)Place.Position.highGroundFloor].Add(new Place(_ + 30, Place.Position.highGroundFloor, Place.Condition.free));
            if (_ <= 5) _places[(int)Place.Position.lodge].Add(new Place(_ + 40, Place.Position.lodge, Place.Condition.free));
            if (_ <= 5) _places[(int)Place.Position.centralLodge].Add(new Place(_ + 45, Place.Position.centralLodge, Place.Condition.free));
        }
            */

            Performances.Add(new Performance("Bohemia", Performance.Condition.expected, _placesL, new DateTime(2022, 10, 20, 18, 30, 00), this));
            Performances.Add(new Performance("Aida", Performance.Condition.expected, _placesL, new DateTime(2022, 11, 11, 19, 30, 00), this));
            Performances.Add(new Performance("Eugene Onegin", Performance.Condition.finished, _placesL, new DateTime(2022, 9, 01, 19, 00, 00), this));
            Performances.Add(new Performance("Iolanthe", Performance.Condition.inProgress, _placesL, DateTime.Now, this));
            address = theaterDate.Value;
        }
        public Theaterl() { }
        public Theaterl(List<Performance> performances)
        {
            Performances = performances;
        }
        public Theaterl(string name, List<Performance> performances)
        {
            NameTheater = name;
            Performances = performances;
        }

        public void AddPerforamnce(Performance performance)
        {
            Performances.Add(performance);
        }

        public bool IsNotPerformanceCompleted(string condition)
        {
            return condition != "finished" ? true : false;
        }
    }
}
