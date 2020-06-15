using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Classes.Spartan_User;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Spartan_User_Historical_Password
{
    /// <summary>
    /// Spartan_User_Historical_Password table
    /// </summary>
    public class Spartan_User_Historical_Password: BaseEntity
    {
        public int Clave { get; set; }
        public DateTime? Fecha_de_Registro { get; set; }
        public int? Usuario { get; set; }
        public string Password { get; set; }

        [ForeignKey("Usuario")]
        public virtual Spartane.Core.Classes.Spartan_User.Spartan_User Usuario_Spartan_User { get; set; }

    }
}

