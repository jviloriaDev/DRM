using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Spartan_Module_Object_Characteristic
{
    public partial class Spartan_Module_Object_CharacteristicMap : EntityTypeConfiguration<Spartane.Core.Classes.Spartan_Module_Object_Characteristic.Spartan_Module_Object_Characteristic>
    {
        public Spartan_Module_Object_CharacteristicMap()
        {
            this.ToTable("Spartan_Module_Object_Characteristic");
            this.HasKey(a => a.Module_Object_Characteristic_Id);
            this.Ignore(a => a.Id);
        }
    }
}
