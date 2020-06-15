using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Tipo_de_Dieta
{
    public partial class Tipo_de_DietaMap : EntityTypeConfiguration<Spartane.Core.Classes.Tipo_de_Dieta.Tipo_de_Dieta>
    {
        public Tipo_de_DietaMap()
        {
            this.ToTable("Tipo_de_Dieta");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Clave);
        }
    }
}
