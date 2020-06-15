using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Spartan_Function_Characteristic
{
    public partial class Spartan_Function_CharacteristicMap : EntityTypeConfiguration<Spartane.Core.Classes.Spartan_Function_Characteristic.Spartan_Function_Characteristic>
    {
        public Spartan_Function_CharacteristicMap()
        {
            this.ToTable("Spartan_Function_Characteristic");
            this.HasKey(a => a.Function_Characteristic);
            this.Ignore(a => a.Id);
        }
    }
}
