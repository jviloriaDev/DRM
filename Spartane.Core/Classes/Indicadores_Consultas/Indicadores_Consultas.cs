using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Indicadores_Consultas
{
    /// <summary>
    /// Indicadores_Consultas table
    /// </summary>
    public class Indicadores_Consultas: BaseEntity
    {
        public int Clave { get; set; }
        public string Nombre { get; set; }


    }
}

