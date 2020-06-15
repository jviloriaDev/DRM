using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllFormas_de_Pago : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Formas_de_Pago_Clave { get; set; }
        public string Formas_de_Pago_Nombre { get; set; }

    }
}
