using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllSpartan_Notice : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Spartan_Notice_Notice_Id { get; set; }
        public string Spartan_Notice_Description { get; set; }
        public int? Spartan_Notice_Notice_Type { get; set; }
        public string Spartan_Notice_Notice_Type_Description { get; set; }
        public DateTime? Spartan_Notice_Start_Date { get; set; }
        public DateTime? Spartan_Notice_End_Date { get; set; }
        public short? Spartan_Notice_Status { get; set; }
        public string Spartan_Notice_Status_Description { get; set; }

    }
}
