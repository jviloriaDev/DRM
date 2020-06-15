using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallPlanes_Alimenticios_Complete : BaseEntity
    {
        public int Folio { get; set; }
        public DateTime? Fecha_de_Registro { get; set; }
        public string Hora_de_Registro { get; set; }
        public int? Usuario_que_Registra { get; set; }
        public string Usuario_que_Registra_Name { get; set; }
        public DateTime? Fecha_inicio_del_Plan { get; set; }
        public DateTime? Fecha_fin_del_Plan { get; set; }
        public int? Semana { get; set; }
        public int? Paciente { get; set; }
        public string Paciente_Nombre_Completo { get; set; }
        public int? Estatus { get; set; }
        public string Estatus_Descripcion { get; set; }

    }
}
