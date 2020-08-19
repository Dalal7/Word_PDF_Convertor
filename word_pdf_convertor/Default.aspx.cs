using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SautinSoft;

namespace word_pdf_convertor
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (file.HasFile)
            {
                try
                {

                    if (file.PostedFile.FileName.Length == 0 || file.FileBytes.Length == 0)
                    {
                        Result.Text = "Please select PDF file at first!";
                        return;
                    }
                    byte[] rtf = null;

                    SautinSoft.PdfFocus f = new SautinSoft.PdfFocus();
                    f.OpenPdf(file.FileBytes);

                    if (f.PageCount > 0)
                    {
                        //Let's whole PDF document to Word (RTF)
                        f.WordOptions.Format = SautinSoft.PdfFocus.CWordOptions.eWordDocument.Rtf;

                        // You may also set an output format to Docx.
                        //f.WordOptions.Format = SautinSoft.PdfFocus.CWordOptions.eWordDocument.Docx;
                        rtf = f.ToWord();
                    }

                    //show Word/rtf
                    if (rtf != null)
                    {
                        ShowResult(rtf, "Result.rtf", "application/msword");
                    }
                    else
                    {
                        Result.Text = "Converting failed!";
                    }
                
   

            }
                catch (Exception ex)
                {
                    Response.Write("Error: " + ex.Message);
                }
            }
            else
            {
                Result.Text = "Please choose a file to upload!";
            }

        }

        private void ShowResult(byte[] data, string fileName, string contentType)
        {
            Response.Buffer = true;
            Response.Clear();
            Response.ContentType = contentType;
            Response.AddHeader("content-disposition", "inline; filename=\"" + fileName + "\"");
            Response.BinaryWrite(data);
            Response.Flush();
            Response.End();
        }
    }
}