using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Indicadores_Laboratorio
{
    public partial class Indicadores_LaboratorioMap : EntityTypeConfiguration<Spartane.Core.Classes.Indicadores_Laboratorio.Indicadores_Laboratorio>
    {
        public Indicadores_LaboratorioMap()
        {
            this.ToTable("Indicadores_Laboratorio");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Folio);
        }
    }
}
