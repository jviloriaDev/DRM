using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllSpartan_Format_Permission_Type : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public short Spartan_Format_Permission_Type_PermissionTypeId { get; set; }
        public string Spartan_Format_Permission_Type_Description { get; set; }

    }
}
