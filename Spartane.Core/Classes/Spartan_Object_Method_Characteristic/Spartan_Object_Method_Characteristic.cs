using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Spartan_Object_Method_Characteristic
{
    /// <summary>
    /// Spartan_Object_Method_Characteristic table
    /// </summary>
    public class Spartan_Object_Method_Characteristic: BaseEntity
    {
        public int Object_Method_Characteristic_Id { get; set; }
        public string Description { get; set; }


    }
}

