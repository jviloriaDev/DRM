using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Dias_de_la_semana
{
    /// <summary>
    /// Dias_de_la_semana table
    /// </summary>
    public class Dias_de_la_semana: BaseEntity
    {
        public int Clave { get; set; }
        public string Texto { get; set; }
        public string Dia { get; set; }


    }
}

