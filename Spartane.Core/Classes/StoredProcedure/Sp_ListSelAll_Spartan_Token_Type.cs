using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllSpartan_Token_Type : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public short Spartan_Token_Type_Token_Type_Id { get; set; }
        public string Spartan_Token_Type_Description { get; set; }

    }
}
