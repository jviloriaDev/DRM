using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Classes.Spartan_User;
using Spartane.Core.Classes.Spartan_BR_Rejection_Reason;
using Spartane.Core.Classes.Spartane_File;
using Spartane.Core.Classes.Business_Rule_Creation;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Spartan_BR_Peer_Review
{
    /// <summary>
    /// Spartan_BR_Peer_Review table
    /// </summary>
    public class Spartan_BR_Peer_Review: BaseEntity
    {
        public int Key_Peer_Review { get; set; }
        public int? User_that_reviewed { get; set; }
        public string Acceptance_Criteria { get; set; }
        public bool? It_worked { get; set; }
        public int? Rejection_reason { get; set; }
        public string Comments { get; set; }
        public int? Evidence { get; set; }
        public string Evidence_URL { get; set; }
        public int? Business_Rule { get; set; }

        [ForeignKey("User_that_reviewed")]
        public virtual Spartane.Core.Classes.Spartan_User.Spartan_User User_that_reviewed_Spartan_User { get; set; }
        [ForeignKey("Rejection_reason")]
        public virtual Spartane.Core.Classes.Spartan_BR_Rejection_Reason.Spartan_BR_Rejection_Reason Rejection_reason_Spartan_BR_Rejection_Reason { get; set; }
        [ForeignKey("Evidence")]
        public virtual Spartane.Core.Classes.Spartane_File.Spartane_File Evidence_Spartane_File { get; set; }
        [ForeignKey("Business_Rule")]
        public virtual Spartane.Core.Classes.Business_Rule_Creation.Business_Rule_Creation Business_Rule_Business_Rule_Creation { get; set; }

    }
}

