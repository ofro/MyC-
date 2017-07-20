using Sagede.Shared.RealTimeData.Common;
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
        /// <summary>
        /// returns a List of Artikeldaten
        /// </summary>
        /// <param name="Data"></param>
        /// <returns></returns>
        public static ArtikelDatenCollection ReadDataSet(string Data)
        {
            ArtikelDatenCollection dc = new ArtikelDatenCollection();
            string[] separator = new string[] { "|@@|" };
            var result = Data.Split(separator, StringSplitOptions.None).ToList(); 
            int index = 0;
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
            //ds.Mandant = Conversion.ToInt32(d[13]);
            //ds.Erfolgreich = d[14];
            ds.Gesperrt = d[13];
            ds.Error = "";
            //UUID 
            return ds;
        }

        public static RowSet FillMdeImportdaten(ArtikelDatenCollection dc)
        {
            RowSet rowSet = new RowSet();
            dc.ForEach(d =>
            {
                Row row = new Row();
                if (string.IsNullOrEmpty(row.UuidValue))
                {
                    row.UuidValue = Guid.NewGuid().ToString();
                }
                row.Fill("ID", d.ID);row.Fill("Artikelnummer", d.Artikelnummer);
                row.Fill("Bestellnummer", d.Bestellnummer);  row.Fill("Bezeichnung1", d.Bezeichnung1); row.Fill("Bezeichnung2", d.Bezeichnung2);
                row.Fill("Einkaufspreis", d.Einkaufspreis); row.Fill("Ersatzartikel", d.Ersatzartikel);
                row.Fill("Gesperrt", d.Gesperrt); row.Fill("Gewicht", d.Gewicht); row.Fill("Gruppe", d.Gruppe);
                row.Fill("Herstellernummer", d.Herstellernummer); row.Fill("Verkaufspreis", d.Verkaufspreis);
                row.Fill("Langtext", d.Langtext); row.Fill("MwSt", d.MwSt); row.Fill("Rabatt", d.Rabatt); row.Fill("Text", d.Text);
                rowSet.Add(row);
            });

            return rowSet;
        }
    }
}
