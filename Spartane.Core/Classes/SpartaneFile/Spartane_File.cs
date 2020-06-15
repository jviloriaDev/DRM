using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.SpartaneFile
{
    /// <summary>
    /// Spartane_File table
    /// </summary>
    public class SpartaneFile : BaseEntity
    {
        public long File_Id { get; set; }
        public string File_Name { get; set; }
        public long File_Size { get; set; }
        public byte[] File { get; set; }  
    }
}
