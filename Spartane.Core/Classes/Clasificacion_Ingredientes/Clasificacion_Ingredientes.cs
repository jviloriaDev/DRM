using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Clasificacion_Ingredientes
{
    /// <summary>
    /// Clasificacion_Ingredientes table
    /// </summary>
    public class Clasificacion_Ingredientes: BaseEntity
    {
        public int Clave { get; set; }
        public string Descripcion { get; set; }


    }
}

