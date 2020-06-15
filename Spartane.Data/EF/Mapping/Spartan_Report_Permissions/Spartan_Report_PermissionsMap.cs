using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Spartan_Report_Permissions
{
    public partial class Spartan_Report_PermissionsMap : EntityTypeConfiguration<Spartane.Core.Classes.Spartan_Report_Permissions.Spartan_Report_Permissions>
    {
        public Spartan_Report_PermissionsMap()
        {
            this.ToTable("Spartan_Report_Permissions");
            this.HasKey(a => a.ReportPermissionId);
            this.Ignore(a => a.Id);
        }
    }
}
