using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Theater;
using DataBase;

namespace UIwpf.ViewModel
{
    internal class AddPerformanceFormModel : BaseViewModel
    {
        public string NamePerformance
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

        public string BeginningDate
        {
            get => _perforamance.BeginningDate;
            set
            {
                if (_perforamance.BeginningDate == value) return;
                _perforamance.BeginningDate = value;
                OnPropertyChanged();
            }
        }

        public string Condition_
        {
            get => _perforamance.Condition_;
            set
            {
                if (_perforamance.Condition_ == value) return;
                _perforamance.Condition_ = value;
                OnPropertyChanged();
            }
        }

        private Performance _perforamance;
        private Theaterl _theater;
        private readonly MainWindowViewModel _mwVM;

        public AddPerformanceFormModel(Theaterl theater, MainWindowViewModel mwVM)
        {
            //default palces

            this._perforamance = new Performance() 
            {
                Places = new List<Place>() { }, Theater = theater
            };
            _theater = theater;
            this._mwVM = mwVM;
        }

        public ICommand ToGroup
            => new RelayCommand((_) => ToGroupImpl());

        private void ToGroupImpl()
        {
            _theater.AddPerforamnce(_perforamance);
            DBControllerSql.AddPerformance(_perforamance);
            _mwVM.Content = new TheaterViewModel(_perforamance.Theater, _mwVM);
        }
    }
}
