using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Classes.Spartan_User;
using Spartane.Core.Classes.Spartan_User_Alert_Type;
using Spartane.Core.Classes.Spartan_User_Alert_Status;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Spartan_User_Alert
{
    /// <summary>
    /// Spartan_User_Alert table
    /// </summary>
    public class Spartan_User_Alert: BaseEntity
    {
        public int User__Alert_Id { get; set; }
        public int? User_Id { get; set; }
        public short? Alert_Type { get; set; }
        public string Description { get; set; }
        public string URL { get; set; }
        public short? Status { get; set; }

        [ForeignKey("User_Id")]
        public virtual Spartane.Core.Classes.Spartan_User.Spartan_User User_Id_Spartan_User { get; set; }
        [ForeignKey("Alert_Type")]
        public virtual Spartane.Core.Classes.Spartan_User_Alert_Type.Spartan_User_Alert_Type Alert_Type_Spartan_User_Alert_Type { get; set; }
        [ForeignKey("Status")]
        public virtual Spartane.Core.Classes.Spartan_User_Alert_Status.Spartan_User_Alert_Status Status_Spartan_User_Alert_Status { get; set; }

    }
}

