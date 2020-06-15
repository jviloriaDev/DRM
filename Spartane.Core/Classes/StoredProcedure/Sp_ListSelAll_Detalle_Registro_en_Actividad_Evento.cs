using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllDetalle_Registro_en_Actividad_Evento : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Detalle_Registro_en_Actividad_Evento_Folio { get; set; }
        public int Detalle_Registro_en_Actividad_Evento_Folio_Registro_Evento { get; set; }
        public int? Detalle_Registro_en_Actividad_Evento_Actividad { get; set; }
        public string Detalle_Registro_en_Actividad_Evento_Actividad_Nombre_de_la_Actividad { get; set; }
        public DateTime? Detalle_Registro_en_Actividad_Evento_Fecha { get; set; }
        public string Detalle_Registro_en_Actividad_Evento_Horario { get; set; }
        public bool? Detalle_Registro_en_Actividad_Evento_Es_para_un_familiar { get; set; }
        public string Detalle_Registro_en_Actividad_Evento_Numero_de_Empleado { get; set; }
        public string Detalle_Registro_en_Actividad_Evento_Nombres { get; set; }
        public string Detalle_Registro_en_Actividad_Evento_Apellido_Paterno { get; set; }
        public string Detalle_Registro_en_Actividad_Evento_Apellido_Materno { get; set; }
        public string Detalle_Registro_en_Actividad_Evento_Nombre_Completo { get; set; }
        public int? Detalle_Registro_en_Actividad_Evento_Parentesco { get; set; }
        public string Detalle_Registro_en_Actividad_Evento_Parentesco_Descripcion { get; set; }
        public int? Detalle_Registro_en_Actividad_Evento_Sexo { get; set; }
        public string Detalle_Registro_en_Actividad_Evento_Sexo_Descripcion { get; set; }
        public DateTime? Detalle_Registro_en_Actividad_Evento_Fecha_de_nacimiento { get; set; }
        public int? Detalle_Registro_en_Actividad_Evento_Estatus_de_la_Reservacion { get; set; }
        public string Detalle_Registro_en_Actividad_Evento_Estatus_de_la_Reservacion_Descripcion { get; set; }
        public string Detalle_Registro_en_Actividad_Evento_Codigo_Reservacion { get; set; }

    }
}
