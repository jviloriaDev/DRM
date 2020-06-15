using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllSpartan_User_Object_Method_Config : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Spartan_User_Object_Method_Config_User_Object_Method_Config_Id { get; set; }
        public int? Spartan_User_Object_Method_Config_User_Id { get; set; }
        public string Spartan_User_Object_Method_Config_User_Id_Name { get; set; }
        public short? Spartan_User_Object_Method_Config_Module_Id { get; set; }
        public string Spartan_User_Object_Method_Config_Module_Id_Name { get; set; }
        public int? Spartan_User_Object_Method_Config_Object_Id { get; set; }
        public string Spartan_User_Object_Method_Config_Object_Id_Name { get; set; }
        public int? Spartan_User_Object_Method_Config_Characteristic { get; set; }
        public string Spartan_User_Object_Method_Config_Characteristic_Description { get; set; }
        public int? Spartan_User_Object_Method_Config_Numeric_Value { get; set; }
        public string Spartan_User_Object_Method_Config_Text_Value { get; set; }

    }
}
