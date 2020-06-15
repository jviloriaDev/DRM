using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Dashboard_Status
{
    public partial class Dashboard_StatusMap : EntityTypeConfiguration<Spartane.Core.Classes.Dashboard_Status.Dashboard_Status>
    {
        public Dashboard_StatusMap()
        {
            this.ToTable("Dashboard_Status");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Status_Id);
        }
    }
}
