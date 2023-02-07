using Syncfusion.DocIO;
using Syncfusion.DocIO.DLS;
//using Syncfusion.HtmlConverter;
//using Syncfusion.Pdf;
using System.IO;
using System.IO.Pipes;

namespace Contractv2.Services
{
    public class FileConverterService
    {
        public void ConvertWordToHtml(string path, ref MemoryStream ms)
        {
            using (FileStream inputStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                //Open an existing Word document.
                using (WordDocument document = new WordDocument(inputStream, FormatType.Automatic))
                {
                    //Save as a Markdown file into the MemoryStream.
                    document.Save(ms, FormatType.Html);
                    ms.Position = 0;
                }
            }
        }

        public void CovertHtmlToWord(string path, ref MemoryStream ms)
        {
            using (FileStream inputStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                //Open an existing Word document.
                using (WordDocument document = new WordDocument(inputStream, FormatType.Html))
                {
                    //Save as a Markdown file into the MemoryStream.
                    document.Save(ms, FormatType.Docx);
                    ms.Position = 0;
                }
            }
        }

        //public MemoryStream ConvertHtmlToPdf(string path)
        //{
        //    //Initialize HTML to PDF converter 
        //    HtmlToPdfConverter htmlConverter = new HtmlToPdfConverter();

        //    //Convert URL to PDF document 
        //    PdfDocument document = htmlConverter.Convert("https://www.google.com");

        //    MemoryStream stream = new MemoryStream();

        //    //Save and close the PDF document 
        //    document.Save(stream);
        //    document.Close(true);

        //    return stream;
        //}
    }
}
