using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Spartan_BR_Complexity
{
    public partial class Spartan_BR_ComplexityMap : EntityTypeConfiguration<Spartane.Core.Classes.Spartan_BR_Complexity.Spartan_BR_Complexity>
    {
        public Spartan_BR_ComplexityMap()
        {
            this.ToTable("Spartan_BR_Complexity");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Key_Complexity);
        }
    }
}
