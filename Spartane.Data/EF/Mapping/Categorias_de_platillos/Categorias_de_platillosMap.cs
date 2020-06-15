using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Categorias_de_platillos
{
    public partial class Categorias_de_platillosMap : EntityTypeConfiguration<Spartane.Core.Classes.Categorias_de_platillos.Categorias_de_platillos>
    {
        public Categorias_de_platillosMap()
        {
            this.ToTable("Categorias_de_platillos");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Clave);
        }
    }
}
