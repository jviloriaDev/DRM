using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllDetalle_Examenes_Laboratorio : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Detalle_Examenes_Laboratorio_Folio { get; set; }
        public int Detalle_Examenes_Laboratorio_Folio_Pacientes { get; set; }
        public int? Detalle_Examenes_Laboratorio_Indicador { get; set; }
        public string Detalle_Examenes_Laboratorio_Indicador_Indicador { get; set; }
        public int? Detalle_Examenes_Laboratorio_Resultado { get; set; }
        public string Detalle_Examenes_Laboratorio_Unidad { get; set; }
        public string Detalle_Examenes_Laboratorio_Intervalo_de_Referencia { get; set; }
        public DateTime? Detalle_Examenes_Laboratorio_Fecha_de_Resultado { get; set; }
        public string Detalle_Examenes_Laboratorio_Estatus_Indicador { get; set; }

    }
}
