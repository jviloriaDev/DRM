using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllSpartan_Format_Permissions : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Spartan_Format_Permissions_PermissionId { get; set; }
        public int? Spartan_Format_Permissions_Format { get; set; }
        public string Spartan_Format_Permissions_Format_Format_Name { get; set; }
        public short? Spartan_Format_Permissions_Permission_Type { get; set; }
        public string Spartan_Format_Permissions_Permission_Type_Description { get; set; }
        public bool? Spartan_Format_Permissions_Apply { get; set; }
        public int? Spartan_Format_Permissions_Spartan_User_Role { get; set; }

    }
}
