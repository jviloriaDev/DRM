using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Interpretacion_consumo_de_agua
{
    /// <summary>
    /// Interpretacion_consumo_de_agua table
    /// </summary>
    public class Interpretacion_consumo_de_agua: BaseEntity
    {
        public int Folio { get; set; }
        public string Descripcion { get; set; }


    }
}

