using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.MS_Exclusion_Ingredientes_Paciente
{
    public partial class MS_Exclusion_Ingredientes_PacienteMap : EntityTypeConfiguration<Spartane.Core.Classes.MS_Exclusion_Ingredientes_Paciente.MS_Exclusion_Ingredientes_Paciente>
    {
        public MS_Exclusion_Ingredientes_PacienteMap()
        {
            this.ToTable("MS_Exclusion_Ingredientes_Paciente");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Folio);
        }
    }
}
