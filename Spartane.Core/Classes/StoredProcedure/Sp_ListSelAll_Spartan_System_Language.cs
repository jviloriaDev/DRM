using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllSpartan_System_Language : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public short Spartan_System_Language_System_Language_Id { get; set; }
        public string Spartan_System_Language_Resource_File { get; set; }
        public string Spartan_System_Language_Language { get; set; }
        public bool? Spartan_System_Language_Initial { get; set; }

    }
}
