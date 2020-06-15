using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllPais : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Pais_Clave { get; set; }
        public string Pais_Nombre_del_Pais { get; set; }
        public string Pais_Abreviatura { get; set; }
        public string Pais_Codigo { get; set; }

    }
}
