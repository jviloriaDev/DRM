using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Musculos
{
    /// <summary>
    /// Musculos table
    /// </summary>
    public class Musculos: BaseEntity
    {
        public int Folio { get; set; }
        public string Descripcion { get; set; }


    }
}

