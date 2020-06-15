using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Nivel_de_dificultad
{
    public partial class Nivel_de_dificultadMap : EntityTypeConfiguration<Spartane.Core.Classes.Nivel_de_dificultad.Nivel_de_dificultad>
    {
        public Nivel_de_dificultadMap()
        {
            this.ToTable("Nivel_de_dificultad");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Folio);
        }
    }
}
