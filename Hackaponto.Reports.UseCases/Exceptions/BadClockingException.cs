using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackaponto.Reports.UseCases.Exceptions
{
    internal class BadClockingException : Exception
    {
        public BadClockingException() : base("Há inconformidades com sua marcações de ponto. Verifique se há marcações ímpares ou desordenação e tente novamente.") { }
        public BadClockingException(string message) : base(message) { }
    }
}
