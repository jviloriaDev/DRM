using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Spartan_BR_Status
{
    public partial class Spartan_BR_StatusMap : EntityTypeConfiguration<Spartane.Core.Classes.Spartan_BR_Status.Spartan_BR_Status>
    {
        public Spartan_BR_StatusMap()
        {
            this.ToTable("Spartan_BR_Status");
            this.HasKey(a => a.StatusId);
            this.Ignore(a => a.Id);
        }
    }
}
