using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllBancos : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Bancos_Clave { get; set; }
        public string Bancos_Nombre { get; set; }
        public string Bancos_Nombre_Completo { get; set; }
        public string Bancos_Codigo { get; set; }

    }
}
