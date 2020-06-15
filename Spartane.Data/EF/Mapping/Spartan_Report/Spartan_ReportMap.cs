using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Spartan_Report
{
    public partial class Spartan_ReportMap : EntityTypeConfiguration<Spartane.Core.Classes.Spartan_Report.Spartan_Report>
    {
        public Spartan_ReportMap()
        {
            this.ToTable("Spartan_Report");
            this.HasKey(a => a.ReportId);
            this.Ignore(a => a.Id);
        }
    }
}
