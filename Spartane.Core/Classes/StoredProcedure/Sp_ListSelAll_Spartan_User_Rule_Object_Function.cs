using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllSpartan_User_Rule_Object_Function : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Spartan_User_Rule_Object_Function_User_Rule_Object_Function_Id { get; set; }
        public short? Spartan_User_Rule_Object_Function_Module_Id { get; set; }
        public string Spartan_User_Rule_Object_Function_Module_Id_Name { get; set; }
        public int? Spartan_User_Rule_Object_Function_Object_Id { get; set; }
        public string Spartan_User_Rule_Object_Function_Object_Id_Name { get; set; }
        public short? Spartan_User_Rule_Object_Function_Fuction_Id { get; set; }
        public string Spartan_User_Rule_Object_Function_Fuction_Id_Description { get; set; }
        public int Spartan_User_Rule_Object_Function_Spartan_User_Rule { get; set; }

    }
}
