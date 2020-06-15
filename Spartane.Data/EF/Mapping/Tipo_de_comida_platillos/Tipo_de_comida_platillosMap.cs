using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Tipo_de_comida_platillos
{
    public partial class Tipo_de_comida_platillosMap : EntityTypeConfiguration<Spartane.Core.Classes.Tipo_de_comida_platillos.Tipo_de_comida_platillos>
    {
        public Tipo_de_comida_platillosMap()
        {
            this.ToTable("Tipo_de_comida_platillos");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Folio);
        }
    }
}
