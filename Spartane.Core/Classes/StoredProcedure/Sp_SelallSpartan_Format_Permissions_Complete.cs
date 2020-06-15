using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallSpartan_Format_Permissions_Complete : BaseEntity
    {
        public int PermissionId { get; set; }
        public int? Format { get; set; }
        public string Format_Format_Name { get; set; }
        public short? Permission_Type { get; set; }
        public string Permission_Type_Description { get; set; }
        public bool? Apply { get; set; }
        public int? Spartan_User_Role { get; set; }

    }
}
