using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllDetalle_Consulta_Actividades_Registro_Evento : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Detalle_Consulta_Actividades_Registro_Evento_Folio { get; set; }
        public int Detalle_Consulta_Actividades_Registro_Evento_Folio_Registro_Evento { get; set; }
        public int? Detalle_Consulta_Actividades_Registro_Evento_Actividad { get; set; }
        public string Detalle_Consulta_Actividades_Registro_Evento_Actividad_Nombre_de_la_Actividad { get; set; }
        public int? Detalle_Consulta_Actividades_Registro_Evento_Tipo_de_Actividad { get; set; }
        public string Detalle_Consulta_Actividades_Registro_Evento_Tipo_de_Actividad_Descripcion { get; set; }
        public int? Detalle_Consulta_Actividades_Registro_Evento_Especialidad { get; set; }
        public string Detalle_Consulta_Actividades_Registro_Evento_Especialidad_Especialidad { get; set; }
        public int? Detalle_Consulta_Actividades_Registro_Evento_Imparte { get; set; }
        public string Detalle_Consulta_Actividades_Registro_Evento_Imparte_Name { get; set; }
        public DateTime? Detalle_Consulta_Actividades_Registro_Evento_Fecha { get; set; }
        public int? Detalle_Consulta_Actividades_Registro_Evento_Lugares_disponibles { get; set; }
        public string Detalle_Consulta_Actividades_Registro_Evento_Horarios_disponibles { get; set; }
        public string Detalle_Consulta_Actividades_Registro_Evento_Ubicacion { get; set; }

    }
}
