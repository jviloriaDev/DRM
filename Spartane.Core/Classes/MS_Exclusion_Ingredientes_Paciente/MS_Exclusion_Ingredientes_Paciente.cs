using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Classes.Pacientes;
using Spartane.Core.Classes.Ingredientes;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.MS_Exclusion_Ingredientes_Paciente
{
    /// <summary>
    /// MS_Exclusion_Ingredientes_Paciente table
    /// </summary>
    public class MS_Exclusion_Ingredientes_Paciente: BaseEntity
    {
        public int Folio { get; set; }
        public int? Folio_Pacientes { get; set; }
        public int? Ingrediente { get; set; }

        [ForeignKey("Folio_Pacientes")]
        public virtual Spartane.Core.Classes.Pacientes.Pacientes Folio_Pacientes_Pacientes { get; set; }
        [ForeignKey("Ingrediente")]
        public virtual Spartane.Core.Classes.Ingredientes.Ingredientes Ingrediente_Ingredientes { get; set; }

    }
}

