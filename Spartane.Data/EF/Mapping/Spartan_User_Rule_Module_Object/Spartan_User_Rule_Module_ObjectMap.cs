using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Spartan_User_Rule_Module_Object
{
    public partial class Spartan_User_Rule_Module_ObjectMap : EntityTypeConfiguration<Spartane.Core.Classes.Spartan_User_Rule_Module_Object.Spartan_User_Rule_Module_Object>
    {
        public Spartan_User_Rule_Module_ObjectMap()
        {
            this.ToTable("Spartan_User_Rule_Module_Object");
            this.HasKey(a => a.User_Rule_Module_Object_Id);
            this.Ignore(a => a.Id);
        }
    }
}
