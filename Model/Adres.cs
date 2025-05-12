using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksiegowosc.Model
{
    public class Adres
    {
        public int IdAdresu { get; set; }
        public string? Ulica { get; set; }
        public string? Miasto { get; set; }
        public string? Kod { get; set; }
        public string? Kraj { get; set; }
    }
}
