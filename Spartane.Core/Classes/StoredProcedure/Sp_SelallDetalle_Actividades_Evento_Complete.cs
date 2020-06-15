using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallDetalle_Actividades_Evento_Complete : BaseEntity
    {
        public int Folio { get; set; }
        public int Folio_Eventos { get; set; }
        public int? Tipo_de_Actividad { get; set; }
        public string Tipo_de_Actividad_Descripcion { get; set; }
        public int? Especialidad { get; set; }
        public string Especialidad_Especialidad { get; set; }
        public string Nombre_de_la_Actividad { get; set; }
        public string Descripcion { get; set; }
        public int? Quien_imparte { get; set; }
        public string Quien_imparte_Name { get; set; }
        public DateTime? Dia { get; set; }
        public string Hora_inicio { get; set; }
        public string Hora_fin { get; set; }
        public bool? Tiene_receso { get; set; }
        public string Hora_inicio_receso { get; set; }
        public string Hora_fin_receso { get; set; }
        public int? Duracion_maxima_por_paciente_mins { get; set; }
        public bool? Cupo_limitado { get; set; }
        public int? Cupo_maximo { get; set; }
        public int? Ubicacion { get; set; }
        public string Ubicacion_Nombre { get; set; }
        public int? Estatus_de_la_Actividad { get; set; }
        public string Estatus_de_la_Actividad_Descripcion { get; set; }

    }
}
