using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Theater;

namespace UIwpf.ViewModel
{
    internal class PlaceViewModel : BaseViewModel
    {
        private Place _place;
        private readonly MainWindowViewModel _mwVM;

        public string Condition_ 
        {
            get => _place.Condition_;
        }
        public int Number 
        {
            get => _place.Number;
        }
        public string Position_ 
        {
            get => _place.Position_;
        }
        public int Cost 
        {
            get => _place.Cost;
        }
        public PlaceViewModel(Place place, MainWindowViewModel mwVM)
        {
            _place = place;
            _mwVM = mwVM;
        }
        public ICommand ToPerformance
            => new RelayCommand((_) => ToPerformanceImpl());

        private void ToPerformanceImpl()
        {
            _mwVM.Content = new PerforamnceViewModel(_place.Performance, _mwVM);
        }
    }
}
