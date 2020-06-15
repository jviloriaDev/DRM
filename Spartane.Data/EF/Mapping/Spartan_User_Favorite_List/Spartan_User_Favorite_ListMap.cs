using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Spartan_User_Favorite_List
{
    public partial class Spartan_User_Favorite_ListMap : EntityTypeConfiguration<Spartane.Core.Classes.Spartan_User_Favorite_List.Spartan_User_Favorite_List>
    {
        public Spartan_User_Favorite_ListMap()
        {
            this.ToTable("Spartan_User_Favorite_List");
            this.HasKey(a => a.User_Favorite_List_Id);
            this.Ignore(a => a.Id);
        }
    }
}
