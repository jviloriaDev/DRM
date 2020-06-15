using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Rango_de_Horas
{
    public partial class Rango_de_HorasMap : EntityTypeConfiguration<Spartane.Core.Classes.Rango_de_Horas.Rango_de_Horas>
    {
        public Rango_de_HorasMap()
        {
            this.ToTable("Rango_de_Horas");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Clave);
        }
    }
}
