using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Detalle_Registro_Beneficiarios_Empresa
{
    public partial class Detalle_Registro_Beneficiarios_EmpresaMap : EntityTypeConfiguration<Spartane.Core.Classes.Detalle_Registro_Beneficiarios_Empresa.Detalle_Registro_Beneficiarios_Empresa>
    {
        public Detalle_Registro_Beneficiarios_EmpresaMap()
        {
            this.ToTable("Detalle_Registro_Beneficiarios_Empresa");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Folio);
        }
    }
}
