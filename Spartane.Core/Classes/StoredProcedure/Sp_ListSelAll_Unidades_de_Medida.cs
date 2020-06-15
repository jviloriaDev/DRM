using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllUnidades_de_Medida : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Unidades_de_Medida_Clave { get; set; }
        public string Unidades_de_Medida_Unidad { get; set; }
        public string Unidades_de_Medida_Abreviacion { get; set; }
        public string Unidades_de_Medida_Texto_Singular { get; set; }
        public string Unidades_de_Medida_Texto_Plural { get; set; }

    }
}
