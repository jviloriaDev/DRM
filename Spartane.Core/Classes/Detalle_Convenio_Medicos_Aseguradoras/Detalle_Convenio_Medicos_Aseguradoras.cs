using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Classes.Medicos;
using Spartane.Core.Classes.Aseguradoras;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Detalle_Convenio_Medicos_Aseguradoras
{
    /// <summary>
    /// Detalle_Convenio_Medicos_Aseguradoras table
    /// </summary>
    public class Detalle_Convenio_Medicos_Aseguradoras: BaseEntity
    {
        public int Folio { get; set; }
        public int? Folio_Medicos { get; set; }
        public int? Aseguradora_medico { get; set; }

        [ForeignKey("Folio_Medicos")]
        public virtual Spartane.Core.Classes.Medicos.Medicos Folio_Medicos_Medicos { get; set; }
        [ForeignKey("Aseguradora_medico")]
        public virtual Spartane.Core.Classes.Aseguradoras.Aseguradoras Aseguradora_medico_Aseguradoras { get; set; }

    }
}

