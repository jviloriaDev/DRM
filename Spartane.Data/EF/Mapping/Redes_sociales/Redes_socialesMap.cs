using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Redes_sociales
{
    public partial class Redes_socialesMap : EntityTypeConfiguration<Spartane.Core.Classes.Redes_sociales.Redes_sociales>
    {
        public Redes_socialesMap()
        {
            this.ToTable("Redes_sociales");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Clave);
        }
    }
}
