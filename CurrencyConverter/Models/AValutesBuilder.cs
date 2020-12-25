
namespace CurrencyConverter.Models
{
    internal abstract class AValutesBuilder
    {
        public abstract void GetData();
        public abstract void Convert();
        public abstract RepositoryValute GetValutes();
    }
}
