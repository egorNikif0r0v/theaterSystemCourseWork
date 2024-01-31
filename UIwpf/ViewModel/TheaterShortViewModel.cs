using System;
using System.Collections.Generic;
using System.Text;
using Theater;

namespace UIwpf.ViewModel
{
    internal class TheaterShortViewModel
    {
        private Theaterl _theater;

        public TheaterShortViewModel(Theaterl theater)
        {
            this._theater = theater;
        }

        public string FIO
        {
            get => _theater.NameTheater;
        }
    }
}
