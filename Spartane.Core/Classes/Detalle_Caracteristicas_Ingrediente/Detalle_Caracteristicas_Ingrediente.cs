using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Classes.Ingredientes;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Detalle_Caracteristicas_Ingrediente
{
    /// <summary>
    /// Detalle_Caracteristicas_Ingrediente table
    /// </summary>
    public class Detalle_Caracteristicas_Ingrediente: BaseEntity
    {
        public int Folio { get; set; }
        public int? Folio_Ingrediente { get; set; }
        public string Caracteristica_combo { get; set; }
        public string Descripcion_texto { get; set; }

        [ForeignKey("Folio_Ingrediente")]
        public virtual Spartane.Core.Classes.Ingredientes.Ingredientes Folio_Ingrediente_Ingredientes { get; set; }

    }
}

