using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Detalle_Convenio_Medicos_Aseguradoras
{
    public partial class Detalle_Convenio_Medicos_AseguradorasMap : EntityTypeConfiguration<Spartane.Core.Classes.Detalle_Convenio_Medicos_Aseguradoras.Detalle_Convenio_Medicos_Aseguradoras>
    {
        public Detalle_Convenio_Medicos_AseguradorasMap()
        {
            this.ToTable("Detalle_Convenio_Medicos_Aseguradoras");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Folio);
        }
    }
}
