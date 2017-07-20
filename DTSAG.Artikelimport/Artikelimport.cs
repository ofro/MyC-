using Sagede.OfficeLine.Shared.RealTimeData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sagede.Core.Data;
using Sagede.Shared.RealTimeData.Common;
using Sagede.OfficeLine.Data;
using Sagede.OfficeLine.Engine;
using Sagede.Shared.RealTimeData.Common.Utilities;

namespace DTSAG.Artikelimport
{
    class Artikelimport : DataServiceBase
    {
        private const string UuidTag = "$uuid";
        private Mandant _mandant;

        public Artikelimport()
        {
            _mandant = Mandant;
        }
        public override DataActionResult<DataContainer> Create(DataActionRequest<DataContainer> request)
        {
            throw new NotImplementedException();
        }

        public override DataActionResult Delete(DataActionRequest request)
        {
            throw new NotImplementedException();
        }

        public override DataServiceExecuteResponse Execute(DataServiceExecuteRequest request)
        {

            switch (request.MethodName)
            {
                //Verfügbare Methoden:
                //WriteDummy: Erstellt ein Dunmmy Rowset mit der Anzahl der Datenzeilen analog der Zeilenanzahl der Exceldatei, hierdurch ist eine Iteration im Macro möglich
                // um im nächsten Step Clientseitig die Daten einzulesen
                case "WriteDummy":
                    var dto = request.Data;
                    var uuid = dto.UuidValue;
                    int count = request.Data.ContainsField("DTCountExcelRows") ? Conversion.ToInt32(request.Data["DTCountExcelRows"]) : 0;

                    RowSet dtoChildrenExceldaten = new RowSet();
                    
                    for (int i = 0; i < count; i++)
                    {
                        Row dtoChild = new Row();
                        if (string.IsNullOrEmpty(dtoChild.UuidValue))
                        {
                            dtoChild.UuidValue = Guid.NewGuid().ToString();
                        }
                        dtoChild.Fill("ID",i);
                        dtoChildrenExceldaten.Add(dtoChild);
                    }
                    //if ((bo.BelegtexteKunden != null))
                    //{
                    //    foreach (Sage100.Rezept13.BelegtextKundenItem boChild in bo.BelegtexteKunden)
                    //    {
                    //        Row dtoChildBelegtexteKunden = new Row();
                    //        FillDtoBelegtextKunden(dtoChildBelegtexteKunden, boChild);
                    //        dtoChildrenBelegtexteKunden.Add(dtoChildBelegtexteKunden);
                    //    }
                    //}
                    //dto.SetChild(dtoChildrenBelegtexteKunden, "BelegtexteKunden");
                    request.Data.SetChild(dtoChildrenExceldaten,"Importdaten" ); //Name Importdaten ist der virtuelle Name der Detail Datenstruktur 
                    break;
                case "WriteData":

                    break;

            }
            //DataContainer dto = request.Data;
            //string uuId = dto.UuidValue;// 
            //string lieferant = dto.ContainsField("DTLieferant") ?Conversion.ToString(dto["DTLieferant"], false):String.Empty;
            //string vorlage = dto.ContainsField("DTArtikelvorlage") ? Conversion.ToString(dto["DTArtikelvorlage"], false) : String.Empty;


            //if (string.IsNullOrEmpty(lieferant))
            //{
            //    return DataServiceExecuteResponse.ErrorResponse (new Exception("Es wurde kein Lieferant gewählt!"));
            //}

            //IGenericCommand command = _mandant.MainDevice.GenericConnection.CreateSqlStringCommand("");
            return DataServiceExecuteResponse.SuccessResponse(request.Data);
        }

        public override DataActionResult<DataContainer> GetItem(DataActionRequest request)
        {
            throw new NotImplementedException();
        }

        public override DataActionResult<DataContainerSet> GetList(DataActionRequest request)
        {
            throw new NotImplementedException();
        }

        public override DataActionResult<DataContainer> GetTemplate(DataActionRequest request)
        {
            DataContainer result = new DataContainer();
            //Dim bo As New DTVorgangsuebersichtVKStatus(Mandant)

            //'UUIDs müssen erzeugt werden
            result.KeyValue = String.Empty;
            result.VersionStamp = String.Empty;
            result.UuidValue = Guid.NewGuid().ToString();
            result.Fill("DTGuid",result.UuidValue);
            result.Fill("DTExceldatei", "Excel Datei");
            result.Fill("DTArtikelvorlage", "Artikel");
            result.Fill("DTLieferant", "Lieferant");
            result.Fill("DTCountExcelRows", "2");
            RowSet dtoChildExceldaten = new RowSet();
            Row dtoChild = new Row();
            dtoChild.UuidValue = Guid.NewGuid().ToString();
            dtoChild.VersionStamp =string.Empty;

            dtoChild.Fill("ID", 1);
            dtoChild.Fill("Text", "Text");
            dtoChildExceldaten.Add(dtoChild);

            result.SetChild(dtoChildExceldaten, "Importdaten");

            return DataActionResult.Succeeded(result);
        }

        public override void PrepareMetadata(DataObjectBase rawMetadata)
        {
            DataStructure dataStructure = (DataStructure)rawMetadata;

        }

        public override DataActionResult<DataContainer> Update(DataActionRequest<DataContainer> request)
        {
            throw new NotImplementedException();
        }
    }
}
