using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllSolicitud_de_Cita_con_Especialista : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Solicitud_de_Cita_con_Especialista_Folio { get; set; }
        public DateTime? Solicitud_de_Cita_con_Especialista_Fecha_de_solicitud { get; set; }
        public string Solicitud_de_Cita_con_Especialista_Hora_de_solicitud { get; set; }
        public int? Solicitud_de_Cita_con_Especialista_Usuario_que_solicita { get; set; }
        public string Solicitud_de_Cita_con_Especialista_Usuario_que_solicita_Name { get; set; }
        public string Solicitud_de_Cita_con_Especialista_Nombre_Completo { get; set; }
        public string Solicitud_de_Cita_con_Especialista_Correo_del_Paciente { get; set; }
        public string Solicitud_de_Cita_con_Especialista_Celular_del_Paciente { get; set; }
        public int? Solicitud_de_Cita_con_Especialista_Especialista { get; set; }
        public string Solicitud_de_Cita_con_Especialista_Especialista_Nombre_Completo { get; set; }
        public string Solicitud_de_Cita_con_Especialista_Correo_del_Especialista { get; set; }
        public bool? Solicitud_de_Cita_con_Especialista_Correo_enviado { get; set; }
        public DateTime? Solicitud_de_Cita_con_Especialista_Fecha_de_Retroalimentacion { get; set; }
        public string Solicitud_de_Cita_con_Especialista_Hora_de_Retroalimentacion { get; set; }
        public int? Solicitud_de_Cita_con_Especialista_Asististe_a_tu_cita { get; set; }
        public string Solicitud_de_Cita_con_Especialista_Asististe_a_tu_cita_Descripcion { get; set; }
        public int? Solicitud_de_Cita_con_Especialista_Calificacion_Especialista { get; set; }
        public string Solicitud_de_Cita_con_Especialista_Calificacion_Especialista_Descripcion { get; set; }
        public int? Solicitud_de_Cita_con_Especialista_Motivo_no_concreto_cita { get; set; }
        public string Solicitud_de_Cita_con_Especialista_Motivo_no_concreto_cita_Descripcion { get; set; }

    }
}
