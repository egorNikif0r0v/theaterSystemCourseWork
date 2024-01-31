using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Theater;
using System.Linq;
using DataBase;

namespace UIwpf.ViewModel
{
    internal class TheaterChainViewModel : BaseViewModel
    {
        private ThSy _theaterChain;
        private readonly MainWindowViewModel _mwVm;
        private ObservableCollection<TheaterShortViewModel> _theaters;
        private TheaterShortViewModel _selectedTheater;

        public TheaterChainViewModel(ThSy theaterChain,
            MainWindowViewModel mwVm)
        {
            this._theaterChain = theaterChain;
            this._mwVm = mwVm;
            IEnumerable<TheaterShortViewModel> performancesVMs =
                from theater in theaterChain.Theaters
                select new TheaterShortViewModel(theater);
            _theaters = new ObservableCollection<TheaterShortViewModel>(performancesVMs);
        }

        public string Name
        {
            get => _theaterChain.Name;
        }
        public ObservableCollection<TheaterShortViewModel> Theaters
        {
            get => _theaters;
            set => _theaters = value;
        }


        public ICommand ShowTheater
        {
            get
            {
                return new RelayCommand(
                    (_) => ShowStudentImpl(),
                    (_) => CanShowStudent());
            }
        }

        public TheaterShortViewModel SelectedTheater
        {
            get => _selectedTheater;
            set
            {
                if (_selectedTheater == value) return;
                _selectedTheater = value;
                OnPropertyChanged();
            }
        }

        private void ShowStudentImpl()
        {
            Theaterl theater = _theaterChain.Theaters.First(x => x.NameTheater == _selectedTheater.FIO);
            theater.ThSy = _theaterChain;
            _mwVm.Content = new TheaterViewModel(theater, _mwVm);
        }

        public ICommand ToQueryService
        {
            get
            {
                return new RelayCommand(
                        (_) => ToQueryServiceImpl());
            }
        }

        private void ToQueryServiceImpl()
        {
            _mwVm.Content = new QueryServiceViewModel(_theaterChain, _mwVm);
        }

        private bool CanShowStudent()
        {
            return _selectedTheater != null;
        }

        public ICommand UpdateDB
        {
            get
            {
                return new RelayCommand(
                        (_) => UpdateDBImpl());
            }
        }
        private void UpdateDBImpl()
        {
            DBControllerSql.LoadTheaterCHain(_theaterChain);
        }


        public ICommand ClearDB
        {
            get
            {
                return new RelayCommand(
                        (_) => ClearDBImpl());
            }
        }
        private void ClearDBImpl()
        {
            DBControllerSql.ClearDB();
        }

    }
}
