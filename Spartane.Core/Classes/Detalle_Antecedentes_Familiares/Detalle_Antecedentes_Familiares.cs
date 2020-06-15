using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Classes.Pacientes;
using Spartane.Core.Classes.Padecimientos;
using Spartane.Core.Classes.Parentesco;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Detalle_Antecedentes_Familiares
{
    /// <summary>
    /// Detalle_Antecedentes_Familiares table
    /// </summary>
    public class Detalle_Antecedentes_Familiares: BaseEntity
    {
        public int Folio { get; set; }
        public int? Folio_Pacientes { get; set; }
        public int? Enfermedad { get; set; }
        public int? Parentesco { get; set; }

        [ForeignKey("Folio_Pacientes")]
        public virtual Spartane.Core.Classes.Pacientes.Pacientes Folio_Pacientes_Pacientes { get; set; }
        [ForeignKey("Enfermedad")]
        public virtual Spartane.Core.Classes.Padecimientos.Padecimientos Enfermedad_Padecimientos { get; set; }
        [ForeignKey("Parentesco")]
        public virtual Spartane.Core.Classes.Parentesco.Parentesco Parentesco_Parentesco { get; set; }

    }
}

