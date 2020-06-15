using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Detalle_Pagos_Especialistas
{
    public partial class Detalle_Pagos_EspecialistasMap : EntityTypeConfiguration<Spartane.Core.Classes.Detalle_Pagos_Especialistas.Detalle_Pagos_Especialistas>
    {
        public Detalle_Pagos_EspecialistasMap()
        {
            this.ToTable("Detalle_Pagos_Especialistas");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Folio);
        }
    }
}
