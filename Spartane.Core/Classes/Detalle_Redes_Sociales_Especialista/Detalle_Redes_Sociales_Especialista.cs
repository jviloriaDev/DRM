using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Classes.Medicos;
using Spartane.Core.Classes.Redes_sociales;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Detalle_Redes_Sociales_Especialista
{
    /// <summary>
    /// Detalle_Redes_Sociales_Especialista table
    /// </summary>
    public class Detalle_Redes_Sociales_Especialista: BaseEntity
    {
        public int Folio { get; set; }
        public int? Folio_Especialistas { get; set; }
        public int? Red_Social { get; set; }
        public string URL { get; set; }
        public bool? Principal { get; set; }

        [ForeignKey("Folio_Especialistas")]
        public virtual Spartane.Core.Classes.Medicos.Medicos Folio_Especialistas_Medicos { get; set; }
        [ForeignKey("Red_Social")]
        public virtual Spartane.Core.Classes.Redes_sociales.Redes_sociales Red_Social_Redes_sociales { get; set; }

    }
}

