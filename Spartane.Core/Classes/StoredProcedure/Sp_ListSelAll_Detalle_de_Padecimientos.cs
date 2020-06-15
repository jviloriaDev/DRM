using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllDetalle_de_Padecimientos : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Detalle_de_Padecimientos_Folio { get; set; }
        public int Detalle_de_Padecimientos_Folio_Pacientes { get; set; }
        public int? Detalle_de_Padecimientos_Padecimiento { get; set; }
        public string Detalle_de_Padecimientos_Padecimiento_Descripcion { get; set; }
        public int? Detalle_de_Padecimientos_Tiempo_con_el_diagnostico { get; set; }
        public string Detalle_de_Padecimientos_Tiempo_con_el_diagnostico_Descripcion { get; set; }
        public int? Detalle_de_Padecimientos_Intervencion_quirurgica { get; set; }
        public string Detalle_de_Padecimientos_Intervencion_quirurgica_Descripcion { get; set; }
        public string Detalle_de_Padecimientos_Tratamiento { get; set; }
        public int? Detalle_de_Padecimientos_Estado_actual { get; set; }
        public string Detalle_de_Padecimientos_Estado_actual_Descripcion { get; set; }

    }
}
