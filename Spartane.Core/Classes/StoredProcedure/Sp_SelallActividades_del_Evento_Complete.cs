using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallActividades_del_Evento_Complete : BaseEntity
    {
        public int Folio { get; set; }
        public DateTime? Fecha_de_Registro { get; set; }
        public string Hora_de_Registro { get; set; }
        public int? Usuario_que_Registra { get; set; }
        public string Usuario_que_Registra_Name { get; set; }
        public int? Evento { get; set; }
        public string Evento_Nombre_del_Evento { get; set; }
        public int? Actividad { get; set; }
        public string Actividad_Nombre_de_la_Actividad { get; set; }
        public string Descripcion { get; set; }
        public DateTime? Dia { get; set; }
        public string Hora_inicio { get; set; }
        public string Hora_fin { get; set; }
        public bool? Tiene_receso { get; set; }
        public string Hora_inicio_receso { get; set; }
        public string Hora_fin_receso { get; set; }
        public int? Ubicacion { get; set; }
        public string Ubicacion_Nombre { get; set; }
        public int? Tipo_de_Actividad { get; set; }
        public string Tipo_de_Actividad_Descripcion { get; set; }
        public int? Quien_imparte { get; set; }
        public string Quien_imparte_Name { get; set; }
        public int? Especialidad { get; set; }
        public string Especialidad_Especialidad { get; set; }
        public bool? Cupo_limitado { get; set; }
        public int? Cupo_maximo { get; set; }
        public int? Duracion_maxima_por_Paciente_mins { get; set; }
        public int? Estatus { get; set; }
        public string Estatus_Descripcion { get; set; }

    }
}
