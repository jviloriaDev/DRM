using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Classes.Spartan_System;
using Spartane.Core.Classes.Spartane_File;
using Spartane.Core.Classes.Spartan_Object_Config;
using Spartane.Core.Classes.Spartan_Module_Status;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Spartan_Module
{
    /// <summary>
    /// Spartan_Module table
    /// </summary>
    public class Spartan_Module: BaseEntity
    {
        public short Module_Id { get; set; }
        public string Name { get; set; }
        public short? System_Id { get; set; }
        public short? Parent_Module { get; set; }
        public short? Order_Shown { get; set; }
        public int? Image { get; set; }
        public short? Object_Config_Id { get; set; }
        public string Description { get; set; }
        public short? Status { get; set; }

        [ForeignKey("System_Id")]
        public virtual Spartane.Core.Classes.Spartan_System.Spartan_System System_Id_Spartan_System { get; set; }
        [ForeignKey("Image")]
        public virtual Spartane.Core.Classes.Spartane_File.Spartane_File Image_Spartane_File { get; set; }
        [ForeignKey("Object_Config_Id")]
        public virtual Spartane.Core.Classes.Spartan_Object_Config.Spartan_Object_Config Object_Config_Id_Spartan_Object_Config { get; set; }
        [ForeignKey("Status")]
        public virtual Spartane.Core.Classes.Spartan_Module_Status.Spartan_Module_Status Status_Spartan_Module_Status { get; set; }

    }
}

