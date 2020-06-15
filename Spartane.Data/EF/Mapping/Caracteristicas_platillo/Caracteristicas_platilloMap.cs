using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Caracteristicas_platillo
{
    public partial class Caracteristicas_platilloMap : EntityTypeConfiguration<Spartane.Core.Classes.Caracteristicas_platillo.Caracteristicas_platillo>
    {
        public Caracteristicas_platilloMap()
        {
            this.ToTable("Caracteristicas_platillo");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Folio);
        }
    }
}
