using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllSpartan_Module_Object_Characteristic : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public short Spartan_Module_Object_Characteristic_Module_Object_Characteristic_Id { get; set; }
        public int? Spartan_Module_Object_Characteristic_Object_Id { get; set; }
        public string Spartan_Module_Object_Characteristic_Object_Id_Name { get; set; }
        public short? Spartan_Module_Object_Characteristic_Characteristic { get; set; }
        public string Spartan_Module_Object_Characteristic_Characteristic_Description { get; set; }
        public int? Spartan_Module_Object_Characteristic_Numeric_Value { get; set; }
        public string Spartan_Module_Object_Characteristic_Text_Value { get; set; }
        public short Spartan_Module_Object_Characteristic_Spartan_Module { get; set; }

    }
}
