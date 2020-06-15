using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Classes.Spartan_Module;
using Spartane.Core.Classes.Spartan_Object;
using Spartane.Core.Classes.Spartan_Function;
using Spartane.Core.Classes.Spartan_User_Role;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Spartan_User_Rule_Object_Function
{
    /// <summary>
    /// Spartan_User_Rule_Object_Function table
    /// </summary>
    public class Spartan_User_Rule_Object_Function: BaseEntity
    {
        public int User_Rule_Object_Function_Id { get; set; }
        public short? Module_Id { get; set; }
        public int? Object_Id { get; set; }
        public short? Fuction_Id { get; set; }
        public int Spartan_User_Rule { get; set; }

        [ForeignKey("Module_Id")]
        public virtual Spartane.Core.Classes.Spartan_Module.Spartan_Module Module_Id_Spartan_Module { get; set; }
        [ForeignKey("Object_Id")]
        public virtual Spartane.Core.Classes.Spartan_Object.Spartan_Object Object_Id_Spartan_Object { get; set; }
        [ForeignKey("Fuction_Id")]
        public virtual Spartane.Core.Classes.Spartan_Function.Spartan_Function Fuction_Id_Spartan_Function { get; set; }
        [ForeignKey("Spartan_User_Rule")]
        public virtual Spartane.Core.Classes.Spartan_User_Role.Spartan_User_Role Spartan_User_Rule_Spartan_User_Role { get; set; }

    }
}

