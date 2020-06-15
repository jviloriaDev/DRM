using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllSpartan_Format_Related : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Spartan_Format_Related_Clave { get; set; }
        public int? Spartan_Format_Related_FormatId { get; set; }
        public int? Spartan_Format_Related_FormatId_FormatId { get; set; }
        public int? Spartan_Format_Related_FormatId_Related { get; set; }
        public int? Spartan_Format_Related_FormatId_Related_FormatId { get; set; }
        public short? Spartan_Format_Related_Order { get; set; }

    }
}
