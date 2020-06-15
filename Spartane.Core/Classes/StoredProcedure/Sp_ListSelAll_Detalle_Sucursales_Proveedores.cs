using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllDetalle_Sucursales_Proveedores : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Detalle_Sucursales_Proveedores_Folio { get; set; }
        public int Detalle_Sucursales_Proveedores_FolioProveedores { get; set; }
        public int? Detalle_Sucursales_Proveedores_Tipo_de_Sucursal { get; set; }
        public string Detalle_Sucursales_Proveedores_Tipo_de_Sucursal_Descripcion { get; set; }
        public string Detalle_Sucursales_Proveedores_Email { get; set; }
        public string Detalle_Sucursales_Proveedores_Telefono { get; set; }
        public string Detalle_Sucursales_Proveedores_Calle { get; set; }
        public int? Detalle_Sucursales_Proveedores_Numero_exterior { get; set; }
        public int? Detalle_Sucursales_Proveedores_Numero_interior { get; set; }
        public string Detalle_Sucursales_Proveedores_Colonia { get; set; }
        public int? Detalle_Sucursales_Proveedores_C_P_ { get; set; }
        public string Detalle_Sucursales_Proveedores_Ciudad { get; set; }
        public string Detalle_Sucursales_Proveedores_Estado { get; set; }
        public string Detalle_Sucursales_Proveedores_Pais { get; set; }

    }
}
