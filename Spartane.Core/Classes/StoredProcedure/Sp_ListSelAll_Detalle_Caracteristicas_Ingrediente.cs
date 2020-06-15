using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllDetalle_Caracteristicas_Ingrediente : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Detalle_Caracteristicas_Ingrediente_Folio { get; set; }
        public int Detalle_Caracteristicas_Ingrediente_Folio_Ingrediente { get; set; }
        public string Detalle_Caracteristicas_Ingrediente_Caracteristica_combo { get; set; }
        public string Detalle_Caracteristicas_Ingrediente_Descripcion_texto { get; set; }

    }
}
