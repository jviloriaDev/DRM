using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Classes.Spartan_Order_Type;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Spartan_Module_Config
{
    /// <summary>
    /// Spartan_Module_Config table
    /// </summary>
    public class Spartan_Module_Config: BaseEntity
    {
        public short Module_Config_Id { get; set; }
        public short? Order_Type { get; set; }

        [ForeignKey("Order_Type")]
        public virtual Spartane.Core.Classes.Spartan_Order_Type.Spartan_Order_Type Order_Type_Spartan_Order_Type { get; set; }

    }
}

