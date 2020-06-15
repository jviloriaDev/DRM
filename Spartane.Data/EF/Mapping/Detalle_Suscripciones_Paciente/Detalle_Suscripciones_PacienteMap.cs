using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Detalle_Suscripciones_Paciente
{
    public partial class Detalle_Suscripciones_PacienteMap : EntityTypeConfiguration<Spartane.Core.Classes.Detalle_Suscripciones_Paciente.Detalle_Suscripciones_Paciente>
    {
        public Detalle_Suscripciones_PacienteMap()
        {
            this.ToTable("Detalle_Suscripciones_Paciente");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Folio);
        }
    }
}
