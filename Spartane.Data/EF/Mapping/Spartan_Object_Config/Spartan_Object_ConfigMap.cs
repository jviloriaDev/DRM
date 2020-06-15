using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Spartan_Object_Config
{
    public partial class Spartan_Object_ConfigMap : EntityTypeConfiguration<Spartane.Core.Classes.Spartan_Object_Config.Spartan_Object_Config>
    {
        public Spartan_Object_ConfigMap()
        {
            this.ToTable("Spartan_Object_Config");
            this.HasKey(a => a.Object_Config_Id);
            this.Ignore(a => a.Id);
        }
    }
}
