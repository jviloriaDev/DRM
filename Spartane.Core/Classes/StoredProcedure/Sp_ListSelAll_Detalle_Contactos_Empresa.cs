using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllDetalle_Contactos_Empresa : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Detalle_Contactos_Empresa_Folio { get; set; }
        public int Detalle_Contactos_Empresa_Folio_Empresas { get; set; }
        public string Detalle_Contactos_Empresa_Nombre_completo { get; set; }
        public string Detalle_Contactos_Empresa_Correo { get; set; }
        public string Detalle_Contactos_Empresa_Telefono { get; set; }
        public bool? Detalle_Contactos_Empresa_Contacto_Principal { get; set; }
        public int? Detalle_Contactos_Empresa_Area { get; set; }
        public string Detalle_Contactos_Empresa_Area_Nombre { get; set; }
        public bool? Detalle_Contactos_Empresa_Acceso_al_Sistema { get; set; }
        public string Detalle_Contactos_Empresa_Nombre_de_usuario { get; set; }
        public bool? Detalle_Contactos_Empresa_Recibe_Alertas { get; set; }
        public int? Detalle_Contactos_Empresa_Estatus { get; set; }
        public string Detalle_Contactos_Empresa_Estatus_Descripcion { get; set; }

    }
}
