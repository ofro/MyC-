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
        public string  Bestellnummer { get; set; }
        public string Herstellernummer { get; set; }
        public string Bezeichnung1  { get; set; }
        public string Bezeichnung2  { get; set; }
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

        public ArtikelDatenCollection ReadDataSet(string Data)
        {
            ArtikelDatenCollection dc = new ArtikelDatenCollection();
            string[] separator = new string[] { "|@@|" };
            var result = Data.Split(separator, StringSplitOptions.None).ToList();
            int index = -1;
            result.ForEach(r=>{
                var lineSeparator = new string[] { "@@" };
                List<string> line = r.Split(lineSeparator, StringSplitOptions.None).ToList();
                dc.Add(fillArtikeldaten(line,index++));
            });
            return dc;
        }

        private ArtikelDaten fillArtikeldaten(List<string> d, int id)
        {

            ID = id;
            //Text 
            Artikelnummer = d[0];
            Bestellnummer = d[1];
            Herstellernummer = d[2];
            Bezeichnung1 = d[3];
            Bezeichnung2 = d[4];
            Langtext = d[5];
            Verkaufspreis = Conversion.ToDecimal(d[6],true);
            Einkaufspreis = Conversion.ToDecimal(d[7],true);
            Ersatzartikel = d[8];
            Gruppe = d[9];
            Gewicht = Conversion.ToDecimal(d[10],true);
            MwSt = Conversion.ToDecimal(d[11],true);
            Rabatt = Conversion.ToDecimal(d[12],true);
            Mandant =Conversion.ToInt32(d[13]);
            Erfolgreich = d[14];
            Gesperrt = d[15];
            Error = "";
            //UUID 
            return this;
        }
    }
}
