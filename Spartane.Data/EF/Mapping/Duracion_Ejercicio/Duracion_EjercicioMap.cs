using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Duracion_Ejercicio
{
    public partial class Duracion_EjercicioMap : EntityTypeConfiguration<Spartane.Core.Classes.Duracion_Ejercicio.Duracion_Ejercicio>
    {
        public Duracion_EjercicioMap()
        {
            this.ToTable("Duracion_Ejercicio");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Clave);
        }
    }
}
