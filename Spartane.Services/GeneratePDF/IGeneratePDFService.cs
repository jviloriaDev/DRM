using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Services.GeneratePDF
{
    public partial interface IGeneratePDFService
    {
        byte[] GeneratePDF(string ConnectionString, int idFormat, string RecordId, string ImgDirectory = "");
        string GenerateHTML(string ConnectionString, int idFormat, string RecordId, string ImgDirectory = "");
       
    }
}
