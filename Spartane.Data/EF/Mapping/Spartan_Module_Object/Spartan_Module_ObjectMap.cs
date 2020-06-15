using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Spartan_Module_Object
{
    public partial class Spartan_Module_ObjectMap : EntityTypeConfiguration<Spartane.Core.Classes.Spartan_Module_Object.Spartan_Module_Object>
    {
        public Spartan_Module_ObjectMap()
        {
            this.ToTable("Spartan_Module_Object");
            this.HasKey(a => a.Module_Object_Id);
            this.Ignore(a => a.Id);
        }
    }
}
