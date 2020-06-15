using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallDetalle_Horarios_Actividad_Complete : BaseEntity
    {
        public int Folio { get; set; }
        public int Folio_Actividades { get; set; }
        public bool? Reservada { get; set; }
        public int? Numero_de_Cita { get; set; }
        public string Hora_inicio { get; set; }
        public string Hora_fin { get; set; }
        public string Horario { get; set; }
        public int? Codigo_de_Reservacion { get; set; }
        public string Codigo_de_Reservacion_Codigo_Reservacion { get; set; }
        public string Numero_de_Empleado { get; set; }
        public bool? Familiar_del_Empleado { get; set; }
        public string Nombre_Completo { get; set; }
        public int? Parentesco_con_el_Empleado { get; set; }
        public string Parentesco_con_el_Empleado_Descripcion { get; set; }
        public int? Sexo { get; set; }
        public string Sexo_Descripcion { get; set; }
        public int? Edad { get; set; }
        public int? Estatus_de_la_Reservacion { get; set; }
        public string Estatus_de_la_Reservacion_Descripcion { get; set; }
        public bool? Asistio { get; set; }

    }
}
