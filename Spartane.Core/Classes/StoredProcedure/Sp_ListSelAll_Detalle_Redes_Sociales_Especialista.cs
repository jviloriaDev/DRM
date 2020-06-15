using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllDetalle_Redes_Sociales_Especialista : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Detalle_Redes_Sociales_Especialista_Folio { get; set; }
        public int Detalle_Redes_Sociales_Especialista_Folio_Especialistas { get; set; }
        public int? Detalle_Redes_Sociales_Especialista_Red_Social { get; set; }
        public string Detalle_Redes_Sociales_Especialista_Red_Social_Descripcion { get; set; }
        public string Detalle_Redes_Sociales_Especialista_URL { get; set; }
        public bool? Detalle_Redes_Sociales_Especialista_Principal { get; set; }

    }
}
