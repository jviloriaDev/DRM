using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallDetalle_Sucursales_Proveedores_Complete : BaseEntity
    {
        public int Folio { get; set; }
        public int FolioProveedores { get; set; }
        public int? Tipo_de_Sucursal { get; set; }
        public string Tipo_de_Sucursal_Descripcion { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Calle { get; set; }
        public int? Numero_exterior { get; set; }
        public int? Numero_interior { get; set; }
        public string Colonia { get; set; }
        public int? C_P_ { get; set; }
        public string Ciudad { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }

    }
}
