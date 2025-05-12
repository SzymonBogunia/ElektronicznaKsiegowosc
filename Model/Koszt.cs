using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksiegowosc.Model
{
    public class Koszt
    {
        public int IdKosztu { get; set; }
        public int? IdKontrahenta { get; set; }
        public string? NumerDokumentu { get; set; }
        public string DataWystawienia { get; set; }
        public string? Opis { get; set; }
        public decimal KwotaNetto { get; set; }
        public int? IdStawki { get; set; }
        public int? IdKategorii { get; set; }
        public Kontrahent? Kontrahent { get; set; }
        public StawkaVat? StawkaVat { get; set; }
        public Kategoria? Kategoria { get; set; }
    }
}
