using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Spartan_BR_Testing
{
    public partial class Spartan_BR_TestingMap : EntityTypeConfiguration<Spartane.Core.Classes.Spartan_BR_Testing.Spartan_BR_Testing>
    {
        public Spartan_BR_TestingMap()
        {
            this.ToTable("Spartan_BR_Testing");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Key_Testing);
        }
    }
}
