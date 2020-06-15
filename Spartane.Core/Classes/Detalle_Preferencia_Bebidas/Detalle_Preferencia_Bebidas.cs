using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Classes.Pacientes;
using Spartane.Core.Classes.Bebidas;
using Spartane.Core.Classes.Rango_Consumo_Bebidas;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Detalle_Preferencia_Bebidas
{
    /// <summary>
    /// Detalle_Preferencia_Bebidas table
    /// </summary>
    public class Detalle_Preferencia_Bebidas: BaseEntity
    {
        public int Folio { get; set; }
        public int? Folio_Pacientes { get; set; }
        public int? Bebida { get; set; }
        public int? Cantidad { get; set; }

        [ForeignKey("Folio_Pacientes")]
        public virtual Spartane.Core.Classes.Pacientes.Pacientes Folio_Pacientes_Pacientes { get; set; }
        [ForeignKey("Bebida")]
        public virtual Spartane.Core.Classes.Bebidas.Bebidas Bebida_Bebidas { get; set; }
        [ForeignKey("Cantidad")]
        public virtual Spartane.Core.Classes.Rango_Consumo_Bebidas.Rango_Consumo_Bebidas Cantidad_Rango_Consumo_Bebidas { get; set; }

    }
}

