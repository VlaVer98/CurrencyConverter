using CurrencyConverter.Commands;
using CurrencyConverter.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private Converter _Converter;

        #region Views
        private Visibility _ViewDownload = Visibility.Visible;
        public Visibility ViewDownload
        {
            get => _ViewDownload;
            set
            {
                _Title = "Загузка данных";
                _ViewErrorLoading = Visibility.Collapsed;
                _ViewDownload = value;
                OnPropertyChanged("Title");
                OnPropertyChanged("ViewDownload");
                OnPropertyChanged("ViewErrorLoading");
            }
        }

        private Visibility _ViewMain = Visibility.Collapsed;
        public Visibility ViewMain
        {
            get => _ViewMain;
            set
            {
                _Title = "Конвертер валют";
                _ViewDownload = Visibility.Collapsed;
                _ViewSelect1 = Visibility.Collapsed;
                _ViewSelect2 = Visibility.Collapsed;
                _ViewMain = value;
                OnPropertyChanged("Title");
                OnPropertyChanged("ViewDownload");
                OnPropertyChanged("ViewMain");
                OnPropertyChanged("ViewSelect1");
                OnPropertyChanged("ViewSelect2");
            }
        }

        private Visibility _ViewSelect1 = Visibility.Collapsed;
        public Visibility ViewSelect1
        {
            get => _ViewSelect1;
            set
            {
                _Title = "Выбор валют";
                _ViewMain = Visibility.Collapsed;
                _ViewSelect1 = value;
                OnPropertyChanged("Title");
                OnPropertyChanged("ViewMain");
                OnPropertyChanged("ViewSelect1");
            }
        }

        private Visibility _ViewSelect2 = Visibility.Collapsed;
        public Visibility ViewSelect2
        {
            get => _ViewSelect2;
            set
            {
                _Title = "Выбор валют";
                _ViewMain = Visibility.Collapsed;
                _ViewSelect2 = value;
                OnPropertyChanged("Title");
                OnPropertyChanged("ViewMain");
                OnPropertyChanged("ViewSelect2");
            }
        }

        private Visibility _ViewErrorLoading = Visibility.Collapsed;
        public Visibility ViewErrorLoading {
            get => _ViewErrorLoading;
            set
            {
                _Title = "Ошибка загрузки курса валют";
                _ViewDownload = Visibility.Collapsed;
                _ViewErrorLoading = value;
                OnPropertyChanged("Title");
                OnPropertyChanged("ViewDownload");
                OnPropertyChanged("ViewErrorLoading");
            }
        }
        #endregion
        #region Binding properties
        #region Title
        string _Title = "Загрузка данных";
        public string Title
        {
            get => _Title;
            set
            {
                _Title = value;
                OnPropertyChanged("Title");
            }
        }
        #endregion
        #region List Valutes
        private ObservableCollection<Valute> _Valutes;
        public ObservableCollection<Valute> Valutes
        {
            get => _Valutes;
            private set
            {
                _Valutes = value;
                OnPropertyChanged("Valutes");
            }
        }
        #endregion
        #region SelectedValute1
        private Valute _SelectedValute1;
        public Valute SelectedValute1
        {
            get => _SelectedValute1;
            set
            {
                _SelectedValute1 = value;
                _Converter.Valute1 = value;
                ViewMain = Visibility.Visible;
                OnPropertyChanged("SelectedValute1");
                UpdateFieldsOfConverter();
            }
        }
        #endregion
        #region SelectedValue2
        private Valute _SelectedValute2;
        public Valute SelectedValute2
        {
            get => _SelectedValute2;
            set
            {
                _SelectedValute2 = value;
                _Converter.Valute2 = value;
                ViewMain = Visibility.Visible;
                OnPropertyChanged("SelectedValute2");
                UpdateFieldsOfConverter();
            }
        }
        #endregion
        #region Money1
        public string Money1
        {
            get => _Converter?.Money1.ToString("F4");
            set
            {
                if (Decimal.TryParse(value, out decimal result))
                    _Converter.Money1 = result;
                else
                    _Converter.Money1 = 0M;
                OnPropertyChanged("Money1");
                OnPropertyChanged("Money2");
            }
        }
        #endregion
        #region Money2
        public string Money2
        {
            get => _Converter?.Money2.ToString("F4");
            set
            {
                if (Decimal.TryParse(value, out decimal result))
                    _Converter.Money2 = result;
                else
                    _Converter.Money2 = 0M;
                OnPropertyChanged("Money1");
                OnPropertyChanged("Money2");
            }
        }
        #endregion
        #region Valute1
        private string _Valute1;
        public string Valute1
        {
            get => _Converter?.Valute1.CharCode;
            private set
            {
                _Valute1 = value;
                OnPropertyChanged("Valute1");
            }
        }
        #endregion
        #region Valute2
        public string Valute2
        {
            get => _Converter?.Valute2.CharCode;
            private set
            {

            }
        }
        #endregion
        #endregion
        #region Commands
        #region Loading Data
        public ICommand LoadingDataCommand { get; set; }
        private async void LoadingData()
        {
            bool operation = true;
            ViewDownload = Visibility.Visible;

            await Task.Run(() => {
                try
                {
                    var list = new RepositoryValute(new ValutesBuilder()).GetValutes();
                    _Valutes = new ObservableCollection<Valute>(list.Values);
                    _Converter = new Converter(_Valutes[0], _Valutes[1]);
                }
                catch (Exception)
                {
                    operation = false;
                }
            });

            if (operation)
            {
                ViewMain = Visibility.Visible;
                UpdateFieldsOfConverter();
                SelectedValute1 = _Converter.Valute1;
                SelectedValute2 = _Converter.Valute2;
                OnPropertyChanged("Valutes");
            }
            else
            {
                ViewErrorLoading = Visibility.Visible;
            }
        }
        #endregion
        #region Show view of valute1 selection
        public ICommand ShowViewOfValute1SelectionCommand { get; set; }
        private void Valute1Selection()
        {
            ViewSelect1 = Visibility.Visible;
        }
        #endregion
        #region Show view of valute2 selection
        public ICommand ShowViewOfValute2SelectionCommand { get; set; }
        private void Valute2Selection()
        {
            ViewSelect2 = Visibility.Visible;
        }
        #endregion
        #region Swap Valute
        public ICommand SwapValuteCommand { get; set; }
        private void SwapValute()
        {
            _Converter.SwapValute();
            UpdateFieldsOfConverter();
        }
        #endregion
        #endregion

        public MainPageViewModel()
        {
            LoadingDataCommand = new RelayCommand(LoadingData);
            ShowViewOfValute1SelectionCommand = new RelayCommand(Valute1Selection);
            ShowViewOfValute2SelectionCommand = new RelayCommand(Valute2Selection);
            SwapValuteCommand = new RelayCommand(SwapValute);
        }

        private void UpdateFieldsOfConverter()
        {
            OnPropertyChanged("Money1");
            OnPropertyChanged("Money2");
            OnPropertyChanged("Valute1");
            OnPropertyChanged("Valute2");
        }
    }
}
