using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallDetalle_de_Padecimientos_Complete : BaseEntity
    {
        public int Folio { get; set; }
        public int Folio_Pacientes { get; set; }
        public int? Padecimiento { get; set; }
        public string Padecimiento_Descripcion { get; set; }
        public int? Tiempo_con_el_diagnostico { get; set; }
        public string Tiempo_con_el_diagnostico_Descripcion { get; set; }
        public int? Intervencion_quirurgica { get; set; }
        public string Intervencion_quirurgica_Descripcion { get; set; }
        public string Tratamiento { get; set; }
        public int? Estado_actual { get; set; }
        public string Estado_actual_Descripcion { get; set; }

    }
}
