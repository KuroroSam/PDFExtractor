using iTextSharp.text.pdf;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI
{
    public class ReadPDF
    {
        public List<LocationModel> ReadPdfFile(String fileName)
        {

            string strText = string.Empty;


            PdfReader reader = new PdfReader(fileName);

            var locationList = new List<LocationModel>();

            for (int page = 1; page <= reader.NumberOfPages; page++)
            {
                var p = reader.GetPageN(page);
                var pageSize = reader.GetPageSize(page);
                var factor = 1700 / pageSize.Height;
               
                var annotationList = p.GetAsArray(iTextSharp.text.pdf.PdfName.ANNOTS);

                foreach (PdfObject annot in annotationList.ArrayList)
                {
                    PdfDictionary annotationDict = (PdfDictionary)PdfReader.GetPdfObject(annot);
                    var subtype = annotationDict.Get(PdfName.SUBTYPE);
                    if (subtype == PdfName.FREETEXT)
                    {
                        var content = annotationDict.GetAsString(PdfName.CONTENTS);
                        var rect = annotationDict.GetAsArray(PdfName.RECT);
                        var left = rect[2];
                        var top = rect[3];

                        var offsetX = 20;

                        var location = new LocationModel {
                            X = Convert.ToInt32(Double.Parse(left.ToString()) * factor) + offsetX,
                            Y = Convert.ToInt32((pageSize.Height - float.Parse(top.ToString())) * factor),
                            Title = content.ToString() };
                        locationList.Add(location);
                    }
                }
            }

            reader.Close();

            return locationList;

        }

        public String WriteJson(List<LocationModel> locations)
        {

            string json = JsonConvert.SerializeObject(locations);

            return json;
        }
    }
}
