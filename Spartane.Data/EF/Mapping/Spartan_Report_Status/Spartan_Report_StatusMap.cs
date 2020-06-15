using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Spartan_Report_Status
{
    public partial class Spartan_Report_StatusMap : EntityTypeConfiguration<Spartane.Core.Classes.Spartan_Report_Status.Spartan_Report_Status>
    {
        public Spartan_Report_StatusMap()
        {
            this.ToTable("Spartan_Report_Status");
            this.HasKey(a => a.StatusId);
            this.Ignore(a => a.Id);
        }
    }
}
