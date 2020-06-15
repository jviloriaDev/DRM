using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Classes.Spartan_User;
using Spartane.Core.Classes.Medicos;
using Spartane.Core.Classes.Respuesta_Logica;
using Spartane.Core.Classes.Calificacion;
using Spartane.Core.Classes.Motivos;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Solicitud_de_Cita_con_Especialista
{
    /// <summary>
    /// Solicitud_de_Cita_con_Especialista table
    /// </summary>
    public class Solicitud_de_Cita_con_Especialista: BaseEntity
    {
        public int Folio { get; set; }
        public DateTime? Fecha_de_solicitud { get; set; }
        public string Hora_de_solicitud { get; set; }
        public int? Usuario_que_solicita { get; set; }
        public string Nombre_Completo { get; set; }
        public string Correo_del_Paciente { get; set; }
        public string Celular_del_Paciente { get; set; }
        public int? Especialista { get; set; }
        public string Correo_del_Especialista { get; set; }
        public bool? Correo_enviado { get; set; }
        public DateTime? Fecha_de_Retroalimentacion { get; set; }
        public string Hora_de_Retroalimentacion { get; set; }
        public int? Asististe_a_tu_cita { get; set; }
        public int? Calificacion_Especialista { get; set; }
        public int? Motivo_no_concreto_cita { get; set; }

        [ForeignKey("Usuario_que_solicita")]
        public virtual Spartane.Core.Classes.Spartan_User.Spartan_User Usuario_que_solicita_Spartan_User { get; set; }
        [ForeignKey("Especialista")]
        public virtual Spartane.Core.Classes.Medicos.Medicos Especialista_Medicos { get; set; }
        [ForeignKey("Asististe_a_tu_cita")]
        public virtual Spartane.Core.Classes.Respuesta_Logica.Respuesta_Logica Asististe_a_tu_cita_Respuesta_Logica { get; set; }
        [ForeignKey("Calificacion_Especialista")]
        public virtual Spartane.Core.Classes.Calificacion.Calificacion Calificacion_Especialista_Calificacion { get; set; }
        [ForeignKey("Motivo_no_concreto_cita")]
        public virtual Spartane.Core.Classes.Motivos.Motivos Motivo_no_concreto_cita_Motivos { get; set; }

    }
}

