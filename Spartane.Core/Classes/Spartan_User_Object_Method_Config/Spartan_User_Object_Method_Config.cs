using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Classes.Spartan_User;
using Spartane.Core.Classes.Spartan_Module;
using Spartane.Core.Classes.Spartan_Object;
using Spartane.Core.Classes.Spartan_Object_Method_Characteristic;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Spartan_User_Object_Method_Config
{
    /// <summary>
    /// Spartan_User_Object_Method_Config table
    /// </summary>
    public class Spartan_User_Object_Method_Config: BaseEntity
    {
        public int User_Object_Method_Config_Id { get; set; }
        public int? User_Id { get; set; }
        public short? Module_Id { get; set; }
        public int? Object_Id { get; set; }
        public int? Characteristic { get; set; }
        public int? Numeric_Value { get; set; }
        public string Text_Value { get; set; }

        [ForeignKey("User_Id")]
        public virtual Spartane.Core.Classes.Spartan_User.Spartan_User User_Id_Spartan_User { get; set; }
        [ForeignKey("Module_Id")]
        public virtual Spartane.Core.Classes.Spartan_Module.Spartan_Module Module_Id_Spartan_Module { get; set; }
        [ForeignKey("Object_Id")]
        public virtual Spartane.Core.Classes.Spartan_Object.Spartan_Object Object_Id_Spartan_Object { get; set; }
        [ForeignKey("Characteristic")]
        public virtual Spartane.Core.Classes.Spartan_Object_Method_Characteristic.Spartan_Object_Method_Characteristic Characteristic_Spartan_Object_Method_Characteristic { get; set; }

    }
}

