using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Frecuencia_Ejercicio
{
    public partial class Frecuencia_EjercicioMap : EntityTypeConfiguration<Spartane.Core.Classes.Frecuencia_Ejercicio.Frecuencia_Ejercicio>
    {
        public Frecuencia_EjercicioMap()
        {
            this.ToTable("Frecuencia_Ejercicio");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Clave);
        }
    }
}
