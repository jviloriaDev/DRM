using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Interpretacion_Dificultad_de_Rutina_de_Ejercicios
{
    public partial class Interpretacion_Dificultad_de_Rutina_de_EjerciciosMap : EntityTypeConfiguration<Spartane.Core.Classes.Interpretacion_Dificultad_de_Rutina_de_Ejercicios.Interpretacion_Dificultad_de_Rutina_de_Ejercicios>
    {
        public Interpretacion_Dificultad_de_Rutina_de_EjerciciosMap()
        {
            this.ToTable("Interpretacion_Dificultad_de_Rutina_de_Ejercicios");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Folio);
        }
    }
}
