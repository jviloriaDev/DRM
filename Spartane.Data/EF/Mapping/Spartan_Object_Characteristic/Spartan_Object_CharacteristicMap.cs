using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Spartan_Object_Characteristic
{
    public partial class Spartan_Object_CharacteristicMap : EntityTypeConfiguration<Spartane.Core.Classes.Spartan_Object_Characteristic.Spartan_Object_Characteristic>
    {
        public Spartan_Object_CharacteristicMap()
        {
            this.ToTable("Spartan_Object_Characteristic");
            this.HasKey(a => a.Object_Characteristc_Id);
            this.Ignore(a => a.Id);
        }
    }
}
