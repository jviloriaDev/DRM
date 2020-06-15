using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Spartan_User_Role_Status
{
    public partial class Spartan_User_Role_StatusMap : EntityTypeConfiguration<Spartane.Core.Classes.Spartan_User_Role_Status.Spartan_User_Role_Status>
    {
        public Spartan_User_Role_StatusMap()
        {
            this.ToTable("Spartan_User_Role_Status");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.User_Role_Status_Id);
        }
    }
}
