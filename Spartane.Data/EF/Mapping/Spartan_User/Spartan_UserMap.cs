using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Spartan_User
{
    public partial class Spartan_UserMap : EntityTypeConfiguration<Spartane.Core.Classes.Spartan_User.Spartan_User>
    {
        public Spartan_UserMap()
        {
            this.ToTable("Spartan_User");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Id_User);
        }
    }
}
