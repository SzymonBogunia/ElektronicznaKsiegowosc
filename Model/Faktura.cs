using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Ksiegowosc.Model
{
    public partial class Faktura
    {
        public int IdFaktury { get; set; }
        public string NumerFaktury { get; set; }
        public string? NumerDokumentu { get; set; }
        public string DataWystawienia { get; set; }
        public string? DataPlatnosci { get; set; }
        public decimal KwotaNetto { get; set; }
        public int? IdKontrahenta { get; set; }
        public int? IdStawki { get; set; }
        public int? IdStatusu { get; set; }
        public Kontrahent? Kontrahent { get; set; }
        public StawkaVat? StawkaVat { get; set; }
        public StatusFaktury? StatusFaktury { get; set; }
    }
}
