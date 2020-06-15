using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Spartan_System_Language
{
    /// <summary>
    /// Spartan_System_Language table
    /// </summary>
    public class Spartan_System_Language: BaseEntity
    {
        public short System_Language_Id { get; set; }
        public string Resource_File { get; set; }
        public string Language { get; set; }
        public bool Initial { get; set; }


    }
}

