using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Classes.Registro_en_Evento;
using Spartane.Core.Classes.Detalle_Actividades_Evento;
using Spartane.Core.Classes.Parentescos_Empleados;
using Spartane.Core.Classes.Sexo;
using Spartane.Core.Classes.Estatus_Reservaciones_Actividad;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Detalle_Registro_en_Actividad_Evento
{
    /// <summary>
    /// Detalle_Registro_en_Actividad_Evento table
    /// </summary>
    public class Detalle_Registro_en_Actividad_Evento: BaseEntity
    {
        public int Folio { get; set; }
        public int? Folio_Registro_Evento { get; set; }
        public int? Actividad { get; set; }
        public DateTime? Fecha { get; set; }
        public string Horario { get; set; }
        public bool? Es_para_un_familiar { get; set; }
        public string Numero_de_Empleado { get; set; }
        public string Nombres { get; set; }
        public string Apellido_Paterno { get; set; }
        public string Apellido_Materno { get; set; }
        public string Nombre_Completo { get; set; }
        public int? Parentesco { get; set; }
        public int? Sexo { get; set; }
        public DateTime? Fecha_de_nacimiento { get; set; }
        public int? Estatus_de_la_Reservacion { get; set; }
        public string Codigo_Reservacion { get; set; }

        [ForeignKey("Folio_Registro_Evento")]
        public virtual Spartane.Core.Classes.Registro_en_Evento.Registro_en_Evento Folio_Registro_Evento_Registro_en_Evento { get; set; }
        [ForeignKey("Actividad")]
        public virtual Spartane.Core.Classes.Detalle_Actividades_Evento.Detalle_Actividades_Evento Actividad_Detalle_Actividades_Evento { get; set; }
        [ForeignKey("Parentesco")]
        public virtual Spartane.Core.Classes.Parentescos_Empleados.Parentescos_Empleados Parentesco_Parentescos_Empleados { get; set; }
        [ForeignKey("Sexo")]
        public virtual Spartane.Core.Classes.Sexo.Sexo Sexo_Sexo { get; set; }
        [ForeignKey("Estatus_de_la_Reservacion")]
        public virtual Spartane.Core.Classes.Estatus_Reservaciones_Actividad.Estatus_Reservaciones_Actividad Estatus_de_la_Reservacion_Estatus_Reservaciones_Actividad { get; set; }

    }
}

