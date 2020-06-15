using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Seleccion_de_Rangos
{
    public partial class Seleccion_de_RangosMap : EntityTypeConfiguration<Spartane.Core.Classes.Seleccion_de_Rangos.Seleccion_de_Rangos>
    {
        public Seleccion_de_RangosMap()
        {
            this.ToTable("Seleccion_de_Rangos");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Clave);
        }
    }
}
