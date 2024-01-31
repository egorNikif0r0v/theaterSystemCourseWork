using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;


namespace Theater
{
    public class Performance
    {

        public string NamePerformance { get; set; }

        public enum Condition : byte
        {
            expected,
            inProgress,
            finished
        }

        internal string[] _condition = new string[3] { "expected", "inProgress", "finished" };

        public int Id { get; set; }
        public int TotalPlace { get; set; }
        public string Condition_ { get; set; }
        public string BeginningDate { get; set; }
        public int TheaterId { get; set; }
        public Theaterl Theater { get; set; }
        public List<Place> Places { get; set; }


        public Performance() { }
        public Performance(string name, Condition? condition, List<Place>[] places, DateTime? beginning, Theaterl theater)
        {
            NamePerformance = name;
            BeginningDate = beginning.ToString();
            Condition_ = _condition[(int)condition];
            Places = null;
            Theater = theater;
        }

        public Performance(string name, Condition? condition, List<Place> places, DateTime? beginning, Theaterl theater)
        {
            NamePerformance = name;
            BeginningDate = beginning.ToString();
            Condition_ = _condition[(int)condition];
            Places = places;
            Theater = theater;
            TotalPlace = places.Count;
        }


        public bool IsPlaceFree(string conditionOfPlace)
        {
            return conditionOfPlace == "free" ?  true : false;
        }

        internal string GetInfo() { return ""; }
    }
}
