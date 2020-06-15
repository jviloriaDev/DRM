using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Pantalla_Francisco
{
    /// <summary>
    /// Pantalla_Francisco table
    /// </summary>
    public class Pantalla_Francisco: BaseEntity
    {
        public int Folio { get; set; }
        public string Campo { get; set; }


    }
}

