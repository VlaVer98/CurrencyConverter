using static CurrencyConverter.Models.RepositoryValute;

namespace CurrencyConverter.Models
{
    internal class Converter
    {
        private decimal _Money1;
        public decimal Money1 {
            get => _Money1;
            set
            {
                if(value > 0)
                {
                    _Money1 = value;
                    RecountValute1();
                }
            }
        }

        private decimal _Money2;
        public decimal Money2
        {
            get => _Money2;
            set
            {
                if (value > 0)
                {
                    _Money2 = value;
                    RecountValute2();
                }
            }
        }

        private Valute _Valute1;
        public Valute Valute1 {
            get => _Valute1;
            set
            {
                if(value != null)
                {
                    _Valute1 = value;
                    RecountValute2();
                }
            }
        }

        private Valute _Valute2;
        public Valute Valute2
        {
            get => _Valute2;
            set
            {
                if (value != null)
                {
                    _Valute2 = value;
                    RecountValute1();
                }
            }
        }

        public Converter(Valute v1, Valute v2)
        {
            _Valute1 = v1;
            _Valute2 = v2;
            _Money1 = 0;
            _Money2 = 0;
        }

        private void RecountValute1()
        {
            decimal koef = Valute1.Value / Valute2.Value;
            _Money2 = Money1 * koef;
        }
        private void RecountValute2()
        {
            decimal koef = Valute2.Value / Valute1.Value;
            _Money1 = Money2 * koef;
        }

    }
}
