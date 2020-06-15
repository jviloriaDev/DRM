using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallPlanes_de_Suscripcion_Especialistas_Complete : BaseEntity
    {
        public int Folio { get; set; }
        public string Nombre { get; set; }
        public int? Costo { get; set; }
        public int? Estatus { get; set; }
        public string Estatus_Descripcion { get; set; }

    }
}
