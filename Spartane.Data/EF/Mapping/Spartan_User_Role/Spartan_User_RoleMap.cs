using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Spartan_User_Role
{
    public partial class Spartan_User_RoleMap : EntityTypeConfiguration<Spartane.Core.Classes.Spartan_User_Role.Spartan_User_Role>
    {
        public Spartan_User_RoleMap()
        {
            this.ToTable("Spartan_User_Role");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.User_Role_Id);
        }
    }
}
