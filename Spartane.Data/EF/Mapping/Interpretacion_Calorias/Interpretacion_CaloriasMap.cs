using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Interpretacion_Calorias
{
    public partial class Interpretacion_CaloriasMap : EntityTypeConfiguration<Spartane.Core.Classes.Interpretacion_Calorias.Interpretacion_Calorias>
    {
        public Interpretacion_CaloriasMap()
        {
            this.ToTable("Interpretacion_Calorias");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Folio);
        }
    }
}
