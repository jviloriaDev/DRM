using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllRegistro_de_Asistencia_Telefonica : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Registro_de_Asistencia_Telefonica_Folio { get; set; }
        public DateTime? Registro_de_Asistencia_Telefonica_Fecha_de_llamada { get; set; }
        public string Registro_de_Asistencia_Telefonica_Hora_de_llamada { get; set; }
        public int? Registro_de_Asistencia_Telefonica_Usuario_que_llama { get; set; }
        public string Registro_de_Asistencia_Telefonica_Usuario_que_llama_Name { get; set; }
        public string Registro_de_Asistencia_Telefonica_Dispositivo { get; set; }
        public int? Registro_de_Asistencia_Telefonica_Nombre_Paciente { get; set; }
        public string Registro_de_Asistencia_Telefonica_Nombre_Paciente_Nombre_Completo { get; set; }
        public int? Registro_de_Asistencia_Telefonica_Suscripcion { get; set; }
        public string Registro_de_Asistencia_Telefonica_Suscripcion_Nombre_del_Plan { get; set; }
        public string Registro_de_Asistencia_Telefonica_Numero_telefonico_del_Paciente { get; set; }
        public string Registro_de_Asistencia_Telefonica_Correo_del_Paciente { get; set; }
        public string Registro_de_Asistencia_Telefonica_Telefono_de_Asistencia_marcado { get; set; }
        public string Registro_de_Asistencia_Telefonica_Hora_inicio_de_la_Llamada { get; set; }
        public string Registro_de_Asistencia_Telefonica_Hora_fin_de_la_Llamada { get; set; }
        public decimal? Registro_de_Asistencia_Telefonica_Duracion_minutos { get; set; }
        public int? Registro_de_Asistencia_Telefonica_Asunto_de_la_Llamada { get; set; }
        public string Registro_de_Asistencia_Telefonica_Asunto_de_la_Llamada_Descripcion { get; set; }
        public int? Registro_de_Asistencia_Telefonica_Atendio { get; set; }
        public string Registro_de_Asistencia_Telefonica_Atendio_Name { get; set; }
        public string Registro_de_Asistencia_Telefonica_Comentarios { get; set; }
        public int? Registro_de_Asistencia_Telefonica_Estatus { get; set; }
        public string Registro_de_Asistencia_Telefonica_Estatus_Descripcion { get; set; }

    }
}
