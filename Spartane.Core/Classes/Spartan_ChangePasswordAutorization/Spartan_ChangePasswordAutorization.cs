using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Classes.Spartan_User;
using Spartane.Core.Classes.SpartanChangePasswordAutorizationEstatus;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Spartan_ChangePasswordAutorization
{
    /// <summary>
    /// Spartan_ChangePasswordAutorization table
    /// </summary>
    public class Spartan_ChangePasswordAutorization: BaseEntity
    {
        public int Clave { get; set; }
        public DateTime? Fecha_de_Registro { get; set; }
        public string Hora_de_Registro { get; set; }
        public int? Usuario { get; set; }
        public int? Estatus { get; set; }
        public string Email { get; set; }

        [ForeignKey("Usuario")]
        public virtual Spartane.Core.Classes.Spartan_User.Spartan_User Usuario_Spartan_User { get; set; }
        [ForeignKey("Estatus")]
        public virtual Spartane.Core.Classes.SpartanChangePasswordAutorizationEstatus.SpartanChangePasswordAutorizationEstatus Estatus_SpartanChangePasswordAutorizationEstatus { get; set; }

    }
}

