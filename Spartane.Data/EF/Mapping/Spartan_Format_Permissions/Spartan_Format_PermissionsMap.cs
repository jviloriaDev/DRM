using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Spartan_Format_Permissions
{
    public partial class Spartan_Format_PermissionsMap : EntityTypeConfiguration<Spartane.Core.Classes.Spartan_Format_Permissions.Spartan_Format_Permissions>
    {
        public Spartan_Format_PermissionsMap()
        {
            this.ToTable("Spartan_Format_Permissions");
            this.HasKey(a => a.PermissionId);
            this.Ignore(a => a.Id);
        }
    }
}
