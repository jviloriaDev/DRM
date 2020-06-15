using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllDetalle_Registro_Beneficiarios_Empresa : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Detalle_Registro_Beneficiarios_Empresa_Folio { get; set; }
        public int Detalle_Registro_Beneficiarios_Empresa_Folio_Empresa { get; set; }
        public string Detalle_Registro_Beneficiarios_Empresa_Numero_de_Empleado { get; set; }
        public int? Detalle_Registro_Beneficiarios_Empresa_Usuario { get; set; }
        public string Detalle_Registro_Beneficiarios_Empresa_Usuario_Name { get; set; }
        public string Detalle_Registro_Beneficiarios_Empresa_Nombres { get; set; }
        public string Detalle_Registro_Beneficiarios_Empresa_Apellido_Paterno { get; set; }
        public string Detalle_Registro_Beneficiarios_Empresa_Apellido_Materno { get; set; }
        public string Detalle_Registro_Beneficiarios_Empresa_Nombre_Completo { get; set; }
        public string Detalle_Registro_Beneficiarios_Empresa_Email { get; set; }
        public bool? Detalle_Registro_Beneficiarios_Empresa_Activo { get; set; }
        public int? Detalle_Registro_Beneficiarios_Empresa_Suscripcion { get; set; }
        public string Detalle_Registro_Beneficiarios_Empresa_Suscripcion_Nombre_del_Plan { get; set; }
        public string Detalle_Registro_Beneficiarios_Empresa_Codigo_de_Referencia { get; set; }
        public int? Detalle_Registro_Beneficiarios_Empresa_Estatus { get; set; }
        public string Detalle_Registro_Beneficiarios_Empresa_Estatus_Descripcion { get; set; }

    }
}
