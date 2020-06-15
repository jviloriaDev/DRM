using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallDetalle_Convenio_Medicos_Aseguradoras_Complete : BaseEntity
    {
        public int Folio { get; set; }
        public int Folio_Medicos { get; set; }
        public int? Aseguradora_medico { get; set; }
        public string Aseguradora_medico_Nombre { get; set; }

    }
}
