using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Spartan_User_Status
{
    public partial class Spartan_User_StatusMap : EntityTypeConfiguration<Spartane.Core.Classes.Spartan_User_Status.Spartan_User_Status>
    {
        public Spartan_User_StatusMap()
        {
            this.ToTable("Spartan_User_Status");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.User_Status_Id);
        }
    }
}
