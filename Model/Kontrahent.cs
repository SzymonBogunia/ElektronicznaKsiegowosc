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
        public string Nip { get; set; }
        public string Adres { get; set; }
        public string Miasto { get; set; }
        public string Kraj { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public TypKontrahenta Typ { get; set; }

        public ICollection<Koszt> Koszty { get; set; }
        public ICollection<Faktura> Faktury { get; set; }

        public enum TypKontrahenta
        {
            Klient,
            Dostawca
        }
    }
}
