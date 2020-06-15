using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllSpartan_User_Rule_Module : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public short Spartan_User_Rule_Module_User_Rule_Module_Id { get; set; }
        public short? Spartan_User_Rule_Module_Module_Id { get; set; }
        public string Spartan_User_Rule_Module_Module_Id_Name { get; set; }
        public short? Spartan_User_Rule_Module_Order_Shown { get; set; }
        public int Spartan_User_Rule_Module_Spartan_User_Role { get; set; }

    }
}
