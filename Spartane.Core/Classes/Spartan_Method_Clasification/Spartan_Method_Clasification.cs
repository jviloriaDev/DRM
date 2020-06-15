using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Spartan_Method_Clasification
{
    /// <summary>
    /// Spartan_Method_Clasification table
    /// </summary>
    public class Spartan_Method_Clasification: BaseEntity
    {
        public short Method_Classification_Id { get; set; }
        public string Description { get; set; }


    }
}

