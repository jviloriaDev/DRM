using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Classes.Spartan_Attribute_Type;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Spartan_Function_Characteristic
{
    /// <summary>
    /// Spartan_Function_Characteristic table
    /// </summary>
    public class Spartan_Function_Characteristic: BaseEntity
    {
        public short Function_Characteristic { get; set; }
        public string Description { get; set; }
        public int? Attribute_Type { get; set; }

        [ForeignKey("Attribute_Type")]
        public virtual Spartane.Core.Classes.Spartan_Attribute_Type.Spartan_Attribute_Type Attribute_Type_Spartan_Attribute_Type { get; set; }

    }
}

