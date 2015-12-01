namespace UI
{
    partial class PDFExtractorForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.textBoxResult = new System.Windows.Forms.TextBox();
            this.buttonReadPDF = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // textBoxResult
            // 
            this.textBoxResult.Location = new System.Drawing.Point(12, 69);
            this.textBoxResult.Multiline = true;
            this.textBoxResult.Name = "textBoxResult";
            this.textBoxResult.Size = new System.Drawing.Size(504, 301);
            this.textBoxResult.TabIndex = 0;
            // 
            // buttonReadPDF
            // 
            this.buttonReadPDF.Location = new System.Drawing.Point(12, 12);
            this.buttonReadPDF.Name = "buttonReadPDF";
            this.buttonReadPDF.Size = new System.Drawing.Size(504, 51);
            this.buttonReadPDF.TabIndex = 1;
            this.buttonReadPDF.Text = "OpenPDF";
            this.buttonReadPDF.UseVisualStyleBackColor = true;
            this.buttonReadPDF.Click += new System.EventHandler(this.buttonReadPDF_Click);
            // 
            // PDFExtractorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 382);
            this.Controls.Add(this.buttonReadPDF);
            this.Controls.Add(this.textBoxResult);
            this.Name = "PDFExtractorForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.PDFExtractorForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox textBoxResult;
        private System.Windows.Forms.Button buttonReadPDF;
    }
}

