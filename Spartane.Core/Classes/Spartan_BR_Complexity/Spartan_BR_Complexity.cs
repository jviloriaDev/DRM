using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Spartan_BR_Complexity
{
    /// <summary>
    /// Spartan_BR_Complexity table
    /// </summary>
    public class Spartan_BR_Complexity: BaseEntity
    {
        public int Key_Complexity { get; set; }
        public string Description { get; set; }


    }
}

