using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Parentescos_Empleados
{
    public partial class Parentescos_EmpleadosMap : EntityTypeConfiguration<Spartane.Core.Classes.Parentescos_Empleados.Parentescos_Empleados>
    {
        public Parentescos_EmpleadosMap()
        {
            this.ToTable("Parentescos_Empleados");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Folio);
        }
    }
}
