using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllActividades_del_Evento : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Actividades_del_Evento_Folio { get; set; }
        public DateTime? Actividades_del_Evento_Fecha_de_Registro { get; set; }
        public string Actividades_del_Evento_Hora_de_Registro { get; set; }
        public int? Actividades_del_Evento_Usuario_que_Registra { get; set; }
        public string Actividades_del_Evento_Usuario_que_Registra_Name { get; set; }
        public int? Actividades_del_Evento_Evento { get; set; }
        public string Actividades_del_Evento_Evento_Nombre_del_Evento { get; set; }
        public int? Actividades_del_Evento_Actividad { get; set; }
        public string Actividades_del_Evento_Actividad_Nombre_de_la_Actividad { get; set; }
        public string Actividades_del_Evento_Descripcion { get; set; }
        public DateTime? Actividades_del_Evento_Dia { get; set; }
        public string Actividades_del_Evento_Hora_inicio { get; set; }
        public string Actividades_del_Evento_Hora_fin { get; set; }
        public bool? Actividades_del_Evento_Tiene_receso { get; set; }
        public string Actividades_del_Evento_Hora_inicio_receso { get; set; }
        public string Actividades_del_Evento_Hora_fin_receso { get; set; }
        public int? Actividades_del_Evento_Ubicacion { get; set; }
        public string Actividades_del_Evento_Ubicacion_Nombre { get; set; }
        public int? Actividades_del_Evento_Tipo_de_Actividad { get; set; }
        public string Actividades_del_Evento_Tipo_de_Actividad_Descripcion { get; set; }
        public int? Actividades_del_Evento_Quien_imparte { get; set; }
        public string Actividades_del_Evento_Quien_imparte_Name { get; set; }
        public int? Actividades_del_Evento_Especialidad { get; set; }
        public string Actividades_del_Evento_Especialidad_Especialidad { get; set; }
        public bool? Actividades_del_Evento_Cupo_limitado { get; set; }
        public int? Actividades_del_Evento_Cupo_maximo { get; set; }
        public int? Actividades_del_Evento_Duracion_maxima_por_Paciente_mins { get; set; }
        public int? Actividades_del_Evento_Estatus { get; set; }
        public string Actividades_del_Evento_Estatus_Descripcion { get; set; }

    }
}
