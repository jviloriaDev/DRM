using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Spartan_Module_Config
{
    public partial class Spartan_Module_ConfigMap : EntityTypeConfiguration<Spartane.Core.Classes.Spartan_Module_Config.Spartan_Module_Config>
    {
        public Spartan_Module_ConfigMap()
        {
            this.ToTable("Spartan_Module_Config");
            this.HasKey(a => a.Module_Config_Id);
            this.Ignore(a => a.Id);
        }
    }
}
