using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Spartan_Language_Text
{
    /// <summary>
    /// Spartan_Language_Text table
    /// </summary>
    public class Spartan_Language_Text: BaseEntity
    {
        public short? System_Language_Id { get; set; }
        public int? Text_Id { get; set; }
        public string Text { get; set; }
        public int Language_Text_Id { get; set; }


    }
}

