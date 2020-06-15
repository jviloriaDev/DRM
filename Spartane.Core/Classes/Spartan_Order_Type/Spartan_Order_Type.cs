using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Spartan_Order_Type
{
    /// <summary>
    /// Spartan_Order_Type table
    /// </summary>
    public class Spartan_Order_Type: BaseEntity
    {
        public short Order_Type_Id { get; set; }
        public string Description { get; set; }


    }
}

