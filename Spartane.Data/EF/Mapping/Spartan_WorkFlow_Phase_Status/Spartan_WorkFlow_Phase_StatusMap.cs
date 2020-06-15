using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Spartan_WorkFlow_Phase_Status
{
    public partial class Spartan_WorkFlow_Phase_StatusMap : EntityTypeConfiguration<Spartane.Core.Classes.Spartan_WorkFlow_Phase_Status.Spartan_WorkFlow_Phase_Status>
    {
        public Spartan_WorkFlow_Phase_StatusMap()
        {
            this.ToTable("Spartan_WorkFlow_Phase_Status");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.StatusId);
        }
    }
}
