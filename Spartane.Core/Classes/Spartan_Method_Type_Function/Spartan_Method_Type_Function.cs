using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Classes.Spartan_Function;
using Spartane.Core.Classes.Spartan_Method_Type;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Spartan_Method_Type_Function
{
    /// <summary>
    /// Spartan_Method_Type_Function table
    /// </summary>
    public class Spartan_Method_Type_Function: BaseEntity
    {
        public short Method_Type_Function_Id { get; set; }
        public short? Function_Id { get; set; }
        public short Spartan_Method_Type { get; set; }

        [ForeignKey("Function_Id")]
        public virtual Spartane.Core.Classes.Spartan_Function.Spartan_Function Function_Id_Spartan_Function { get; set; }
        [ForeignKey("Spartan_Method_Type")]
        public virtual Spartane.Core.Classes.Spartan_Method_Type.Spartan_Method_Type Spartan_Method_Type_Spartan_Method_Type { get; set; }

    }
}

