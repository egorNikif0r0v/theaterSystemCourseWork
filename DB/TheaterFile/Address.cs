using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataBase.TheaterFile
{
    public class Address
    {
        public string City { get; set; }
        public string District{ get; set; }
        public string PostalCode { get; set; }
        public int House { get; set; }
        [ForeignKey("IdTheaters")]
        public Theaterl Theater { get; set; }
        public int IdTheater { get; set; }
        [Key]
        public int IdAdress { get; set; }
    }
}
