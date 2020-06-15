using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallDetalle_Examenes_Laboratorio_Complete : BaseEntity
    {
        public int Folio { get; set; }
        public int Folio_Pacientes { get; set; }
        public int? Indicador { get; set; }
        public string Indicador_Indicador { get; set; }
        public int? Resultado { get; set; }
        public string Unidad { get; set; }
        public string Intervalo_de_Referencia { get; set; }
        public DateTime? Fecha_de_Resultado { get; set; }
        public string Estatus_Indicador { get; set; }

    }
}
