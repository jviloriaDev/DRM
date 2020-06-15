using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallRegistro_de_Asistencia_Telefonica_Complete : BaseEntity
    {
        public int Folio { get; set; }
        public DateTime? Fecha_de_llamada { get; set; }
        public string Hora_de_llamada { get; set; }
        public int? Usuario_que_llama { get; set; }
        public string Usuario_que_llama_Name { get; set; }
        public string Dispositivo { get; set; }
        public int? Nombre_Paciente { get; set; }
        public string Nombre_Paciente_Nombre_Completo { get; set; }
        public int? Suscripcion { get; set; }
        public string Suscripcion_Nombre_del_Plan { get; set; }
        public string Numero_telefonico_del_Paciente { get; set; }
        public string Correo_del_Paciente { get; set; }
        public string Telefono_de_Asistencia_marcado { get; set; }
        public string Hora_inicio_de_la_Llamada { get; set; }
        public string Hora_fin_de_la_Llamada { get; set; }
        public decimal? Duracion_minutos { get; set; }
        public int? Asunto_de_la_Llamada { get; set; }
        public string Asunto_de_la_Llamada_Descripcion { get; set; }
        public int? Atendio { get; set; }
        public string Atendio_Name { get; set; }
        public string Comentarios { get; set; }
        public int? Estatus { get; set; }
        public string Estatus_Descripcion { get; set; }

    }
}
