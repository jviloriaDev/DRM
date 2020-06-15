using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Tipo_de_comida_platillos
{
    /// <summary>
    /// Tipo_de_comida_platillos table
    /// </summary>
    public class Tipo_de_comida_platillos: BaseEntity
    {
        public int Folio { get; set; }
        public string Tipo_de_comida { get; set; }


    }
}

