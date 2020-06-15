using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllInterpretacion_de_porcentaje_de_grasa_corporal : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Interpretacion_de_porcentaje_de_grasa_corporal_Folio { get; set; }
        public string Interpretacion_de_porcentaje_de_grasa_corporal_Descripcion { get; set; }

    }
}
