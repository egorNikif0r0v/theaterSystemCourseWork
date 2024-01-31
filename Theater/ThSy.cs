using System.Collections.Generic;

namespace Theater
{
    public class ThSy
    {
        public int Id { get; set; }
        public List<Theaterl> Theaters { get; set; } = new List<Theaterl>();
        public string Name { get; set; }

        public ThSy() { }

        public ThSy(List<KeyValuePair<string, Address>> theatersDate)
        {
            foreach (var theater in theatersDate)
            {
                Theaters.Add(new Theaterl(theater));
            }
        }
    }
}