using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;


namespace DataBase.TheaterFile
{
    public class Performance
    {

        public string NamePerformance { get;  set; }

        public enum Condition : byte
        {
            expected,
            inProgress,
            finished
        }

        internal string[] _condition = new string[3] { "expected", "inProgress", "finished" };
        [Key]
        public int IdPerformance { get; set; }
        public int IdTheater { get; set; }
        public int IdPlace { get; set; }
        [ForeignKey("IdPlace")]
        public List<Place> PlacesList { get; set; }
        public int TotalPlace { get; set; } = 50;
        public string Condition_ { get; set; }
        public string BeginningDate { get; set; }
        public Theaterl Theater { get; set; }
       
    }
}
