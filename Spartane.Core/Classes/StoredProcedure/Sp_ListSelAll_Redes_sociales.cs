using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllRedes_sociales : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Redes_sociales_Clave { get; set; }
        public string Redes_sociales_Descripcion { get; set; }
        public string Redes_sociales_Direccion_URL { get; set; }

    }
}
