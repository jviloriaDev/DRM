using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Rango_Consumo_Bebidas
{
    /// <summary>
    /// Rango_Consumo_Bebidas table
    /// </summary>
    public class Rango_Consumo_Bebidas: BaseEntity
    {
        public int Clave { get; set; }
        public string Descripcion { get; set; }


    }
}

