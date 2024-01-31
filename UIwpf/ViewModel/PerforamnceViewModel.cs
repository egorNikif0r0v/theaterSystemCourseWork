using System;
using System.Collections.Generic;
using System.Text;
using Theater;
using System.Windows.Input;
using UIwpf.Model;
using System.Collections.ObjectModel;
using System.Linq;

namespace UIwpf.ViewModel
{
    internal class PerforamnceViewModel : BaseViewModel
    {
        private Performance _perforamance;
        private readonly MainWindowViewModel _mwVM;
        private ObservableCollection<PlaceShortViewModel> _places;
        private PlaceShortViewModel _selectedPlace;

        public string Name
        {
            get => _perforamance.NamePerformance;
            set
            {
                if (_perforamance.NamePerformance == value) return;
                _perforamance.NamePerformance = value;
                OnPropertyChanged();
            }
        }

        public int TotalPlace
        {
            get => _perforamance.TotalPlace;
            set
            {
                if (_perforamance.TotalPlace == value) return;
                _perforamance.TotalPlace = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<PlaceShortViewModel> Places
        {
            get => _places;
            set => _places = value;

        }


        public PerforamnceViewModel(Performance performance, MainWindowViewModel mwVM)
        {
            this._perforamance = performance;
            this._mwVM = mwVM;
            IEnumerable<PlaceShortViewModel> placeVMs =
                from place in performance.Places
                select new PlaceShortViewModel(place);
            _places = new ObservableCollection<PlaceShortViewModel>(placeVMs);
        }

        public string Beginning
        {
            get => _perforamance.BeginningDate;
            set
            {
                if (_perforamance.BeginningDate == value) return;
                _perforamance.BeginningDate = DateTime.Parse(value).ToString();
                OnPropertyChanged();
            }
        }

        public ICommand ToGroup
            => new RelayCommand((_) => ToGroupImpl());

        private void ToGroupImpl()
        {
            _mwVM.Content = new TheaterViewModel(_perforamance.Theater, _mwVM);
        }

        private bool CanShowPlace()
        {
            return _selectedPlace != null;
        }

        public PlaceShortViewModel SelectedPlace
        {
            get => _selectedPlace;
            set
            {
                if (_selectedPlace == value) return;
                _selectedPlace = value;
                OnPropertyChanged();
            }
        }

        public ICommand ToPlace
            => new RelayCommand(
                (_) => ToPlaceImpl(),
                (_) => CanShowPlace());

        private void ToPlaceImpl()
        {
            Place place = _perforamance.Places.First(x => x.Number == _selectedPlace.Numb);
            place.Performance = _perforamance;
            _mwVM.Content = new PlaceViewModel(place, _mwVM);
        }


    }
}
