using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Spartan_Format_Configuration
{
    public partial class Spartan_Format_ConfigurationMap : EntityTypeConfiguration<Spartane.Core.Classes.Spartan_Format_Configuration.Spartan_Format_Configuration>
    {
        public Spartan_Format_ConfigurationMap()
        {
            this.ToTable("Spartan_Format_Configuration");
            this.HasKey(a => a.Format);
            this.Ignore(a => a.Id);
        }
    }
}
