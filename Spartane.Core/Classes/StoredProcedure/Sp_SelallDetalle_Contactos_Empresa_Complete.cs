using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallDetalle_Contactos_Empresa_Complete : BaseEntity
    {
        public int Folio { get; set; }
        public int Folio_Empresas { get; set; }
        public string Nombre_completo { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public bool? Contacto_Principal { get; set; }
        public int? Area { get; set; }
        public string Area_Nombre { get; set; }
        public bool? Acceso_al_Sistema { get; set; }
        public string Nombre_de_usuario { get; set; }
        public bool? Recibe_Alertas { get; set; }
        public int? Estatus { get; set; }
        public string Estatus_Descripcion { get; set; }

    }
}
