using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Detalle_Ejercicios_Rutinas
{
    public partial class Detalle_Ejercicios_RutinasMap : EntityTypeConfiguration<Spartane.Core.Classes.Detalle_Ejercicios_Rutinas.Detalle_Ejercicios_Rutinas>
    {
        public Detalle_Ejercicios_RutinasMap()
        {
            this.ToTable("Detalle_Ejercicios_Rutinas");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Folio);
        }
    }
}
