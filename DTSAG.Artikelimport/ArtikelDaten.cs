using Sagede.Shared.RealTimeData.Common.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTSAG.Artikelimport
{
    public class ArtikelDatenCollection : List<ArtikelDaten>
    {
    }
    public class ArtikelDaten
    {
        public int ID { get; set; }
        public string Text { get; set; } //die Daten vom Client Semmikolon separiert
        public string Artikelnummer { get; set; }
        public string Bestellnummer { get; set; }
        public string Herstellernummer { get; set; }
        public string Bezeichnung1 { get; set; }
        public string Bezeichnung2 { get; set; }
        public string Langtext { get; set; }
        public decimal Verkaufspreis { get; set; }
        public decimal Einkaufspreis { get; set; }
        public string Ersatzartikel { get; set; }
        public string Gruppe { get; set; }
        public decimal Gewicht { get; set; }
        public decimal MwSt { get; set; }
        public decimal Rabatt { get; set; }
        public int Mandant { get; set; }
        public string Erfolgreich { get; set; }
        public string Gesperrt { get; set; }
        public string Error { get; set; }
        public string UUID { get; set; }
    }

}

