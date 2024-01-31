using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Input;
using Theater;
using System.Linq;
using UIwpf.Model;

namespace UIwpf.ViewModel
{
    internal class TheaterViewModel : BaseViewModel
    {
        private Theaterl _theater;
        private readonly MainWindowViewModel _mwVm;
        private ObservableCollection<PerformanceShortViewModel> performances;
        private PerformanceShortViewModel selectedPerformance;

        public TheaterViewModel(Theaterl theater,
            MainWindowViewModel mwVm)
        {
            this._theater = theater;
            this._mwVm = mwVm;
            IEnumerable<PerformanceShortViewModel> performancesVMs =
                from performance in theater.Performances
                select new PerformanceShortViewModel(performance);
            performances = new ObservableCollection<PerformanceShortViewModel>(performancesVMs);
        }

        public string Name
        {
            get => _theater.NameTheater;
            set
            {
                if (_theater.NameTheater == value) return;
                _theater.NameTheater = value;
                OnPropertyChanged();
            }
        }

        public string City
        { 
            get => _theater.address.City;
        }
        public string District
        {
            get => _theater.address.District;
        }
        public string PostalCode
        {
            get => _theater.address.PostalCode;
        }

        public ObservableCollection<PerformanceShortViewModel> Performances
        {
            get => performances;
            set => performances = value;
        }


        public ICommand ShowPerformance
        {
            get
            {
                return new RelayCommand(
                    (_) => ShowStudentImpl(),
                    (_) => CanShowStudent());
            }
        }

        public PerformanceShortViewModel SelectedPerformance
        {
            get => selectedPerformance;
            set
            {
                if (selectedPerformance == value) return;
                selectedPerformance = value;
                OnPropertyChanged();
            }
        }

        private void ShowStudentImpl()
        {
            Performance performance = _theater.Performances.First(x => x.NamePerformance == selectedPerformance.FIO);
            _mwVm.Content = new PerforamnceViewModel(performance, _mwVm);
        }

        

        public ICommand AddPerformanceAndShow
              => new RelayCommand((_) => AddPerformance());

        private void AddPerformance()
        {
            _mwVm.Content = new AddPerformanceFormModel(_theater, _mwVm);
        }

        private bool CanShowStudent()
        {
            return selectedPerformance != null;
        }

        public ICommand ToGroup
           => new RelayCommand((_) => ToGroupImpl());

        private void ToGroupImpl()
        {
            _mwVm.Content = new TheaterChainViewModel(Repository.GetTheaterChain(), _mwVm);
        }

       
    }
}
