using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Theater;

namespace UIwpf.ViewModel
{
    internal class PlaceShortViewModel
    {
        private Place _place;

        public PlaceShortViewModel(Place place)
        {
            _place = place;
        }

        public int Numb
        {
            get => _place.Number;
        }
        public string Condition
        {
            get => _place.Condition_;
        }
    }
}
