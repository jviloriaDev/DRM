using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Spartan_User_Quicklink
{
    public partial class Spartan_User_QuicklinkMap : EntityTypeConfiguration<Spartane.Core.Classes.Spartan_User_Quicklink.Spartan_User_Quicklink>
    {
        public Spartan_User_QuicklinkMap()
        {
            this.ToTable("Spartan_User_Quicklink");
            this.HasKey(a => a.User_Quicklink_Id);
            this.Ignore(a => a.Id);
        }
    }
}
