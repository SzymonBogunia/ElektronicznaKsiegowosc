﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Ksiegowosc.Model
{
    public class Faktura
    {
        public int IdFaktury { get; set; }
        public int IdKontrahenta { get; set; }
        public string NumerDokumentu { get; set; }
        public DateTime DataWystawienia { get; set; }
        public DateTime DataPlatnosci { get; set; }
        public decimal KwotaNetto { get; set; }
        public decimal StawkaVat { get; set; }
        public decimal KwotaBrutto { get; set; }
        public StatusFaktury Status { get; set; }

        public Kontrahent Kontrahent { get; set; }

        public enum StatusFaktury
        {
            Oplacona,
            Nieopłacona,
            Przedawniona
        }
    }
}
