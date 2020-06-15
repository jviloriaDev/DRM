using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllMS_Suscripciones_Codigos_Referidos_Especialista : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int MS_Suscripciones_Codigos_Referidos_Especialista_Folio { get; set; }
        public int MS_Suscripciones_Codigos_Referidos_Especialista_Folio_Codigos { get; set; }
        public int? MS_Suscripciones_Codigos_Referidos_Especialista_Plan_de_Suscripcion { get; set; }
        public string MS_Suscripciones_Codigos_Referidos_Especialista_Plan_de_Suscripcion_Nombre_del_Plan { get; set; }

    }
}
