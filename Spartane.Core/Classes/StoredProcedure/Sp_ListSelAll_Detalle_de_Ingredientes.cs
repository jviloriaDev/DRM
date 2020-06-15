using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllDetalle_de_Ingredientes : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Detalle_de_Ingredientes_Clave { get; set; }
        public string Detalle_de_Ingredientes_Cantidad { get; set; }
        public int? Detalle_de_Ingredientes_Unidad { get; set; }
        public string Detalle_de_Ingredientes_Unidad_Unidad { get; set; }
        public int? Detalle_de_Ingredientes_Nombre_del_Ingrediente { get; set; }
        public string Detalle_de_Ingredientes_Nombre_del_Ingrediente_Nombre_Ingrediente { get; set; }
        public int? Detalle_de_Ingredientes_Nombre_de_presentacion { get; set; }
        public string Detalle_de_Ingredientes_Nombre_de_presentacion_Descripcion { get; set; }
        public int? Detalle_de_Ingredientes_Nombre_de_Marca { get; set; }
        public string Detalle_de_Ingredientes_Nombre_de_Marca_Descripcion { get; set; }
        public int Detalle_de_Ingredientes_Platillos { get; set; }

    }
}
