using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllDificultad_de_platillos : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Dificultad_de_platillos_Clave { get; set; }
        public string Dificultad_de_platillos_Categoria { get; set; }

    }
}
