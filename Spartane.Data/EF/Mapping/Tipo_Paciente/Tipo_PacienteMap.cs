using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Tipo_Paciente
{
    public partial class Tipo_PacienteMap : EntityTypeConfiguration<Spartane.Core.Classes.Tipo_Paciente.Tipo_Paciente>
    {
        public Tipo_PacienteMap()
        {
            this.ToTable("Tipo_Paciente");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Clave);
        }
    }
}
