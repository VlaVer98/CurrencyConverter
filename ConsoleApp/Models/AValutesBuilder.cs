using System;
using System.Collections.Generic;
using System.Text;
using static ConsoleApp.Models.RepositoryValute;

namespace ConsoleApp.Models
{
    internal abstract class AValutesBuilder
    {
        public abstract void GetData();
        public abstract void Convert();
        public abstract RepositoryValute GetValutes();
    }
}
