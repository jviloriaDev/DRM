using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneratePDF;

namespace Spartane.Services.GeneratePDF
{
    public partial class GeneratePDFService : IGeneratePDFService
    {

        public byte[] GeneratePDF(string ConnectionString, int idFormat, string RecordId, string ImgDirectory = "")
        {
            return GenerateDocument.GeneratePDF(ConnectionString, idFormat, RecordId, ImgDirectory);
        }
        public string GenerateHTML(string ConnectionString, int idFormat, string RecordId, string ImgDirectory = "")
        {
            return GenerateDocument.GenerateHTML(ConnectionString, idFormat, RecordId, ImgDirectory);
        }
    }
}
