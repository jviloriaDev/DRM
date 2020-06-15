using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Periodo_del_dia
{
    public partial class Periodo_del_diaMap : EntityTypeConfiguration<Spartane.Core.Classes.Periodo_del_dia.Periodo_del_dia>
    {
        public Periodo_del_diaMap()
        {
            this.ToTable("Periodo_del_dia");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Clave);
        }
    }
}
