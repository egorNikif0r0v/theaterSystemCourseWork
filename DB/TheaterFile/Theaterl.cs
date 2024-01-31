using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataBase.TheaterFile
{
    public class Theaterl
    {
        public string NameTheater { get; set; }
        [ForeignKey("IdPerformance")]
        public List<Performance> Performances { get; set; }
        public int IdPerformance { get; set; }
        public Address Address_ { get; set; }
        public string PhoneNumber { get; set; }
        [Key]
        public int IdTheater { get; set; }
    }
}
