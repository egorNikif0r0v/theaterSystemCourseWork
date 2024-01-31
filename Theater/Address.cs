using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Theater
{
    public class Address
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string PostalCode { get; set; }
        public int House { get; set; }
        public int TheaterId { get; set; }
        public Theaterl Theater { get; set; }

    }
}
