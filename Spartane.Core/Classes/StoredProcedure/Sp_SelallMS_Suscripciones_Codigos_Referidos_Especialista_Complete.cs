using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallMS_Suscripciones_Codigos_Referidos_Especialista_Complete : BaseEntity
    {
        public int Folio { get; set; }
        public int Folio_Codigos { get; set; }
        public int? Plan_de_Suscripcion { get; set; }
        public string Plan_de_Suscripcion_Nombre_del_Plan { get; set; }

    }
}
