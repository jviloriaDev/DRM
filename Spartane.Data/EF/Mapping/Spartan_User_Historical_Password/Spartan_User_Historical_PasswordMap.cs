using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Spartan_User_Historical_Password
{
    public partial class Spartan_User_Historical_PasswordMap : EntityTypeConfiguration<Spartane.Core.Classes.Spartan_User_Historical_Password.Spartan_User_Historical_Password>
    {
        public Spartan_User_Historical_PasswordMap()
        {
            this.ToTable("Spartan_User_Historical_Password");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Clave);
        }
    }
}
