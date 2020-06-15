using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Classes.Spartan_Function_Characteristic;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Spartan_Function_Characteristic_Config
{
    /// <summary>
    /// Spartan_Function_Characteristic_Config table
    /// </summary>
    public class Spartan_Function_Characteristic_Config: BaseEntity
    {
        public short Function_Characteristic_Config_Id { get; set; }
        public short? Function_Characteristic_Id { get; set; }
        public int? Numeric_Value { get; set; }
        public string Text_Value { get; set; }

        [ForeignKey("Function_Characteristic_Id")]
        public virtual Spartane.Core.Classes.Spartan_Function_Characteristic.Spartan_Function_Characteristic Function_Characteristic_Id_Spartan_Function_Characteristic { get; set; }

    }
}

