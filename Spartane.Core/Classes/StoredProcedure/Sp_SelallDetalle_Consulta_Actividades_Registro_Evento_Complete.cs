using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallDetalle_Consulta_Actividades_Registro_Evento_Complete : BaseEntity
    {
        public int Folio { get; set; }
        public int Folio_Registro_Evento { get; set; }
        public int? Actividad { get; set; }
        public string Actividad_Nombre_de_la_Actividad { get; set; }
        public int? Tipo_de_Actividad { get; set; }
        public string Tipo_de_Actividad_Descripcion { get; set; }
        public int? Especialidad { get; set; }
        public string Especialidad_Especialidad { get; set; }
        public int? Imparte { get; set; }
        public string Imparte_Name { get; set; }
        public DateTime? Fecha { get; set; }
        public int? Lugares_disponibles { get; set; }
        public string Horarios_disponibles { get; set; }
        public string Ubicacion { get; set; }

    }
}
