using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Classes.Spartan_User;
using Spartane.Core.Classes.Spartan_Object;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Spartan_User_Favorite_Object
{
    /// <summary>
    /// Spartan_User_Favorite_Object table
    /// </summary>
    public class Spartan_User_Favorite_Object: BaseEntity
    {
        public int User_Favorite_Object_Id { get; set; }
        public int? User_Id { get; set; }
        public int? Object { get; set; }
        public short? Order_Shown { get; set; }

        [ForeignKey("User_Id")]
        public virtual Spartane.Core.Classes.Spartan_User.Spartan_User User_Id_Spartan_User { get; set; }
        [ForeignKey("Object")]
        public virtual Spartane.Core.Classes.Spartan_Object.Spartan_Object Object_Spartan_Object { get; set; }

    }
}

