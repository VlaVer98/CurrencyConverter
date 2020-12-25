using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace CurrencyConverter.ViewModels
{
    class MainPageViewModel : BaseViewModel
    {
        string _Title = "Загрузка данных";
        public string Title {
            get => _Title;
            set
            {
                _Title = value;
                OnPropertyChanged("Title");
            }
        }

        private Visibility _ViewDownload = Visibility.Visible;
        public Visibility ViewDownload { 
            get => _ViewDownload; 
            set {
                _ViewDownload = value;
                OnPropertyChanged("ViewDownload");
            } 
        }

        private Visibility _ViewMain = Visibility.Collapsed;
        public Visibility ViewMain { 
            get => _ViewMain; 
            set
            {
                _ViewMain = value;
                OnPropertyChanged("ViewMain");
            }
        }

        private Visibility _ViewSelect = Visibility.Collapsed;
        public Visibility ViewSelect { 
            get => _ViewSelect;
            set
            {
                _ViewSelect = value;
                OnPropertyChanged("ViewSelect");
            } 
        }
    }
}
