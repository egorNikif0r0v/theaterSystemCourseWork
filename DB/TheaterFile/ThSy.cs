using System.Collections.Generic;

namespace DataBase.TheaterFile
{
    public class ThSy
    {
        public List<Theaterl> Theaters { get;  set; } = new List<Theaterl>();

        public string Name { get => "TheaterChain"; set { } }
        public int ThSyId { get; set; }
        public ThSy() { }
    }
}