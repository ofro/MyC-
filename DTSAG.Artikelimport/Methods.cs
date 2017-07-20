using Sagede.Shared.RealTimeData.Common.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTSAG.Artikelimport
{
    public class Methods
    {
        public static ArtikelDatenCollection ReadDataSet(string Data)
        {
            ArtikelDatenCollection dc = new ArtikelDatenCollection();
            string[] separator = new string[] { "|@@|" };
            var result = Data.Split(separator, StringSplitOptions.None).ToList();
            int index = -1;
            result.ForEach(r =>
            {
                var lineSeparator = new string[] { "@@" };
                List<string> line = r.Split(lineSeparator, StringSplitOptions.None).ToList();
                dc.Add(fillArtikeldaten(line, index++));
            });
            return dc;
        }

        private static ArtikelDaten fillArtikeldaten(List<string> d, int id)
        {
            ArtikelDaten ds = new ArtikelDaten();
            ds.ID = id;
            //Text 
            ds.Artikelnummer = d[0];
            ds.Bestellnummer = d[1];
            ds.Herstellernummer = d[2];
            ds.Bezeichnung1 = d[3];
            ds.Bezeichnung2 = d[4];
            ds.Langtext = d[5];
            ds.Verkaufspreis = Conversion.ToDecimal(d[6], true);
            ds.Einkaufspreis = Conversion.ToDecimal(d[7], true);
            ds.Ersatzartikel = d[8];
            ds.Gruppe = d[9];
            ds.Gewicht = Conversion.ToDecimal(d[10], true);
            ds.MwSt = Conversion.ToDecimal(d[11], true);
            ds.Rabatt = Conversion.ToDecimal(d[12], true);
            ds.Mandant = Conversion.ToInt32(d[13]);
            ds.Erfolgreich = d[14];
            ds.Gesperrt = d[15];
            ds.Error = "";
            //UUID 
            return ds;
        }
    }
}
