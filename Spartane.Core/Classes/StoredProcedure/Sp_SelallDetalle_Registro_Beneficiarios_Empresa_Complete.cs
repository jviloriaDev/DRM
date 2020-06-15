using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallDetalle_Registro_Beneficiarios_Empresa_Complete : BaseEntity
    {
        public int Folio { get; set; }
        public int Folio_Empresa { get; set; }
        public string Numero_de_Empleado { get; set; }
        public int? Usuario { get; set; }
        public string Usuario_Name { get; set; }
        public string Nombres { get; set; }
        public string Apellido_Paterno { get; set; }
        public string Apellido_Materno { get; set; }
        public string Nombre_Completo { get; set; }
        public string Email { get; set; }
        public bool? Activo { get; set; }
        public int? Suscripcion { get; set; }
        public string Suscripcion_Nombre_del_Plan { get; set; }
        public string Codigo_de_Referencia { get; set; }
        public int? Estatus { get; set; }
        public string Estatus_Descripcion { get; set; }

    }
}
