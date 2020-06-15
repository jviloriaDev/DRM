using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Spartan_BR_Rejection_Reason
{
    public partial class Spartan_BR_Rejection_ReasonMap : EntityTypeConfiguration<Spartane.Core.Classes.Spartan_BR_Rejection_Reason.Spartan_BR_Rejection_Reason>
    {
        public Spartan_BR_Rejection_ReasonMap()
        {
            this.ToTable("Spartan_BR_Rejection_Reason");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Key_Rejection_Reason);
        }
    }
}
