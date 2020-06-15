using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Identificaciones_Oficiales
{
    /// <summary>
    /// Identificaciones_Oficiales table
    /// </summary>
    public class Identificaciones_Oficiales: BaseEntity
    {
        public int Clave { get; set; }
        public string Descripcion { get; set; }


    }
}

