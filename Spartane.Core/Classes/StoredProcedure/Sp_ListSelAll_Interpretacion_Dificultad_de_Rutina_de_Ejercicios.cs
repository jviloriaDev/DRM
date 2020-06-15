using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllInterpretacion_Dificultad_de_Rutina_de_Ejercicios : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Interpretacion_Dificultad_de_Rutina_de_Ejercicios_Folio { get; set; }
        public string Interpretacion_Dificultad_de_Rutina_de_Ejercicios_Descripcion { get; set; }

    }
}
