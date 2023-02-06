using Syncfusion.DocIO;
using Syncfusion.DocIO.DLS;
//using Syncfusion.HtmlConverter;
//using Syncfusion.Pdf;
using System.IO;

namespace Contractv2.Services
{
    public class WordService
    {
        public MemoryStream ConvertWordToHtml(string path)
        {
            using (FileStream inputStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                //Open an existing Word document.
                using (WordDocument document = new WordDocument(inputStream, FormatType.Automatic))
                {
                    //Save as a Markdown file into the MemoryStream.
                    using (MemoryStream stream = new MemoryStream())
                    {
                        document.Save(stream, FormatType.Html);
                        stream.Position = 0;
                        return stream;
                    }
                }
            }
        }

        public MemoryStream ConvertHTMLtoWord(string path)
        {
            using (FileStream inputStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                //Open an existing Word document.
                using (WordDocument document = new WordDocument(inputStream, FormatType.Automatic))
                {
                    //Save as a Markdown file into the MemoryStream.
                    using (MemoryStream stream = new MemoryStream())
                    {
                        document.Save(stream, FormatType.Docx);
                        stream.Position = 0;
                        return stream;
                    }
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
