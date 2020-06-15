using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallDetalle_Registro_en_Actividad_Evento_Complete : BaseEntity
    {
        public int Folio { get; set; }
        public int Folio_Registro_Evento { get; set; }
        public int? Actividad { get; set; }
        public string Actividad_Nombre_de_la_Actividad { get; set; }
        public DateTime? Fecha { get; set; }
        public string Horario { get; set; }
        public bool? Es_para_un_familiar { get; set; }
        public string Numero_de_Empleado { get; set; }
        public string Nombres { get; set; }
        public string Apellido_Paterno { get; set; }
        public string Apellido_Materno { get; set; }
        public string Nombre_Completo { get; set; }
        public int? Parentesco { get; set; }
        public string Parentesco_Descripcion { get; set; }
        public int? Sexo { get; set; }
        public string Sexo_Descripcion { get; set; }
        public DateTime? Fecha_de_nacimiento { get; set; }
        public int? Estatus_de_la_Reservacion { get; set; }
        public string Estatus_de_la_Reservacion_Descripcion { get; set; }
        public string Codigo_Reservacion { get; set; }

    }
}
