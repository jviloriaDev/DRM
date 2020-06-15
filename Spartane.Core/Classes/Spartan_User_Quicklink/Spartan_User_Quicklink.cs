using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Classes.Spartan_User;
using Spartane.Core.Classes.Spartan_Object;
using Spartane.Core.Classes.Spartan_Method_Type;
using Spartane.Core.Classes.Spartan_Control_Type;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Spartan_User_Quicklink
{
    /// <summary>
    /// Spartan_User_Quicklink table
    /// </summary>
    public class Spartan_User_Quicklink: BaseEntity
    {
        public int User_Quicklink_Id { get; set; }
        public int? User_Id { get; set; }
        public int? Object { get; set; }
        public short? Order_Shown { get; set; }
        public short? Method_Type { get; set; }
        public string Description { get; set; }
        public int? Atribute_Id { get; set; }
        public int? Control_Type { get; set; }

        [ForeignKey("User_Id")]
        public virtual Spartane.Core.Classes.Spartan_User.Spartan_User User_Id_Spartan_User { get; set; }
        [ForeignKey("Object")]
        public virtual Spartane.Core.Classes.Spartan_Object.Spartan_Object Object_Spartan_Object { get; set; }
        [ForeignKey("Method_Type")]
        public virtual Spartane.Core.Classes.Spartan_Method_Type.Spartan_Method_Type Method_Type_Spartan_Method_Type { get; set; }
        [ForeignKey("Control_Type")]
        public virtual Spartane.Core.Classes.Spartan_Control_Type.Spartan_Control_Type Control_Type_Spartan_Control_Type { get; set; }

    }
}

