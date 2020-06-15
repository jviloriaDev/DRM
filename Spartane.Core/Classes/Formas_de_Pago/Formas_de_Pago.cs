using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Formas_de_Pago
{
    /// <summary>
    /// Formas_de_Pago table
    /// </summary>
    public class Formas_de_Pago: BaseEntity
    {
        public int Clave { get; set; }
        public string Nombre { get; set; }


    }
}

