using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Classes.Spartan_User;
using Spartane.Core.Classes.Spartan_Object;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Spartan_Control_Type
{
    /// <summary>
    /// Spartan_Control_Type table
    /// </summary>
    public class Spartan_Control_Type: BaseEntity
    {
        public int Control_Type_Id { get; set; }
        public int? User_Id { get; set; }
        public int? Object { get; set; }
        public short? Order_Shown { get; set; }

        [ForeignKey("User_Id")]
        public virtual Spartane.Core.Classes.Spartan_User.Spartan_User User_Id_Spartan_User { get; set; }
        [ForeignKey("Object")]
        public virtual Spartane.Core.Classes.Spartan_Object.Spartan_Object Object_Spartan_Object { get; set; }

    }
}

