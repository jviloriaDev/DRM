using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Frecuencia_de_pago_Especialistas
{
    /// <summary>
    /// Frecuencia_de_pago_Especialistas table
    /// </summary>
    public class Frecuencia_de_pago_Especialistas: BaseEntity
    {
        public int Clave { get; set; }
        public string Nombre { get; set; }


    }
}

