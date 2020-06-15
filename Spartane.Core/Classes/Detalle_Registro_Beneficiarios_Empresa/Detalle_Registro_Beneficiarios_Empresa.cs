using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Classes.Empresas;
using Spartane.Core.Classes.Spartan_User;
using Spartane.Core.Classes.Planes_de_Suscripcion;
using Spartane.Core.Classes.Estatus;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Detalle_Registro_Beneficiarios_Empresa
{
    /// <summary>
    /// Detalle_Registro_Beneficiarios_Empresa table
    /// </summary>
    public class Detalle_Registro_Beneficiarios_Empresa: BaseEntity
    {
        public int Folio { get; set; }
        public int? Folio_Empresa { get; set; }
        public string Numero_de_Empleado { get; set; }
        public int? Usuario { get; set; }
        public string Nombres { get; set; }
        public string Apellido_Paterno { get; set; }
        public string Apellido_Materno { get; set; }
        public string Nombre_Completo { get; set; }
        public string Email { get; set; }
        public bool? Activo { get; set; }
        public int? Suscripcion { get; set; }
        public string Codigo_de_Referencia { get; set; }
        public int? Estatus { get; set; }

        [ForeignKey("Folio_Empresa")]
        public virtual Spartane.Core.Classes.Empresas.Empresas Folio_Empresa_Empresas { get; set; }
        [ForeignKey("Usuario")]
        public virtual Spartane.Core.Classes.Spartan_User.Spartan_User Usuario_Spartan_User { get; set; }
        [ForeignKey("Suscripcion")]
        public virtual Spartane.Core.Classes.Planes_de_Suscripcion.Planes_de_Suscripcion Suscripcion_Planes_de_Suscripcion { get; set; }
        [ForeignKey("Estatus")]
        public virtual Spartane.Core.Classes.Estatus.Estatus Estatus_Estatus { get; set; }

    }
}

