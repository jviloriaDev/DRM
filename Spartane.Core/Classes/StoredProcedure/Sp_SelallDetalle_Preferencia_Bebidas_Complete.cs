using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallDetalle_Preferencia_Bebidas_Complete : BaseEntity
    {
        public int Folio { get; set; }
        public int Folio_Pacientes { get; set; }
        public int? Bebida { get; set; }
        public string Bebida_Descripcion { get; set; }
        public int? Cantidad { get; set; }
        public string Cantidad_Descripcion { get; set; }

    }
}
