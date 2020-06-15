using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Pantalla_Francisco
{
    public partial class Pantalla_FranciscoMap : EntityTypeConfiguration<Spartane.Core.Classes.Pantalla_Francisco.Pantalla_Francisco>
    {
        public Pantalla_FranciscoMap()
        {
            this.ToTable("Pantalla_Francisco");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Folio);
        }
    }
}
