using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Interpretacion_IMC
{
    /// <summary>
    /// Interpretacion_IMC table
    /// </summary>
    public class Interpretacion_IMC: BaseEntity
    {
        public int Folio { get; set; }
        public string Descripcion { get; set; }


    }
}

