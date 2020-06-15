using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Classes.Spartane_File;
using Spartane.Core.Classes.Spartan_Object_Type;
using Spartane.Core.Classes.Spartan_Object_Status;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Spartan_Object
{
    /// <summary>
    /// Spartan_Object table
    /// </summary>
    public class Spartan_Object: BaseEntity
    {
        public int Object_Id { get; set; }
        public string Name { get; set; }
        public int? Image { get; set; }
        public string URL { get; set; }
        public string Description { get; set; }
        public string Tags { get; set; }
        public short? Object_Type { get; set; }
        public short? Status { get; set; }

        [ForeignKey("Image")]
        public virtual Spartane.Core.Classes.Spartane_File.Spartane_File Image_Spartane_File { get; set; }
        [ForeignKey("Object_Type")]
        public virtual Spartane.Core.Classes.Spartan_Object_Type.Spartan_Object_Type Object_Type_Spartan_Object_Type { get; set; }
        [ForeignKey("Status")]
        public virtual Spartane.Core.Classes.Spartan_Object_Status.Spartan_Object_Status Status_Spartan_Object_Status { get; set; }

    }
}

