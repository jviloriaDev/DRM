using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllDetalle_Convenio_Medicos_Aseguradoras : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Detalle_Convenio_Medicos_Aseguradoras_Folio { get; set; }
        public int Detalle_Convenio_Medicos_Aseguradoras_Folio_Medicos { get; set; }
        public int? Detalle_Convenio_Medicos_Aseguradoras_Aseguradora_medico { get; set; }
        public string Detalle_Convenio_Medicos_Aseguradoras_Aseguradora_medico_Nombre { get; set; }

    }
}
