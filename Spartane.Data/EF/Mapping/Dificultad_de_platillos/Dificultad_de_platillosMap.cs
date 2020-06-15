using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Dificultad_de_platillos
{
    public partial class Dificultad_de_platillosMap : EntityTypeConfiguration<Spartane.Core.Classes.Dificultad_de_platillos.Dificultad_de_platillos>
    {
        public Dificultad_de_platillosMap()
        {
            this.ToTable("Dificultad_de_platillos");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Clave);
        }
    }
}
