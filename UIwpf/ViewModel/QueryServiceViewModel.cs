using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Theater;
using QueryService;
using System.Collections;
using System.Windows;
using UIwpf.View;
using System.Linq;
using QueryService.Requests;
using UIwpf.ViewModelResponseWindow;
using UIwpf.Model;
using DataBase;

namespace UIwpf.ViewModel
{
    internal class QueryServiceViewModel : BaseViewModel
    {
        bool _IsRadioButtonBoodingBeletChecked;
        public bool IsRadioButtonBoodingBeletChecked 
        {
            get => _IsRadioButtonBoodingBeletChecked;
            set
            {
                if (_IsRadioButtonBoodingBeletChecked == value) return;
                _IsRadioButtonBoodingBeletChecked = value;
                OnPropertyChanged();
            }
        }

        bool _IsRadioButtonCancellationChecked;
        public bool IsRadioButtonCancellationChecked
        {
            get => _IsRadioButtonCancellationChecked;
            set
            {
                if (_IsRadioButtonCancellationChecked == value) return;
                _IsRadioButtonCancellationChecked = value;
                OnPropertyChanged();
            }
        }
        public string NameTheater
        {
            get => _query.NameTheater;
            set
            {
                if (_query.NameTheater == value) return;
                _query.NameTheater = value;
                OnPropertyChanged();
            }
        }

        public string NamePerformance
        {
            get => _query.NamePerformance;
            set
            {
                if (_query.NamePerformance == value) return;
                _query.NamePerformance = value;
                OnPropertyChanged();
            }
        }

        string _placesnumber;
        public string PlaceNumber
        {
            get => _placesnumber;
            set
            {

                try
                {
                    var temp = value.Split(',').Select(Int32.Parse).ToList();
                    if (_query.PlaceNumber == temp) return;
                    _query.PlaceNumber = temp;
                    _placesnumber = value;
                    OnPropertyChanged();
                }
                catch (FormatException ex)
                {
                    return;
                }
            }
        }

        private Request _query;
        private ThSy _theaterChain;
        private readonly MainWindowViewModel _mwVM;

        public QueryServiceViewModel(ThSy theaterChain, MainWindowViewModel mwVM)
        {
            _theaterChain = theaterChain;
            this._mwVM = mwVM;
        }

        public ICommand ToTheaterChain
            => new RelayCommand((_) => ToTheaterChainImpl());

        private void ToTheaterChainImpl()
        {
            Place.Condition condition = default;
            if (_IsRadioButtonBoodingBeletChecked)
            {
                _query.Request_ = "ticket booking";
                Repository.ResponseRequest = BookingBelet.GetResponseRequest(_query, _theaterChain);
                condition = Place.Condition.occupied;
            }
            else if (_IsRadioButtonCancellationChecked)
            {
                _query.Request_ = "cancellation";
                Repository.ResponseRequest =  Cancellation.GetResponseRequest(_query, _theaterChain);
                condition = Place.Condition.free;
            }

            Repository.GetResponseWindow().DataContext = new ResponseWindowViewModel();
            Repository.GetResponseWindow().Show();

            Performance perf = _theaterChain
                .Theaters
                .First(x => x.NameTheater.Equals(Repository.ResponseRequest.NameTheater))
                .Performances
                .First(x => x.NamePerformance.Equals(Repository.ResponseRequest.NamePerformance));

            DBControllerSql.UpdatePlace(perf,
                _query, condition);


            _mwVM.Content = new TheaterChainViewModel(_theaterChain, _mwVM);
        }
    }
}
