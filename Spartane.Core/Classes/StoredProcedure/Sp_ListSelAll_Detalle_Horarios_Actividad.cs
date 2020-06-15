using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllDetalle_Horarios_Actividad : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Detalle_Horarios_Actividad_Folio { get; set; }
        public int Detalle_Horarios_Actividad_Folio_Actividades { get; set; }
        public bool? Detalle_Horarios_Actividad_Reservada { get; set; }
        public int? Detalle_Horarios_Actividad_Numero_de_Cita { get; set; }
        public string Detalle_Horarios_Actividad_Hora_inicio { get; set; }
        public string Detalle_Horarios_Actividad_Hora_fin { get; set; }
        public string Detalle_Horarios_Actividad_Horario { get; set; }
        public int? Detalle_Horarios_Actividad_Codigo_de_Reservacion { get; set; }
        public string Detalle_Horarios_Actividad_Codigo_de_Reservacion_Codigo_Reservacion { get; set; }
        public string Detalle_Horarios_Actividad_Numero_de_Empleado { get; set; }
        public bool? Detalle_Horarios_Actividad_Familiar_del_Empleado { get; set; }
        public string Detalle_Horarios_Actividad_Nombre_Completo { get; set; }
        public int? Detalle_Horarios_Actividad_Parentesco_con_el_Empleado { get; set; }
        public string Detalle_Horarios_Actividad_Parentesco_con_el_Empleado_Descripcion { get; set; }
        public int? Detalle_Horarios_Actividad_Sexo { get; set; }
        public string Detalle_Horarios_Actividad_Sexo_Descripcion { get; set; }
        public int? Detalle_Horarios_Actividad_Edad { get; set; }
        public int? Detalle_Horarios_Actividad_Estatus_de_la_Reservacion { get; set; }
        public string Detalle_Horarios_Actividad_Estatus_de_la_Reservacion_Descripcion { get; set; }
        public bool? Detalle_Horarios_Actividad_Asistio { get; set; }

    }
}
