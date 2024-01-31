using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UIwpf.Model;
using UIwpf.ViewModel;

namespace UIwpf.ViewModelResponseWindow
{
    internal class ResponseWindowViewModel : BaseViewModel
    {
        public ResponseWindowViewModel()
        {
            _response = new ResponseViewModel(Repository.ResponseRequest, this);
        }

        private ResponseViewModel _response;

        public ResponseViewModel Content
        {
            get => _response;
            set
            {
                if (_response == value) return;
                _response = value;
                OnPropertyChanged();
            }
        }
    }
}