using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Nivel_de_Satisfaccion
{
    public partial class Nivel_de_SatisfaccionMap : EntityTypeConfiguration<Spartane.Core.Classes.Nivel_de_Satisfaccion.Nivel_de_Satisfaccion>
    {
        public Nivel_de_SatisfaccionMap()
        {
            this.ToTable("Nivel_de_Satisfaccion");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Clave);
        }
    }
}
