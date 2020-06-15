using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Nivel_de_Intensidad
{
    public partial class Nivel_de_IntensidadMap : EntityTypeConfiguration<Spartane.Core.Classes.Nivel_de_Intensidad.Nivel_de_Intensidad>
    {
        public Nivel_de_IntensidadMap()
        {
            this.ToTable("Nivel_de_Intensidad");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Folio);
        }
    }
}
