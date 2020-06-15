using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Antiguedad_Ejercicios
{
    public partial class Antiguedad_EjerciciosMap : EntityTypeConfiguration<Spartane.Core.Classes.Antiguedad_Ejercicios.Antiguedad_Ejercicios>
    {
        public Antiguedad_EjerciciosMap()
        {
            this.ToTable("Antiguedad_Ejercicios");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Clave);
        }
    }
}
