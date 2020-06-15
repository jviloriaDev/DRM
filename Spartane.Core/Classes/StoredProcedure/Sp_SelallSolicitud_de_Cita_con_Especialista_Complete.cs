using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallSolicitud_de_Cita_con_Especialista_Complete : BaseEntity
    {
        public int Folio { get; set; }
        public DateTime? Fecha_de_solicitud { get; set; }
        public string Hora_de_solicitud { get; set; }
        public int? Usuario_que_solicita { get; set; }
        public string Usuario_que_solicita_Name { get; set; }
        public string Nombre_Completo { get; set; }
        public string Correo_del_Paciente { get; set; }
        public string Celular_del_Paciente { get; set; }
        public int? Especialista { get; set; }
        public string Especialista_Nombre_Completo { get; set; }
        public string Correo_del_Especialista { get; set; }
        public bool? Correo_enviado { get; set; }
        public DateTime? Fecha_de_Retroalimentacion { get; set; }
        public string Hora_de_Retroalimentacion { get; set; }
        public int? Asististe_a_tu_cita { get; set; }
        public string Asististe_a_tu_cita_Descripcion { get; set; }
        public int? Calificacion_Especialista { get; set; }
        public string Calificacion_Especialista_Descripcion { get; set; }
        public int? Motivo_no_concreto_cita { get; set; }
        public string Motivo_no_concreto_cita_Descripcion { get; set; }

    }
}
