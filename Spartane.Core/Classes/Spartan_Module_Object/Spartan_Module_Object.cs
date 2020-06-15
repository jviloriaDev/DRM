using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Classes.Spartan_Object;
using Spartane.Core.Classes.Spartan_Module;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Spartan_Module_Object
{
    /// <summary>
    /// Spartan_Module_Object table
    /// </summary>
    public class Spartan_Module_Object: BaseEntity
    {
        public int Module_Object_Id { get; set; }
        public int? Object_Id { get; set; }
        public short Module_Id { get; set; }
        public string Name { get; set; }
        public string Physical_Name { get; set; }
        public string URL { get; set; }
        public short? Order_Shown { get; set; }

        
        [ForeignKey("Object_Id")]
        public virtual Spartane.Core.Classes.Spartan_Object.Spartan_Object Object_Id_Spartan_Object { get; set; }
        [ForeignKey("Module_Id")]
        public virtual Spartane.Core.Classes.Spartan_Module.Spartan_Module Module_Id_Spartan_Module { get; set; }

    }
}

