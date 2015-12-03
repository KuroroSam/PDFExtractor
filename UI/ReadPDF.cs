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
                var pageSize = reader.GetPageSizeWithRotation(page);

                float factor;
                if (pageSize.Height > pageSize.Width) 
                {
                    //Portait
                    factor = 2000 / pageSize.Width; 
                }
                else{
                    //landscape
                    factor = 1700 / pageSize.Height;
                }
               
                var annotationList = p.GetAsArray(iTextSharp.text.pdf.PdfName.ANNOTS);

                foreach (PdfObject annot in annotationList.ArrayList)
                {
                    PdfDictionary annotationDict = (PdfDictionary)PdfReader.GetPdfObject(annot);
                    var subtype = annotationDict.Get(PdfName.SUBTYPE);
                    if (subtype == PdfName.FREETEXT)
                    {
                        var content = annotationDict.GetAsString(PdfName.CONTENTS);
                        var rect = annotationDict.GetAsArray(PdfName.RECT);
                        var roatation = pageSize.Rotation;
                        var left = Convert.ToDouble(rect[2].ToString());
                        var top = Convert.ToDouble(pageSize.Height - float.Parse(rect[3].ToString()));

                        if (roatation == 90)
                        {
                            left = pageSize.Height > pageSize.Width ? Convert.ToDouble(rect[3].ToString()) :  float.Parse(rect[1].ToString());
                            top = pageSize.Height > pageSize.Width ? float.Parse(rect[2].ToString()) : Convert.ToDouble(float.Parse(rect[0].ToString()));
                        }
                        

                        var offsetX = 20;

                        var location = new LocationModel {
                            X = Convert.ToInt32(Double.Parse(left.ToString()) * factor) + offsetX,
                            Y = Convert.ToInt32(Double.Parse(top.ToString()) * factor),
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
