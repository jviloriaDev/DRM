using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallDetalle_Especialistas_Pacientes_Complete : BaseEntity
    {
        public int Folio { get; set; }
        public int Folio_Pacientes { get; set; }
        public int? Especialista { get; set; }
        public string Especialista_Name { get; set; }
        public int? Especialidad { get; set; }
        public string Especialidad_Especialidad { get; set; }
        public DateTime? Fecha_inicio { get; set; }
        public DateTime? Fecha_fin { get; set; }
        public int? Cantidad_consultas { get; set; }
        public bool? Principal { get; set; }
        public int? Estatus { get; set; }
        public string Estatus_Descripcion { get; set; }

    }
}
