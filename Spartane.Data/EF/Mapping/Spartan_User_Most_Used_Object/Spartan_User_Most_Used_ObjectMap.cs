using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Spartan_User_Most_Used_Object
{
    public partial class Spartan_User_Most_Used_ObjectMap : EntityTypeConfiguration<Spartane.Core.Classes.Spartan_User_Most_Used_Object.Spartan_User_Most_Used_Object>
    {
        public Spartan_User_Most_Used_ObjectMap()
        {
            this.ToTable("Spartan_User_Most_Used_Object");
            this.HasKey(a => a.User_Most_Used_Object_Id);
            this.Ignore(a => a.Id);
        }
    }
}
