using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallDetalle_Identificacion_Oficial_Medicos_Complete : BaseEntity
    {
        public int Folio { get; set; }
        public int Folio_Medico { get; set; }
        public int? Tipo_de_Identificacion_Oficial { get; set; }
        public string Tipo_de_Identificacion_Oficial_Descripcion { get; set; }
        public int? Documento { get; set; }

    }
}
