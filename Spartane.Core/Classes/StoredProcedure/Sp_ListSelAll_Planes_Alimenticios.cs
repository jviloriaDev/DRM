using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllPlanes_Alimenticios : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Planes_Alimenticios_Folio { get; set; }
        public DateTime? Planes_Alimenticios_Fecha_de_Registro { get; set; }
        public string Planes_Alimenticios_Hora_de_Registro { get; set; }
        public int? Planes_Alimenticios_Usuario_que_Registra { get; set; }
        public string Planes_Alimenticios_Usuario_que_Registra_Name { get; set; }
        public DateTime? Planes_Alimenticios_Fecha_inicio_del_Plan { get; set; }
        public DateTime? Planes_Alimenticios_Fecha_fin_del_Plan { get; set; }
        public int? Planes_Alimenticios_Semana { get; set; }
        public int? Planes_Alimenticios_Paciente { get; set; }
        public string Planes_Alimenticios_Paciente_Nombre_Completo { get; set; }
        public int? Planes_Alimenticios_Estatus { get; set; }
        public string Planes_Alimenticios_Estatus_Descripcion { get; set; }

    }
}
