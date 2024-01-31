using System;
using System.Collections.Generic;
using System.Text;
using UIwpf.Model;

namespace UIwpf.ViewModel
{
    public class MainWindowViewModel : BaseViewModel
    {
        public MainWindowViewModel()
        {
            group = new TheaterChainViewModel(Repository.GetTheaterChain(), this);
        }

        private BaseViewModel group;

        public BaseViewModel Content
        {
            get => group;
            set
            {
                if (group == value) return;
                group = value;
                OnPropertyChanged();
            }
        }
    }
}
