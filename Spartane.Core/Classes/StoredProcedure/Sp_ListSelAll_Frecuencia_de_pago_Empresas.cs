using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllFrecuencia_de_pago_Empresas : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Frecuencia_de_pago_Empresas_Clave { get; set; }
        public string Frecuencia_de_pago_Empresas_Nombre { get; set; }

    }
}
