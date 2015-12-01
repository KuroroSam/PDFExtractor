using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class PDFExtractorForm : Form
    {
        public PDFExtractorForm()
        {
            InitializeComponent();
            this.Text = @"PDF Extractor";
        }

        private void buttonReadPDF_Click(object sender, EventArgs e)
        {
            int size = -1;
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                var pdfreader = new ReadPDF();
                var locations = pdfreader.ReadPdfFile(openFileDialog1.FileName);
                var jsonLocations = pdfreader.WriteJson(locations);

                String jsText = GetJsText();
                textBoxResult.Text = jsText.Replace("{0}",jsonLocations).Replace("{1}",openFileDialog1.FileName);
               
                // Copy the contents of the control to the Clipboard.
                textBoxResult.SelectAll();
                textBoxResult.Copy();
            }
        }

        private String GetJsText()
        {
            String script = @"
/* Generate From PDF: {1} */

var drawingID = 0;
var list = {0};

$.each(list,function(i,n){
	_webAPI.webRequest('/api/Locations',{XCoord:n.X,YCoord:n.Y,Location:n.Title,DrwgID: drawingID},'POST');
});";

            return script;
        }

        private void PDFExtractorForm_Load(object sender, EventArgs e)
        {

        }
    }
}
