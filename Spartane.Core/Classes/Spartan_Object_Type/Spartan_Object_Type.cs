using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Spartan_Object_Type
{
    /// <summary>
    /// Spartan_Object_Type table
    /// </summary>
    public class Spartan_Object_Type: BaseEntity
    {
        public short Object_Type_Id { get; set; }
        public string Description { get; set; }


    }
}

