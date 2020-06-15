using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Spartan_Traduction_Process_Data
{
    public partial class Spartan_Traduction_Process_DataMap : EntityTypeConfiguration<Spartane.Core.Classes.Spartan_Traduction_Process_Data.Spartan_Traduction_Process_Data>
    {
        public Spartan_Traduction_Process_DataMap()
        {
            this.ToTable("Spartan_Traduction_Process_Data");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Clave);
        }
    }
}
