using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Theater
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


        public int Id { get; set; }
        public string Condition_ { get; set; }
        public int Number { get; set; }
        public string Position_ { get; set; }
        public int Cost { get; set; }
        public int PerformanceId { get; set; }
        public Performance Performance { get; set; }

        public Place() {}
        public Place(int number_, Position? position__, Condition condition)
        {
            Number = number_;
            if (position__ == null) Position_ = "";
            else 
            {
                Position_ = _position?[(int)position__];
                Cost = _cost[(int)position__];
            }

            Condition_ = _condition[(int)condition];
        }

        public void ChangeCondition(Condition condition)
        {
            Condition_ = _condition[(byte)condition];
        }

    }
}
