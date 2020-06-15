using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllRango_Consumo_Bebidas : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Rango_Consumo_Bebidas_Clave { get; set; }
        public string Rango_Consumo_Bebidas_Descripcion { get; set; }

    }
}
