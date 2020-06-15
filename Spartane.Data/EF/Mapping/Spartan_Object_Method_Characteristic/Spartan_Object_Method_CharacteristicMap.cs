using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Spartan_Object_Method_Characteristic
{
    public partial class Spartan_Object_Method_CharacteristicMap : EntityTypeConfiguration<Spartane.Core.Classes.Spartan_Object_Method_Characteristic.Spartan_Object_Method_Characteristic>
    {
        public Spartan_Object_Method_CharacteristicMap()
        {
            this.ToTable("Spartan_Object_Method_Characteristic");
            this.HasKey(a => a.Object_Method_Characteristic_Id);
            this.Ignore(a => a.Id);
        }
    }
}
