using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Spartan_Method_Clasification
{
    public partial class Spartan_Method_ClasificationMap : EntityTypeConfiguration<Spartane.Core.Classes.Spartan_Method_Clasification.Spartan_Method_Clasification>
    {
        public Spartan_Method_ClasificationMap()
        {
            this.ToTable("Spartan_Method_Clasification");
            this.HasKey(a => a.Method_Classification_Id);
            this.Ignore(a => a.Id);
        }
    }
}
