using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Tipo_de_Dieta
{
    /// <summary>
    /// Tipo_de_Dieta table
    /// </summary>
    public class Tipo_de_Dieta: BaseEntity
    {
        public int Clave { get; set; }
        public string Descripcion { get; set; }


    }
}

