using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Spartan_WorkFlow_Status
{
    public partial class Spartan_WorkFlow_StatusMap : EntityTypeConfiguration<Spartane.Core.Classes.Spartan_WorkFlow_Status.Spartan_WorkFlow_Status>
    {
        public Spartan_WorkFlow_StatusMap()
        {
            this.ToTable("Spartan_WorkFlow_Status");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.StatusId);
        }
    }
}
