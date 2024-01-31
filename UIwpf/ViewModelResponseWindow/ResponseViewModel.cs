using QueryService;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using Theater;
using UIwpf.Model;
using UIwpf.ViewModel;

namespace UIwpf.ViewModelResponseWindow
{
    internal class ResponseViewModel
    {
        static private IResponseRequest _responseRequest;
        private readonly ResponseWindowViewModel _mwVm;

        public int Id { get => _responseRequest.Id; }
        public IResponseRequest.Action_ Action { get => _responseRequest.Action; }
        public string NameTheater { get => _responseRequest.NameTheater; }
        public string NamePerformance { get => _responseRequest.NamePerformance; }
        public string PlaceNumber { get => String.Join(',', _responseRequest.PlaceNumber); }
          

        public ResponseViewModel(IResponseRequest responseRequest,
            ResponseWindowViewModel mwVm)
        {
            _responseRequest = responseRequest;
            _mwVm = mwVm;
        }



    }
}
