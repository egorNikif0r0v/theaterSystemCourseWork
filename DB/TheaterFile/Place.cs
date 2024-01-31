using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataBase.TheaterFile
{
    public class Place
    {
        public enum Condition : byte
        {
            occupied,
            free
        }
        public enum Position : byte
        {
            groundFloor,
            highGroundFloor,
            lodge,
            centralLodge
        }

        private string[] _condition = new string[]
        {
            "occupied",
            "free"
        };
        private string[] _position = new string[] 
        {
            "groundFloor",
            "highGroundFloor",
            "lodge",
            "centralLodge"
        };
        private int[] _cost = new int[] { 300, 500, 1000, 1500 };

        public string Condition_ { get; set; }
        public int Number { get;  set; }
        public string Position_ { get;  set; }
        public int Cost { get; set; }
        [Key]
        public int IdPlace { get; set; }
        public int IdPerformance { get; set; }
        public Performance Performances { get; set; }

        public Place() {}
    }
}
