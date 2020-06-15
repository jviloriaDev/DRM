using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Classes.Spartan_Module;
using Spartane.Core.Classes.Spartan_Object;
using Spartane.Core.Classes.Spartan_Method_Type;
using Spartane.Core.Classes.Spartane_File;
using Spartane.Core.Classes.Spartan_Object_Method_Status;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Spartan_Object_Method
{
    /// <summary>
    /// Spartan_Object_Method table
    /// </summary>
    public class Spartan_Object_Method: BaseEntity
    {
        public short Module_Id { get; set; }
        public int? Object_Id { get; set; }
        public string Name { get; set; }
        public string Physical_Name { get; set; }
        public string URL { get; set; }
        public short? Method_Type { get; set; }
        public string Scope { get; set; }
        public string Tags { get; set; }
        public int? Image { get; set; }
        public short? Status { get; set; }
        public int Object_Method_Id { get; set; }

        [ForeignKey("Module_Id")]
        public virtual Spartane.Core.Classes.Spartan_Module.Spartan_Module Module_Id_Spartan_Module { get; set; }
        [ForeignKey("Object_Id")]
        public virtual Spartane.Core.Classes.Spartan_Object.Spartan_Object Object_Id_Spartan_Object { get; set; }
        [ForeignKey("Method_Type")]
        public virtual Spartane.Core.Classes.Spartan_Method_Type.Spartan_Method_Type Method_Type_Spartan_Method_Type { get; set; }
        [ForeignKey("Image")]
        public virtual Spartane.Core.Classes.Spartane_File.Spartane_File Image_Spartane_File { get; set; }
        [ForeignKey("Status")]
        public virtual Spartane.Core.Classes.Spartan_Object_Method_Status.Spartan_Object_Method_Status Status_Spartan_Object_Method_Status { get; set; }

    }
}

