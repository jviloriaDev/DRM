using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Spartan_User_Alert
{
    public partial class Spartan_User_AlertMap : EntityTypeConfiguration<Spartane.Core.Classes.Spartan_User_Alert.Spartan_User_Alert>
    {
        public Spartan_User_AlertMap()
        {
            this.ToTable("Spartan_User_Alert");
            this.HasKey(a => a.User__Alert_Id);
            this.Ignore(a => a.Id);
        }
    }
}
