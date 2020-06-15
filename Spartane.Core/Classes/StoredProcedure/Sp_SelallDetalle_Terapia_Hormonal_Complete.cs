using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallDetalle_Terapia_Hormonal_Complete : BaseEntity
    {
        public int Folio { get; set; }
        public int Folio_Pacientes { get; set; }
        public string Nombre { get; set; }
        public string Dosis { get; set; }

    }
}
