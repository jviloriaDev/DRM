using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllDetalle_Actividades_Evento : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Detalle_Actividades_Evento_Folio { get; set; }
        public int Detalle_Actividades_Evento_Folio_Eventos { get; set; }
        public int? Detalle_Actividades_Evento_Tipo_de_Actividad { get; set; }
        public string Detalle_Actividades_Evento_Tipo_de_Actividad_Descripcion { get; set; }
        public int? Detalle_Actividades_Evento_Especialidad { get; set; }
        public string Detalle_Actividades_Evento_Especialidad_Especialidad { get; set; }
        public string Detalle_Actividades_Evento_Nombre_de_la_Actividad { get; set; }
        public string Detalle_Actividades_Evento_Descripcion { get; set; }
        public int? Detalle_Actividades_Evento_Quien_imparte { get; set; }
        public string Detalle_Actividades_Evento_Quien_imparte_Name { get; set; }
        public DateTime? Detalle_Actividades_Evento_Dia { get; set; }
        public string Detalle_Actividades_Evento_Hora_inicio { get; set; }
        public string Detalle_Actividades_Evento_Hora_fin { get; set; }
        public bool? Detalle_Actividades_Evento_Tiene_receso { get; set; }
        public string Detalle_Actividades_Evento_Hora_inicio_receso { get; set; }
        public string Detalle_Actividades_Evento_Hora_fin_receso { get; set; }
        public int? Detalle_Actividades_Evento_Duracion_maxima_por_paciente_mins { get; set; }
        public bool? Detalle_Actividades_Evento_Cupo_limitado { get; set; }
        public int? Detalle_Actividades_Evento_Cupo_maximo { get; set; }
        public int? Detalle_Actividades_Evento_Ubicacion { get; set; }
        public string Detalle_Actividades_Evento_Ubicacion_Nombre { get; set; }
        public int? Detalle_Actividades_Evento_Estatus_de_la_Actividad { get; set; }
        public string Detalle_Actividades_Evento_Estatus_de_la_Actividad_Descripcion { get; set; }

    }
}
