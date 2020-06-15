using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Spartan_Traduction_Detail
{
    public partial class Spartan_Traduction_DetailMap : EntityTypeConfiguration<Spartane.Core.Classes.Spartan_Traduction_Detail.Spartan_Traduction_Detail>
    {
        public Spartan_Traduction_DetailMap()
        {
            this.ToTable("Spartan_Traduction_Detail");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.IdTraductionDetail);
        }
    }
}
