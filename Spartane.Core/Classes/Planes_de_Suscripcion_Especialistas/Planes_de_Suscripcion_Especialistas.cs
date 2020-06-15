using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Classes.Estatus;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Planes_de_Suscripcion_Especialistas
{
    /// <summary>
    /// Planes_de_Suscripcion_Especialistas table
    /// </summary>
    public class Planes_de_Suscripcion_Especialistas: BaseEntity
    {
        public int Folio { get; set; }
        public string Nombre { get; set; }
        public int? Costo { get; set; }
        public int? Estatus { get; set; }

        [ForeignKey("Estatus")]
        public virtual Spartane.Core.Classes.Estatus.Estatus Estatus_Estatus { get; set; }

    }
}

