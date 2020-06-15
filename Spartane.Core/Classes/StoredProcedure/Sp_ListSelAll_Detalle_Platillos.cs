using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllDetalle_Platillos : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Detalle_Platillos_Folio { get; set; }
        public int Detalle_Platillos_Folio_Platillos { get; set; }
        public bool? Detalle_Platillos_Lleva_fracciones { get; set; }
        public int? Detalle_Platillos_Cantidad { get; set; }
        public int? Detalle_Platillos_Cantidad_fraccion { get; set; }
        public string Detalle_Platillos_Cantidad_fraccion_Cantidad { get; set; }
        public int? Detalle_Platillos_Unidad { get; set; }
        public int? Detalle_Platillos_Ingrediente { get; set; }
        public string Detalle_Platillos_Ingrediente_Nombre_Ingrediente { get; set; }
        public string Detalle_Platillos_Caracteristica { get; set; }
        public int? Detalle_Platillos_Unidad_SMAE { get; set; }
        public int? Detalle_Platillos_Equivalente_Unidad_SMAE { get; set; }
        public int? Detalle_Platillos_Porciones { get; set; }
        public string Detalle_Platillos_Detalle { get; set; }
        public string Detalle_Platillos_Detalle_Super { get; set; }

    }
}
