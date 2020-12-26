using CurrencyConverter.Commands;
using CurrencyConverter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml;
using static CurrencyConverter.Models.RepositoryValute;

namespace CurrencyConverter.ViewModels
{
    class MainPageViewModel : BaseViewModel
    {
        Dictionary<string, Valute> valutes;
        Converter converter;

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
                _Title = "Загузка данных";
                _ViewMain = Visibility.Collapsed;
                _ViewSelect = Visibility.Collapsed;
                _ViewDownload = value;
                OnPropertyChanged("Title");
                OnPropertyChanged("ViewDownload");
                OnPropertyChanged("ViewMain");
                OnPropertyChanged("ViewSelect");
            } 
        }

        private Visibility _ViewMain = Visibility.Collapsed;
        public Visibility ViewMain { 
            get => _ViewMain; 
            set
            {
                _Title = "Конвертер валют";
                _ViewDownload = Visibility.Collapsed;
                _ViewSelect = Visibility.Collapsed;
                _ViewMain = value;
                OnPropertyChanged("Title");
                OnPropertyChanged("ViewDownload");
                OnPropertyChanged("ViewMain");
                OnPropertyChanged("ViewSelect");
            }
        }

        private Visibility _ViewSelect = Visibility.Collapsed;
        public Visibility ViewSelect { 
            get => _ViewSelect;
            set
            {
                _Title = "Выбор валют";
                _ViewDownload = Visibility.Collapsed;
                _ViewMain = Visibility.Collapsed;
                _ViewSelect = value;
                OnPropertyChanged("Title");
                OnPropertyChanged("ViewDownload");
                OnPropertyChanged("ViewMain");
                OnPropertyChanged("ViewSelect");
            } 
        }
        public ICommand LoadedCommand { get; set; }

        public MainPageViewModel()
        {
            LoadedCommand = new RelayCommand(Loaded);
        }
        private async void Loaded()
        {
            bool operation = true;

            await Task.Run(() => {
                try
                {
                    valutes = new RepositoryValute(new ValutesBuilder()).GetValutes();
                    converter = new Converter(valutes["USD"], valutes["EUR"]);
                }
                catch (Exception) {
                    operation = false;
                }
            });

            if (operation)
            {
                ViewMain = Visibility.Visible;
            }
            else
            {
                //TODO вид ошибки
            }
        }
    }
}
