using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Spartan_User_Favorite_Object
{
    public partial class Spartan_User_Favorite_ObjectMap : EntityTypeConfiguration<Spartane.Core.Classes.Spartan_User_Favorite_Object.Spartan_User_Favorite_Object>
    {
        public Spartan_User_Favorite_ObjectMap()
        {
            this.ToTable("Spartan_User_Favorite_Object");
            this.HasKey(a => a.User_Favorite_Object_Id);
            this.Ignore(a => a.Id);
        }
    }
}
