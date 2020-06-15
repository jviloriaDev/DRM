using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllSpartan_User_Quicklink : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Spartan_User_Quicklink_User_Quicklink_Id { get; set; }
        public int? Spartan_User_Quicklink_User_Id { get; set; }
        public string Spartan_User_Quicklink_User_Id_Name { get; set; }
        public int? Spartan_User_Quicklink_Object { get; set; }
        public string Spartan_User_Quicklink_Object_Name { get; set; }
        public short? Spartan_User_Quicklink_Order_Shown { get; set; }
        public short? Spartan_User_Quicklink_Method_Type { get; set; }
        public string Spartan_User_Quicklink_Method_Type_Description { get; set; }
        public string Spartan_User_Quicklink_Description { get; set; }
        public int? Spartan_User_Quicklink_Atribute_Id { get; set; }
        public int? Spartan_User_Quicklink_Control_Type { get; set; }
        public int Spartan_User_Quicklink_Control_Type_User_Id { get; set; }

    }
}
