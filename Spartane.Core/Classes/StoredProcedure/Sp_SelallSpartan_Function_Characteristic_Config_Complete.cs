using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallSpartan_Function_Characteristic_Config_Complete : BaseEntity
    {
        public short Function_Characteristic_Config_Id { get; set; }
        public short? Function_Characteristic_Id { get; set; }
        public string Function_Characteristic_Id_Description { get; set; }
        public int? Numeric_Value { get; set; }
        public string Text_Value { get; set; }

    }
}
