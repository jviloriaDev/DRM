using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Classes.Spartan_Object;
using Spartane.Core.Classes.Spartan_Object_Characteristic;
using Spartane.Core.Classes.Spartan_Module;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Spartan_Module_Object_Characteristic
{
    /// <summary>
    /// Spartan_Module_Object_Characteristic table
    /// </summary>
    public class Spartan_Module_Object_Characteristic: BaseEntity
    {
        public short Module_Object_Characteristic_Id { get; set; }
        public int? Object_Id { get; set; }
        public short? Characteristic { get; set; }
        public int? Numeric_Value { get; set; }
        public string Text_Value { get; set; }
        public short Spartan_Module { get; set; }

        [ForeignKey("Object_Id")]
        public virtual Spartane.Core.Classes.Spartan_Object.Spartan_Object Object_Id_Spartan_Object { get; set; }
        [ForeignKey("Characteristic")]
        public virtual Spartane.Core.Classes.Spartan_Object_Characteristic.Spartan_Object_Characteristic Characteristic_Spartan_Object_Characteristic { get; set; }
        [ForeignKey("Spartan_Module")]
        public virtual Spartane.Core.Classes.Spartan_Module.Spartan_Module Spartan_Module_Spartan_Module { get; set; }

    }
}

