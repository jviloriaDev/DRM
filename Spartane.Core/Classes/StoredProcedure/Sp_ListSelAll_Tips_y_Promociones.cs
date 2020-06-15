using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllTips_y_Promociones : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Tips_y_Promociones_Folio { get; set; }
        public DateTime? Tips_y_Promociones_Fecha_de_registro { get; set; }
        public string Tips_y_Promociones_Hora_de_Registro { get; set; }
        public int? Tips_y_Promociones_Usuario_que_Registra { get; set; }
        public string Tips_y_Promociones_Usuario_que_Registra_Name { get; set; }
        public string Tips_y_Promociones_Nombre { get; set; }
        public string Tips_y_Promociones_Descripcion_Corta { get; set; }
        public string Tips_y_Promociones_Descripcion_Larga { get; set; }
        public int? Tips_y_Promociones_Imagen { get; set; }
        public string Tips_y_Promociones_Imagen_Nombre { get; set; }
        public DateTime? Tips_y_Promociones_Fecha_inicio_de_Vigencia { get; set; }
        public DateTime? Tips_y_Promociones_Fecha_fin_de_Vigencia { get; set; }
        public int? Tips_y_Promociones_Especialidad { get; set; }
        public string Tips_y_Promociones_Especialidad_Especialidad { get; set; }
        public int? Tips_y_Promociones_Especialista { get; set; }
        public string Tips_y_Promociones_Especialista_Nombre_Completo { get; set; }
        public int? Tips_y_Promociones_Vendedor { get; set; }
        public string Tips_y_Promociones_Vendedor_Name { get; set; }
        public int? Tips_y_Promociones_Estatus { get; set; }
        public string Tips_y_Promociones_Estatus_Descripcion { get; set; }

    }
}
