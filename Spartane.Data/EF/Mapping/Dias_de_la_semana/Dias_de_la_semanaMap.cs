using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Dias_de_la_semana
{
    public partial class Dias_de_la_semanaMap : EntityTypeConfiguration<Spartane.Core.Classes.Dias_de_la_semana.Dias_de_la_semana>
    {
        public Dias_de_la_semanaMap()
        {
            this.ToTable("Dias_de_la_semana");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Clave);
        }
    }
}
