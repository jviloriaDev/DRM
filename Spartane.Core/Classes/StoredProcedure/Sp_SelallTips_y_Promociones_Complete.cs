using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallTips_y_Promociones_Complete : BaseEntity
    {
        public int Folio { get; set; }
        public DateTime? Fecha_de_registro { get; set; }
        public string Hora_de_Registro { get; set; }
        public int? Usuario_que_Registra { get; set; }
        public string Usuario_que_Registra_Name { get; set; }
        public string Nombre { get; set; }
        public string Descripcion_Corta { get; set; }
        public string Descripcion_Larga { get; set; }
        public int? Imagen { get; set; }
        public DateTime? Fecha_inicio_de_Vigencia { get; set; }
        public DateTime? Fecha_fin_de_Vigencia { get; set; }
        public int? Especialidad { get; set; }
        public string Especialidad_Especialidad { get; set; }
        public int? Especialista { get; set; }
        public string Especialista_Nombre_Completo { get; set; }
        public int? Vendedor { get; set; }
        public string Vendedor_Name { get; set; }
        public int? Estatus { get; set; }
        public string Estatus_Descripcion { get; set; }

    }
}
