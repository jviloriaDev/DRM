using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Spartan_Function_Characteristic_Config
{
    public partial class Spartan_Function_Characteristic_ConfigMap : EntityTypeConfiguration<Spartane.Core.Classes.Spartan_Function_Characteristic_Config.Spartan_Function_Characteristic_Config>
    {
        public Spartan_Function_Characteristic_ConfigMap()
        {
            this.ToTable("Spartan_Function_Characteristic_Config");
            this.HasKey(a => a.Function_Characteristic_Config_Id);
            this.Ignore(a => a.Id);
        }
    }
}
