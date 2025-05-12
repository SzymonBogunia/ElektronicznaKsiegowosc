using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksiegowosc.Model
{
    public class Kontrahent
    {
        public int IdKontrahenta { get; set; }
        public string Nazwa { get; set; }
        public string? Nip { get; set; }
        public int? IdTypu { get; set; }
        public string? Email { get; set; }
        public string? Telefon { get; set; }
        public int? IdAdresu { get; set; }
        public TypKontrahenta? TypKontrahenta { get; set; }
        public Adres? Adres { get; set; }
    }
}
