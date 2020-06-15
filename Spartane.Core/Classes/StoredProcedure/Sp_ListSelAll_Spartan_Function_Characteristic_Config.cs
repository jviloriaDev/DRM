using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllSpartan_Function_Characteristic_Config : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public short Spartan_Function_Characteristic_Config_Function_Characteristic_Config_Id { get; set; }
        public short? Spartan_Function_Characteristic_Config_Function_Characteristic_Id { get; set; }
        public string Spartan_Function_Characteristic_Config_Function_Characteristic_Id_Description { get; set; }
        public int? Spartan_Function_Characteristic_Config_Numeric_Value { get; set; }
        public string Spartan_Function_Characteristic_Config_Text_Value { get; set; }

    }
}
